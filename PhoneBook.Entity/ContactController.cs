using Spectre.Console;

namespace PhoneBook.Entity
{
    internal class ContactController
    {
        internal static void AddContact()
        {
            var contact = new Contact();
            contact.Name = AnsiConsole.Ask<string>("Enter name: ");
            contact.PhoneNumber = AnsiConsole.Ask<string>("Enter phone number: ");
            contact.Email = AnsiConsole.Ask<string>("Enter email: ");

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
            var contact = db.Contacts.SingleOrDefault(c => c.Id == id);

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
            using var context = new ContactContext();

            var contacts = context.Contacts.ToList();

            return contacts;


        }


    }
}
