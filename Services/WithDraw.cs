// Service Sub-Folder

// Withdraw.cs

namespace BankManagementSystem
{
   public class Withdraw
   {
      public static void WithdrawManager(BankAccount bankAccount)
      {
         ShowWithdrawtMenu(bankAccount);
         MakeWithdraw.GetWithdraw(bankAccount);
         MenuManager.DisplayMenu();
      }


      public static void ShowWithdrawtMenu(BankAccount bankAccount)
      {
         // This method is the UI menu handler
         // It's solely responsible about the UI

         Console.WriteLine();
         Console.WriteLine();
         Console.WriteLine("Loading Withdraw Menu...");
         Thread.Sleep(2000);
         Console.Clear();
         WithdrawMenu.DisplayWithdraw(bankAccount);
      }
   }
}