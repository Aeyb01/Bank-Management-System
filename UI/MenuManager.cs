// MenuManager.cs

// This is the brain of the menu logic
// It works as the orchestror of the entire
// Menu logic / UI 

namespace BankManagementSystem
{
    public class MenuManager
    {
        public static void DisplayMenu()
        {
            BankAccount bankAccount = GetOrCreateAccount();

            MainMenu.DisplayMain(bankAccount);
            UserInputService.HandleInputWithParam<BankOptions>(
            Dictionaries.BankOptionsDict, bankAccount);
        }


        private static BankAccount GetOrCreateAccount()
        {
            BankAccount? bankAccount = JsonUtility.LoadBankAccount();

            while (bankAccount == null)
            {
                NoAccountMenu.DisplayNoAccountMenu();
                UserInputService.HandleInput<NoAccountOptions>(Dictionaries.NoAccountMenuDict);
                bankAccount = JsonUtility.LoadBankAccount();
            }

            return bankAccount;
        }




        // TODO: Refactoriser avec MenuBase (classe abstraite) quand on aura 3+ menus
        // Idée : créer MenuBase avec Display() + GetLines() abstraite
        // Chaque menu hérite de MenuBase et fournit ses lignes via GetLines()
        // MenuManager n'appellera plus qu'un seul menu.Display() au lieu d'une méthode différente par menu
    }
}