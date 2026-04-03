// Services => Account Creation Sub-Folder => Address Sub-Folder


// DepositValidator.cs

namespace BankManagementSystem
{
    public class DepositValidator
    {
        public static bool ValidateDeposit(string deposit)
        {
            if (!int.TryParse(deposit, out int number) || number < 0)
            {
                ConsoleNotifiers.InvalidMessage("Invalid entry for deposit.");
                return false;
            }
            return true;
        }
    }
}