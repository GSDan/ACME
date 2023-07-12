// See https://aka.ms/new-console-template for more information
using App.DataAccessLayer;
using App.Distributors;
using Microsoft.EntityFrameworkCore;
using Models;

Dictionary<string, IDistributor> distributors = new Dictionary<string, IDistributor>()
{
    {"RogerMail", new RogerMail() }
};


using (AcmeContext db = new AcmeContext())
{
    List<Subscription> allSubscriptions = await db.Subscriptions.Include("Address").ToListAsync();

    foreach (Subscription subscription in allSubscriptions)
    {
        int subCountryId = subscription.Address.CountryId;

        // Get the list of distributors which can print this publication in this country
        List<Distribution> availableDistributors = await db.Distributions.Where(d => d.CountryId == subCountryId && d.PublicationId == subscription.PublicationId)
                .GroupBy(sub => sub.CompanyId)
                .Select(group => group.First())
                .ToListAsync();

        Console.WriteLine(availableDistributors.ToString());
    }
}