// Service Folder

// Deposite.cs
// This script is called by a dictionary when the user chooses the first option


namespace BankManagementSystem
{
    public class Deposit
    {
        public static void DepositManager(BankAccount bankAccount)
        {
            ShowDepositMenu(bankAccount);
            MakeDeposit.GetDeposit(bankAccount);

            // Go back to the main menu after we're done with putting the deposit
            MenuManager.DisplayMenu();
        }

        public static void ShowDepositMenu(BankAccount bankAccount)
        {
            // This method is the UI menu handler
            // It's solely responsible about the UI

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Loading Deposit Menu...");
            Thread.Sleep(2000);
            Console.Clear();
            DepositMenu.DisplayDeposit(bankAccount);
        }
    }
}