// Services => Account Creation Sub-Folder => Account Type Sub-Folder

// AccountTypeValidator.cs

namespace BankManagementSystem
{
    public class AccountTypeValidator
    {
        public static bool ValidateAccountType(string accountType)
        {
            accountType = accountType.ToLower().Trim();
            
            if(accountType != "savings" && accountType != "checking")
            {
                ConsoleNotifiers.InvalidMessage
                (
                    "Invalid Account Type."
                );
                return false;
            }
            return true;
        }
    }
}