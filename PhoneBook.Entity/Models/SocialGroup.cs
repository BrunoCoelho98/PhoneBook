using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Entity.Models
{
    [Index(nameof(Name), IsUnique = true)]
    internal class SocialGroup
    {
        [Key]
        public int SocialGroupId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
