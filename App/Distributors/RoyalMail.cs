using Models;

namespace App.Distributors
{
    internal class RoyalMail : IDistributor
    {
        public string GetDbId()
        {
            return "RoyalMail";
        }

        public async Task SendPublication(Publication pub, Address address)
        {
            await Task.Delay(1000);
            Console.WriteLine(string.Format("RoyalMail sent {0} to {1}", pub.Title, address.StreetAddress));
        }
    }
}
