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
                Console.Clear();
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<MainMenuOptions>()
                        .Title("What would you like to do?")
                                              .AddChoices(
                        MainMenuOptions.ManageContacts,
                        MainMenuOptions.ManageSocialGroups,
                        MainMenuOptions.Exit));

                switch (option)
                {
                    case MainMenuOptions.ManageContacts:
                        ContactMenu();
                        break;
                    case MainMenuOptions.ManageSocialGroups:
                        SocialGroupMenu();
                        break;
                    case MainMenuOptions.Exit:
                        isRunning = false;
                        break;
                }

            }
        }

        static internal void ContactMenu()
        {
            var isContactMenuRunning = true;

            while (isContactMenuRunning)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<ContactOptions>()
                        .Title("What would you like to do?")
                                              .AddChoices(
                        ContactOptions.ViewContact,
                        ContactOptions.AddContact,
                        ContactOptions.DeleteContact,
                        ContactOptions.EditContact,
                        ContactOptions.ListAllContacts,
                        ContactOptions.GoBack));

                switch (option)
                {
                    case ContactOptions.AddContact:
                        ContactService.AddContact();
                        break;
                    case ContactOptions.DeleteContact:
                        ContactService.DeleteContact();
                        break;
                    case ContactOptions.EditContact:
                        ContactService.EditContact();
                        break;
                    case ContactOptions.ViewContact:
                        var contact = ContactService.GetContactOptionInput();
                        UserInterface.ShowContact(contact);
                        break;
                    case ContactOptions.ListAllContacts:
                        UserInterface.ShowContactsTable(ContactController.ListContacts());
                        break;
                    case ContactOptions.GoBack:
                        isContactMenuRunning = false;
                        break;
                }
            }
        }

        static internal void SocialGroupMenu()
        {
            var IsSocialGroupMenuRunning = true;

            while (IsSocialGroupMenuRunning)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<SocialGroupOptions>()
                        .Title("What would you like to do?")
                                              .AddChoices(
                        SocialGroupOptions.ViewSocialGroup,
                        SocialGroupOptions.AddSocialGroup,
                        SocialGroupOptions.DeleteSocialGroup,
                        SocialGroupOptions.EditSocialGroup,
                        SocialGroupOptions.ViewAllSocialGroups,
                        SocialGroupOptions.GoBack));

                switch (option)
                {
                    case SocialGroupOptions.AddSocialGroup:
                        SocialGroupService.AddSocialGroup();
                        break;
                    case SocialGroupOptions.DeleteSocialGroup:
                        SocialGroupService.DeleteSocialGroup();
                        break;
                    case SocialGroupOptions.EditSocialGroup:
                        SocialGroupService.EditSocialGroup();
                        break;
                    case SocialGroupOptions.ViewSocialGroup:
                        SocialGroupService.GetSocialGroup();
                        break;
                    case SocialGroupOptions.ViewAllSocialGroups:
                        SocialGroupService.GetSocialGroups();
                        break;
                    case SocialGroupOptions.GoBack:
                        IsSocialGroupMenuRunning = false;
                        break;
                }
            }
        }
        internal static void ShowContact(Contact contact)
        {
            var panel = new Panel($@"ContactId: {contact.ContactId}
Name: {contact.Name}
SocialGroup: {contact.SocialGroup.Name}");
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
            table.AddColumn("Social Group");

            foreach (var contact in contacts)
            {
                table.AddRow(contact.ContactId.ToString(), 
                    contact.Name,
                    contact.PhoneNumber,
                    contact.Email,
                    contact.SocialGroup.Name);
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

        static internal void ShowSocialGroup(SocialGroup socialGroup)
        {
            var panel = new Panel($@"SocialGroupId: {socialGroup.SocialGroupId}
Name: {socialGroup.Name}
Contact Count: {socialGroup.Contacts.Count}");
            panel.Header = new PanelHeader($"{socialGroup.Name}");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);
            ShowContactsTable(socialGroup.Contacts);

            Console.WriteLine("Enter a key to continue");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
