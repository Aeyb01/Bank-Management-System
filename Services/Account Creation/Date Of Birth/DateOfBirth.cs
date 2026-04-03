// Service Folder => Account Creation Sub-Folder => Date Of Birth Sub-Folder

// DateOfBirth.cs


namespace BankManagementSystem
{
    public class DateOfBirth
    {
        public static string DateOfBirthHandler()
        {
            // Pretty much the same logic and ideas from
            // The NameHandler

            string birthDate = FieldInputService.ProcessField
            (
                "Date of Birth: ",
                "Give Date Of Birth In The Format Of YYYY/MM/DD: ",
                DateOfBirthValidator.ValidateDateOfBirth,
                AccountCreationUI.accountCreationLines
            );

            return birthDate;
        }
    }
}