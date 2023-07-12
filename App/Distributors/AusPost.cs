using Models;

namespace App.Distributors
{
    public class AusPost : IDistributor
    {
        public string GetDbId()
        {
            return "AusPost";
        }

        public async Task SendPublication(Publication pub, Address address)
        {
            await Task.Delay(3000);
            Console.WriteLine(string.Format("AusPost sent {0} to {1}", pub.Title, address.StreetAddress));
        }
    }
}
