// JsonUtility.cs

// This file is meant to be the one saving
// the user's bank account into a json file
// This script will be called by `CreatAccount.cs`

using System.Text.Json;

namespace BankManagementSystem
{
    public class JsonUtility
    {
        // Get the full path directly then retreat 3 times
        // That's happening to avoid the bug of creating the data folder
        // Inside of the bin folder
        // The variable is static and readonly so we wouldn't need to
        // Instantiate it each time we call it nor it should ever be
        // Modified
        public static readonly string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));



        public static void MakeBankAccount(BankAccount bankAccount)
        {
            SaveData.SaveBankAccount(bankAccount);
        }

        public static BankAccount? LoadBankAccount()
        {
            // Get the file path from the specific folder IN APPROPRIATE FORM
            string? filePath = Path.GetFullPath(Path.Combine(projectDirectory, "UserData", "account.json"));

            if(File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                BankAccount? bankAccount = JsonSerializer.Deserialize<BankAccount>(json);
                return bankAccount;
            }

            return null;
        }
    }
}