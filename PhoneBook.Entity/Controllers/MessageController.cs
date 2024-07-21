using PhoneBook.Entity.Models;

namespace PhoneBook.Entity.Controllers
{
    internal class MessageController
    {
        internal static void SendMessage(Message message)
        {
            using var db = new ContactContext();

            db.Add(message);

            db.SaveChanges();

        }


        internal static List<Message> GetMessagesByContactId(int contactId)
        {
            using var db = new ContactContext();
            var messages = db.Messages
                .Where(m => m.ContactId == contactId)
                .ToList();

            return messages;
        }
    }
}
