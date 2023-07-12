namespace Models
{
    public class Country
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public virtual ICollection<Distribution>? Distributions { get; set; }
    }
}
