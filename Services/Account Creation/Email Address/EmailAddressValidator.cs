// Services => Account Creation Sub-Folder => Email Address Sub-Folder

// EmailAddressValidator.cs

using System.Net.Mail;

namespace BankManagementSystem
{
    public class EmailAddressValidator
    {
        public static bool ValidateEmailAddress(string emailAddress)
        {
            try
            {
                var email = new MailAddress(emailAddress);
            }
            catch
            {
                ConsoleNotifiers.InvalidMessage("Invalid Email Adress.");
                return false;
            }
            return true;
        }
    }
}