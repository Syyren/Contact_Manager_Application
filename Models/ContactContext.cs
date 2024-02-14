using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contact_Manager_Application.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                 new Category { CategoryId = "F", Name = "Family" },
                 new Category { CategoryId = "Fr", Name = "Friend" },
                 new Category { CategoryId = "U", Name = "Unknown" },
                 new Category { CategoryId = "W", Name = "Work" }
             );
            modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                Id = 1,
                FirstName = "Ryan",
                LastName = "McGrandle",
                Phone = "888-888-8888",
                Email = "Ryan@McGrandle.com",
                CategoryId = "Fr",
                Organization = null,
                Log = DateTime.Now
            },
            new Contact
            {
                Id = 2,
                FirstName = "Kaden",
                LastName = "de Frece",
                Phone = "888-888-8889",
                Email = "Kaden@deFrece.com",
                CategoryId = "F",
                Organization = null,
                Log = DateTime.Now
            },
            new Contact
            {
                Id = 3,
                FirstName = "Dane",
                LastName = "Fillingham",
                Phone = "888-888-8887",
                Email = "Dane@Fillingham.com",
                CategoryId = "W",
                Organization = null,
                Log = DateTime.Now
            }
        );
        }
    }
}
