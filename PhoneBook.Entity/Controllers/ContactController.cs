using Microsoft.EntityFrameworkCore;
using PhoneBook.Entity.Models;
using Spectre.Console;

namespace PhoneBook.Entity.Controllers
{
    internal class ContactController
    {
        internal static void AddContact(Contact contact)
        {

            using var db = new ContactContext();

            db.Add(contact);
            db.SaveChanges();

        }

        internal static void DeleteContact(Contact contact)
        {
            using var db = new ContactContext();
            db.Remove(contact);
            db.SaveChanges();
        }

        internal static Contact GetContactById(int id)
        {
            using var db = new ContactContext();
            var contact = db.Contacts
                .Include(c => c.SocialGroup)
                .SingleOrDefault(c => c.ContactId == id);

            return contact;
        }

        internal static void EditContact(Contact contact)
        {
            using var db = new ContactContext();
            db.Update(contact);

            db.SaveChanges();
        }

        internal static List<Contact> ListContacts()
        {
            using var db = new ContactContext();

            var contacts = db.Contacts
                .Include(c => c.SocialGroup)
                .ToList();

            return contacts;


        }


    }
}
