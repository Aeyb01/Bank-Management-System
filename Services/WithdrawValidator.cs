// Service Sub-Folder

// WithdrawValidator.cs

namespace BankManagementSystem
{
   public class WithdrawValidator
   {
      public static bool ValidateWithdraw(string amount)
      {
         if (!int.TryParse(amount, out int number) || number < 0)
         {
            ConsoleNotifiers.InvalidMessage("Invalid entry amount.");
            return false;
         }
         return true;
      }
   }
}