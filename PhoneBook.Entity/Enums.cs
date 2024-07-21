using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PhoneBook.Entity
{
    internal class Enums
    {
        internal enum MainMenuOptions
        {
            ManageSocialGroups,
            ManageContacts,
            Exit
        }

        internal enum SocialGroupOptions
        {
            AddSocialGroup,
            DeleteSocialGroup,
            EditSocialGroup,
            ViewSocialGroup,
            ViewAllSocialGroups,
            GoBack
        }

        internal enum ContactOptions
        {
            AddContact,
            DeleteContact,
            EditContact,
            ViewContact,
            ListAllContacts,
            SendMessage,
            GoBack
        }
    }
}
