using App.DataAccessLayer;
using App.Distributors;
using Microsoft.EntityFrameworkCore;
using Models;

namespace App
{
    public class SubscriptionManager
    {
        Dictionary<string, IDistributor> distributorApis = new Dictionary<string, IDistributor>()
        {
            {"AusPost", new AusPost() },
            {"RoyalMail", new RoyalMail() }
        };


        public async Task RequestDistribution()
        {
                using AcmeContext db = new AcmeContext();
                List<Subscription> allSubscriptions = await db.Subscriptions
                    .Where(sub => sub.StartDate < DateTime.Now && sub.EndDate > DateTime.Now)
                    .Include("Address")
                    .Include("Publication")
                    .ToListAsync();

                // Connecting to third party APIs sequentially would take too long,
                // instead, fire them all off at once before waiting
                // TODO consider third-party API rate limits
                List<Task> apiTasks = new List<Task>();

                // Keep track of failed subscription orders so that we can
                // handle them properly, with something like exponential backoffs
                // or manual interventions
                List<Tuple<Subscription, DistributionCompany?>> failedTasks = new List<Tuple<Subscription, DistributionCompany?>>(); ;

                foreach (Subscription subscription in allSubscriptions)
                {
                    apiTasks.Add(Task.Run(async () =>
                    {
                        DistributionCompany? distributor = null;
                        try
                        {
                            // Each thread needs a new DB context
                            using (AcmeContext threadedDb = new AcmeContext())
                            {
                                int subCountryId = subscription.Address.CountryId;

                                // Get the list of distributors which can print this publication in this country
                                List<Distribution> availableDistributors = await threadedDb.Distributions.Where(d => d.CountryId == subCountryId && d.PublicationId == subscription.PublicationId)
                                        .GroupBy(sub => sub.CompanyId)
                                        .Select(group => group.First())
                                        .ToListAsync();

                                int distributorId = availableDistributors.First().Id;
                                distributor = threadedDb.DistributionCompanies.First(d => d.Id == distributorId);

                                if (distributor != null && distributorApis.ContainsKey(distributor.ImplementingClass))
                                {
                                    // attempt to call distributor's API
                                    await distributorApis[distributor.ImplementingClass].SendPublication(subscription.Publication, subscription.Address);
                                }
                                else
                                {
                                    throw new Exception(distributor != null ?
                                        distributor.Name + " API not implemented!" :
                                        string.Format("No distributor found for pub {0} + country {1}", subscription.PublicationId, subCountryId));
                                } 
                            }
                                
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.ToString());
                            failedTasks.Add(Tuple.Create(subscription, distributor));
                        }
                        
                    }));
                }

                await Task.WhenAll(apiTasks);

                if(failedTasks.Count > 0)
                {
                    // TODO implement retry system
                    Console.Error.WriteLine(failedTasks.Count + " API calls failed, please see error log");
                    foreach (var task in failedTasks)
                    {
                        Console.Error.WriteLine(string.Format("Failed to fulfill subscription {0}, {1}",
                            task.Item1.Id,
                            task.Item2 != null ? "distributor ID: " + task.Item2.Id : " distributor not found"));
                    }
                }
            }
        }
    }

