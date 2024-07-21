using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PhoneBook.Entity.Models
{
    [Index(nameof(PhoneNumber), IsUnique = true)]
    
    internal class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // List of Messages
        public List<Message> Messages { get; set; }

        public int SocialGroupId { get; set; }

        [ForeignKey(nameof(SocialGroupId))]
        public SocialGroup SocialGroup { get; set; }

    }
}
