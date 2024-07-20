using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Entity
{
    internal class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=contacts.db");
        }
    }
    
}
