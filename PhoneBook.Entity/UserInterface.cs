using PhoneBook.Entity.Controllers;
using PhoneBook.Entity.Models;
using PhoneBook.Entity.Services;
using Spectre.Console;
using static PhoneBook.Entity.Enums;


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
                                              .AddChoices(
                        MenuOption.AddSocialGroup,
                        MenuOption.ViewAllSocialGroups,
                        MenuOption.AddContact,
                        MenuOption.DeleteContact,
                        MenuOption.EditContact,
                        MenuOption.ViewContact,
                        MenuOption.ListAllContacts,
                        MenuOption.Exit));

                switch (option)
                {
                    case MenuOption.AddSocialGroup:
                        SocialGroupService.AddSocialGroup();
                        break;
                    case MenuOption.ViewAllSocialGroups:
                        SocialGroupService.GetSocialGroups();
                        break;
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
            var panel = new Panel($@"ContactId: {contact.ContactId}
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
            table.AddColumn("ContactId");
            table.AddColumn("Name");
            table.AddColumn("Phone Number");
            table.AddColumn("Email");

            foreach (var contact in contacts)
            {
                table.AddRow(contact.ContactId.ToString(), 
                    contact.Name,
                    contact.PhoneNumber,
                    contact.Email);
            }

            AnsiConsole.Write(table);

            Console.WriteLine("Enter a key to continue");
            Console.ReadLine();
            Console.Clear();
        }

        static internal void ShowSocialGroupsTable(List<SocialGroup> socialGroups)
        {
            var table = new Table();
            table.AddColumn("SocialGroupId");
            table.AddColumn("Name");

            foreach (var socialGroup in socialGroups)
            {
                table.AddRow(socialGroup.SocialGroupId.ToString(),
                    socialGroup.Name);
            }

            AnsiConsole.Write(table);

            Console.WriteLine("Enter a key to continue");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
