using Microsoft.EntityFrameworkCore;
using PhoneBook.Entity.Models;

namespace PhoneBook.Entity
{
    internal class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<SocialGroup> SocialGroups { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=contacts.db");
        }
    }
    
}
