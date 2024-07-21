using PhoneBook.Entity.Controllers;
using PhoneBook.Entity.Models;
using Spectre.Console;
using static PhoneBook.Entity.Enums;

namespace PhoneBook.Entity.Services
{
    internal class MessageService
    {
        internal static void SendMessage()
        {
            var message = new Message();
            
            message.ContactId = ContactService.GetContactOptionInput().ContactId;

            message.Content = AnsiConsole.Ask<string>("Write you message: ");

            MessageController.SendMessage(message);
            
        }



    }
}
