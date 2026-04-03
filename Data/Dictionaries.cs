// (Possibly in the future I might added the enum script to the data folder)
// Data Folder

// Dictionaries.cs
// This script is dedicated to contain
// All of the dictionaries in this project
// And to more prcise it's meant to play
// The role of the bridge between the enum
// And the action 

namespace BankManagementSystem
{
    public static class Dictionaries
    {
        public static Dictionary<NoAccountOptions, Action> NoAccountMenuDict = new Dictionary<NoAccountOptions, Action>
        {
            { NoAccountOptions.Exit, () => Environment.Exit(0) },
            { NoAccountOptions.CreateAccount, () => CreateAccount.CreateAccountManager()}
        };

        // Generic dictionary
        public static Dictionary<BankOptions, Action<BankAccount>> BankOptionsDict = new Dictionary<BankOptions, Action<BankAccount>>
        {
            { BankOptions.Exit, bankAccount => Environment.Exit(0) },
            { BankOptions.Deposit, bankAccount => Deposit.DepositManager(bankAccount) },
            { BankOptions.Withdraw, bankAccount => Withdraw.WithdrawManager(bankAccount) }
        };
    }
}