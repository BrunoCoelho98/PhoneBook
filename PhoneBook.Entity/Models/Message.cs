using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace PhoneBook.Entity.Models
{
    internal class Message
    {
        // Primary Key
        [Key]
        public int MessageId { get; set; }

        public int ContactId { get; set; }

        [Required]
        public string Content { get; set; }

    }
}
