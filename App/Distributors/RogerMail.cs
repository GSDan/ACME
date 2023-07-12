using Models;

namespace App.Distributors
{
    public class RogerMail : IDistributor
    {
        public string GetDbId()
        {
            return "RogerMail";
        }

        public async Task SendPublication(Publication pub, Address address)
        {
            await Task.Delay(1000);
            Console.WriteLine(string.Format("Roger sent {0} to {1}", pub.Title, address.StreetAddress));
        }
    }
}
