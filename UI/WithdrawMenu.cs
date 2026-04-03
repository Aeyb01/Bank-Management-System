// UI Sub-Folder

// WithdrawMenu.cs

namespace BankManagementSystem
{
   public class WithdrawMenu
   {
      public static void DisplayWithdraw(BankAccount bankAccount)
      {
         Display.ShowMenu(withdrawMenuLines, bankAccount);
      }

      public static string[] withdrawMenuLines = new string[]
      {
         "+--------------------------------------------------+",
         "|               MAKE A WITHDRAWAL                 |",
         "+--------------------------------------------------+",
         "|  Account Holder : $Name                          |",
         "|  Account Type   : $AccountType                   |",
         "|  Current Balance: $Balance                       |",
         "+--------------------------------------------------+",
         "",
         "   Enter the amount you wish to withdraw:",
         "",
         "   ------------------------------------------------",
         "   |  Type the amount in $:                        |",
         "   ------------------------------------------------",
         "",
         "+--------------------------------------------------+",
         "|                 [ ENTER AMOUNT ]                 |",
         "+--------------------------------------------------+",
         "",
      };
   }
}
