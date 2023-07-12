using Models;

namespace App.Distributors
{
    public interface IDistributor
    {
        public string GetDbId();
        public Task SendPublication(Publication pub, Address address);
    }
}
