// UI Folder

// MainMenu.cs

namespace BankManagementSystem
{
    public class MainMenu
    {
        public static void DisplayMain(BankAccount bankAccount)
        {
            Display.ShowMenu(mainMenuLines, bankAccount);
        }

        public static string[] mainMenuLines = new string[]
        {
            "+--------------------------------------------------+",
            "|           WELCOME TO YOUR BANK ACCOUNT           |",
            "+--------------------------------------------------+",
            "|  Account Holder : $Name                          |",
            "|  Account Type   : $AccountType                   |",
            "|  Balance        : $Balance                       |",
            "+--------------------------------------------------+",
            "",
            "   Please choose an option from the menu below:",
            "",
            "   ------------------------------------------------",
         //   "   | (5) Update Account Information                |",
         //   "   | (4) View Transaction History                  |",
        //    "   | (3) Transfer Funds                            |",
            "   | (2) Make a Withdrawal                         |",
            "   | (1) Make a Deposit                            |",
         // "   | (1) Logout                                    |", TODO
            "   | (0) Exit                                      |",
            "   ------------------------------------------------",
            "",
            "+--------------------------------------------------+",
            "|                 [ SELECT OPTION ]                |",
            "+--------------------------------------------------+",
            "",
        };
    }
}