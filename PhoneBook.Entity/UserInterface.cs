using Spectre.Console;


namespace PhoneBook.Entity
{
    static internal class UserInterface
    {
        static internal void MainMenu()
        {
            var isRunning = true;

            while (isRunning)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<MenuOption>()
                        .Title("What would you like to do?")
                                   .PageSize(10)
                                              .AddChoices(MenuOption.AddContact, MenuOption.DeleteContact, MenuOption.EditContact, MenuOption.ViewContact, MenuOption.ListAllContacts, MenuOption.Exit)
                                                 );
                switch (option)
                {
                    case MenuOption.AddContact:
                        ContactController.AddContact();
                        break;
                    case MenuOption.DeleteContact:
                        ContactService.DeleteContact();
                        break;
                    case MenuOption.EditContact:
                        ContactService.EditContact();
                        break;
                    case MenuOption.ViewContact:
                        var contact = ContactService.GetContactOptionInput();
                        UserInterface.ShowContact(contact);
                        break;
                    case MenuOption.ListAllContacts:
                        UserInterface.ShowContactsTable(ContactController.ListContacts());
                        break;
                }
            }
        }
        internal static void ShowContact(Contact contact)
        {
            var panel = new Panel($@"Id: {contact.Id}
Name: {contact.Name}");
                panel.Header = new PanelHeader("Contact Information");
                panel.Padding = new Padding(2, 2, 2, 2);
                
            AnsiConsole.Write(panel);

            Console.WriteLine("Enter a key to continue");
            Console.ReadLine();
            Console.Clear();

        }
        static internal void ShowContactsTable(List<Contact> contacts)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Name");
            table.AddColumn("Phone Number");
            table.AddColumn("Email");

            foreach (var contact in contacts)
            {
                table.AddRow(contact.Id.ToString(), 
                    contact.Name,
                    contact.PhoneNumber,
                    contact.Email);
            }

            AnsiConsole.Write(table);

            Console.WriteLine("Enter a key to continue");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
