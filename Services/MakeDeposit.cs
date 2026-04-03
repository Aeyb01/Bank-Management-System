// Service Sub-Folder

// MakeDeposit.cs

namespace BankManagementSystem
{
   public class MakeDeposit
   {
      public static void GetDeposit(BankAccount bankAccount)
      {
         Console.WriteLine("Getting a deposit");
         Thread.Sleep(2000);

         string deposit = FieldInputService.ProcessField
            (
               "Type the amount in $:",
               "Enter Deposit: ",
               DepositValidator.ValidateDeposit,
               DepositMenu.depositMenuLines
            );

         decimal newDeposit = decimal.Parse(deposit);
         decimal oldDeposit = decimal.Parse(bankAccount.Deposit);

         decimal deposing = newDeposit + oldDeposit;

         Console.WriteLine();
         Console.WriteLine("Deposit has been gotten!");
         Thread.Sleep(2000);

         deposit = deposing.ToString();

         // Now updating the deposit and we save it
         bankAccount.Deposit = deposit;
         SaveData.SaveBankAccount(bankAccount);
      }
   }
}