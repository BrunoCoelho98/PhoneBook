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

        internal static void GetSocialGroups()
        {
            var socialGroups = SocialGroupController.GetSocialGroups();
            UserInterface.ShowSocialGroupsTable(socialGroups);
        }
    }
}
