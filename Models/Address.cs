namespace Models
{
    public class Address
    {
        public int Id { get; set; }
        public required string Nickname { get; set; }
        public required string StreetAddress { get; set; }
        public required string City { get; set; }
        public string? State { get; set; }
        public required string PostCode { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
