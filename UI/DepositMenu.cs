// DepositMenu.cs

namespace BankManagementSystem
{
    public class DepositMenu
    {
        public static void DisplayDeposit(BankAccount bankAccount)
        {
           Display.ShowMenu(depositMenuLines, bankAccount);
        }

        public static string[] depositMenuLines = new string[]
        {
            "+--------------------------------------------------+",
            "|                MAKE A DEPOSIT                    |",
            "+--------------------------------------------------+",
            "|  Account Holder : $Name                          |",
            "|  Account Type   : $AccountType                   |",
            "|  Current Balance: $Balance                       |",
            "+--------------------------------------------------+",
            "",
            "   Enter the amount you wish to deposit:",
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