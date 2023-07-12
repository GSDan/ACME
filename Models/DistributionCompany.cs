namespace Models
{
    public class DistributionCompany
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ImplementingClass { get; set; }

        public ICollection<Distribution>? Distributions { get; set; }
    }
}
