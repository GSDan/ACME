using Microsoft.EntityFrameworkCore;
using Models;

namespace App.DataAccessLayer
{
    public class AcmeContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Distribution> Distributions { get; set; }
        public DbSet<DistributionCompany> DistributionCompanies { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public string DbPath { get; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasMany(c => c.Subscriptions).WithOne(s => s.Customer).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Subscription>().HasOne(s => s.Customer).WithMany(c => c.Subscriptions).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Publication>().HasData(new Publication { Id = 1, Title = "The Viz" });
            modelBuilder.Entity<DistributionCompany>().HasData(new DistributionCompany { Id = 1, Name = "Roger's Printing Services", ImplementingClass = "RogerMail" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Australia" });
            modelBuilder.Entity<Distribution>().HasData(new Distribution { Id = 1, CompanyId = 1, CountryId = 1, PublicationId = 1 });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 1, FirstName = "Dan", LastName = "Richardson", Email = "dan.richardson.gs@gmail.com", DefaultAddressId = 1 });
            modelBuilder.Entity<Address>().HasData(new Address { Id = 1, CountryId = 1, Nickname = "Home", StreetAddress = "19 Red Herring Place", City = "Belgrave", State = "VIC", PostCode = "3160" });
            modelBuilder.Entity<Subscription>().HasData(new Subscription { Id = 1, CustomerId = 1, PublicationId = 1, AddressId = 1, StartDate = new DateTime(2023, 4, 7), EndDate = new DateTime(2024, 4, 7) });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite($"Data Source={DbPath}");
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = acme; Integrated Security = True");
        }
    }
}
