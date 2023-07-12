namespace Models
{
    public class Distribution
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public DistributionCompany Company { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
    }
}
