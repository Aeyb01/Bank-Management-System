// Services => Account Creation Sub-Folder => Phone Number Sub-Folder

// PhoneNumber.cs

namespace BankManagementSystem
{
    public class PhoneNumber
    {
        public static string Phone()
        {
            string phoneNumber = FieldInputService.ProcessField
            (
                "Phone Number: ",
                "Enter Phone Number: ",
                PhoneNumberValidator.ValidatePhoneNumber,
                AccountCreationUI.accountCreationLines
            );

            // No need to convert the givien number into a digit
            // As it might contain + spaces or other allowed caracters

            return phoneNumber;
        }
    }
}