// Service Sub-Folder

// MakeWithdraw.cs

namespace BankManagementSystem
{
   public class MakeWithdraw
   {
      public static void GetWithdraw(BankAccount bankAccount)
      {
         Console.WriteLine("Getting Amount...");
         Thread.Sleep(2000);

         while (true)
         {
            string withdrawAmount = FieldInputService.ProcessField
               (
                  "Type the amount in $:",
                  "Enter Desired Amount To Withdraw: ",
                  WithdrawValidator.ValidateWithdraw,
                  WithdrawMenu.withdrawMenuLines
               );

            decimal amount = decimal.Parse(withdrawAmount);
            decimal deposit = decimal.Parse(bankAccount.Deposit);

            if (amount > deposit) 
            {
               ConsoleNotifiers.InvalidMessage(
                           "Cannot withdraw more than what you have in your deposit."
                           ); 
               continue;
            }

            decimal withdrawing = deposit - amount;

            Console.WriteLine();
            Console.WriteLine("Withdraw has been gotten!");
            Thread.Sleep(2000);

            withdrawAmount = withdrawing.ToString();

            // Now updating the Withdraw and we save it
            bankAccount.Deposit = withdrawAmount;
            SaveData.SaveBankAccount(bankAccount);
            break;
         }
      }
   }
}