using Spectre.Console;

namespace PhoneBook.Entity
{
    internal class ContactService
    {
        internal static void DeleteContact()
        {
            var contact = GetContactOptionInput();
            ContactController.DeleteContact(contact);
        }

        internal static void EditContact()
        {
            var contact = GetContactOptionInput();

            contact.Name = AnsiConsole.Confirm("Edit Name?") 
                ? AnsiConsole.Ask<string>("Enter new name: ")
                : contact.Name;

            contact.PhoneNumber = AnsiConsole.Confirm("Edit Phone Number?")
                ? AnsiConsole.Ask<string>("Enter new phone number: ")
                : contact.PhoneNumber;

            contact.Email = AnsiConsole.Confirm("Edit Email?")
                ? AnsiConsole.Ask<string>("Enter new email: ")
                : contact.Email;


         
            ContactController.EditContact(contact);
        }
        
        static public Contact GetContactOptionInput()
        {
            var contacts = ContactController.ListContacts();
            var contactsArray = contacts.Select(c => c.Name).ToArray();
            var contactName = AnsiConsole.Prompt(
                               new SelectionPrompt<string>()
                                .Title("Select a contact")
                                .AddChoices(contactsArray)
                                );
            var id = contacts.Single(c => c.Name == contactName).Id;
            var contact = ContactController.GetContactById(id);

            return contact;
        }

    }
}
