using PhoneBook.Entity.Models;

namespace PhoneBook.Entity.Controllers
{
    internal class SocialGroupController
    {
        internal static void AddSocialGroup(SocialGroup socialGroup)
        {
            using var db = new ContactContext();

            db.Add(socialGroup);

            db.SaveChanges();

        }

        internal static void DeleteSocialGroup(SocialGroup socialGroup)
        {
            using var db = new ContactContext();

            db.Remove(socialGroup);

            db.SaveChanges();
        }

        internal static List<SocialGroup> GetSocialGroups()
        {
            using var db = new ContactContext();

            var socialGroups = db.SocialGroups.ToList();

            return socialGroups;
        }

    }
}
