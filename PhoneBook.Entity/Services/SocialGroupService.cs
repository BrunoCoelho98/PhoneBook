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
            var socialGroupId = GetSocialGroupOptionInput();
            SocialGroupController.DeleteSocialGroup(new SocialGroup { SocialGroupId = socialGroupId });
        }

        internal static void GetSocialGroups()
        {
            var socialGroups = SocialGroupController.GetSocialGroups();
            UserInterface.ShowSocialGroupsTable(socialGroups);
        }

        internal static int GetSocialGroupOptionInput()
        {
            var socialGroups = SocialGroupController.GetSocialGroups();
            var socialGroupsArray = socialGroups.Select(c => c.Name).ToArray();
            var socialGroupName = AnsiConsole.Prompt(
                               new SelectionPrompt<string>()
                                .Title("Select a contact")
                                .AddChoices(socialGroupsArray)
                                );
            var id = socialGroups.Single(c => c.Name == socialGroupName).SocialGroupId;
            var socialGroup = ContactController.GetContactById(id);

            return id;
        }
    }
}
