using PhoneBook.Entity.Controllers;
using PhoneBook.Entity.Models;
using Spectre.Console;

namespace PhoneBook.Entity.Services
{
    internal class SocialGroupService
    {
        internal static void AddSocialGroup()
        {
            var socialGroup = new SocialGroup();

            socialGroup.Name = AnsiConsole.Ask<string>("Social Group's name:");

            SocialGroupController.AddSocialGroup(socialGroup);

        }

        internal static void DeleteSocialGroup()
        {
            var socialGroup = GetSocialGroupOptionInput();
            SocialGroupController.DeleteSocialGroup(socialGroup);
        }

        internal static void GetSocialGroups()
        {
            var socialGroups = SocialGroupController.GetSocialGroups();
            UserInterface.ShowSocialGroupsTable(socialGroups);
        }

        internal static void EditSocialGroup()
        {
            var socialGroup = GetSocialGroupOptionInput();

            socialGroup.Name = AnsiConsole.Confirm("Edit Name?")
                ? AnsiConsole.Ask<string>("Enter new name: ")
                : socialGroup.Name;

      
            SocialGroupController.EditSocialGroup(socialGroup);
        }

        internal static void GetSocialGroup()
        {
            var socialGroup = GetSocialGroupOptionInput();
            UserInterface.ShowSocialGroup(socialGroup);
        }

        internal static SocialGroup GetSocialGroupOptionInput()
        {
            var socialGroups = SocialGroupController.GetSocialGroups();
            var socialGroupsArray = socialGroups.Select(c => c.Name).ToArray();
            var socialGroupName = AnsiConsole.Prompt(
                               new SelectionPrompt<string>()
                                .Title("Select a contact")
                                .AddChoices(socialGroupsArray)
                                );
            var socialGroup = socialGroups.Single(c => c.Name == socialGroupName);

            return socialGroup;
        }
    }
}
