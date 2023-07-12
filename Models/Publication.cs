namespace Models
{
    public class Publication
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public ICollection<Distribution>? Distributions { get; set; }
    }
}
