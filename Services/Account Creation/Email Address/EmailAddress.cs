// Services => Account Creation Sub-Folder => Email Address Sub-Folder

// EmailAddress.cs

namespace BankManagementSystem
{
    public class EmailAddress
    {
        public static string Email()
        {
            string emailAddress = FieldInputService.ProcessField
            (
                "Email Address: ",
                "Enter Email Address: ",
                EmailAddressValidator.ValidateEmailAddress,
                AccountCreationUI.accountCreationLines
            );

            return emailAddress;
        }
    }
}