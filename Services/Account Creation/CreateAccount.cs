// Service Folder => Account Creation Sub-Folder => Name Sub-Folder

// CreateAccount.cs
// This is the main script of creating an account
// In this bank management system
// It's the brain of the process and the orchesteror


using System.Globalization;

namespace BankManagementSystem
{
    public class CreateAccount
    {
        public static void CreateAccountManager()
        {
            BankAccount bankAccount = new BankAccount();
            
            ShowCreateAccountMenu(false);
            bankAccount = HandleAccountCreationInput();
            ShowCreateAccountMenu(true);

            JsonUtility.MakeBankAccount(bankAccount);
        }   


        public static void ShowCreateAccountMenu(bool isMade)
        {
            // This method is the UI menu handler
            // It's solely responsible about the UI

            if(isMade)
            {
                Creating();
                return;
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Loading Creating Account Handler...");
            Thread.Sleep(2000);
            Console.Clear();
            AccountCreationUI.DisplayAccountCreationForm();
        }


        public static BankAccount HandleAccountCreationInput()
        {
            BankAccount bankAccount = new BankAccount();

            bankAccount.FullName = Name.NameHandler();
            bankAccount.BirthDate = DateOfBirth.DateOfBirthHandler();
            bankAccount.EmailAddress = EmailAddress.Email();
            bankAccount.PhoneNumber = PhoneNumber.Phone();
            bankAccount.Address = Address.GetAddress();
            bankAccount.AccountType = AccountType.GetAccountType();
            bankAccount.Deposit = InitialDeposit.GetInitialDeposit();

            return bankAccount;
        }

        static void Creating()
        {
            ConsoleKey key;
            
            do
            {
                Console.WriteLine("Press Enter To Make An Account");
            
                key = Console.ReadKey().Key;    

                if(key == ConsoleKey.Enter)
                {
                    Console.WriteLine("Creating an account...");
                    Thread.Sleep(2000);
                    ConsoleNotifiers.Sucess("Account made!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                }

                ConsoleNotifiers.InvalidMessage("Invalid pressed key.");
            
            } while(key != ConsoleKey.Enter);
        }
    }
}
