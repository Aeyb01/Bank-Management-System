// Services => Account Creation Sub-Folder => Account Type Sub-Folder

// AccountType.cs

namespace BankManagementSystem
{
    public class AccountType
    {
        public static string GetAccountType()
        {
            string accountType = FieldInputService.ProcessField
            (
                "Account Type: ",
                "Choose Between Savings Or Checking: ",
                AccountTypeValidator.ValidateAccountType,
                AccountCreationUI.accountCreationLines
            );

            return accountType;
        }
    }
}