namespace Models
{
    public class Customer
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }

        public int DefaultAddressId { get; set; }
        public Address DefaultAddress { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }

    }
}