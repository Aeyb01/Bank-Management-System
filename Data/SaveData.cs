// SaveData.cs

using System.Text.Json;
using System.IO;

namespace BankManagementSystem
{
    public class SaveData
    {
        public static void SaveBankAccount(BankAccount bankAccount)
        {
            string folderPath = CreateFolder();
            //string customID = GetUniqueID(); TODO LATER AFTER THE PROGRAM WORKS
            CreateJsonFile(bankAccount, folderPath);
        }
    
        static string CreateFolder()
        {
            // So fist of all and before we do anything
            // We'll have to define a folder that'll be the 
            // Container of the saved json files

            // Now we create the correct path for where to create
            // The UserData folder
            string folderPath = Path.Combine(JsonUtility.projectDirectory, "UserData");
    
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); // Now create the folder if it doesn't exist
            }
    
            return folderPath;
        }
    
        static void CreateJsonFile(BankAccount bankAccount, string folderPath)
        {
            // Now after we've created the folder we need to
            // Create the json file
            
            // Serialize the data
            string json = JsonSerializer.Serialize(bankAccount);
            
            // Give a unique name to the json file
            string fileName = "account.json";
    
            // Get the sub-folder path + the json file name
            string filePath = Path.Combine(folderPath, fileName);
            
            // Now create the json file in the correct path
            File.WriteAllText(filePath, json);
        }
/*
        static string GetUniqueID()
        {
            long timestamp = DateTime.UtcNow.Ticks;
            Guid randomPart = Guid.NewGuid();
            string customID = $"{timestamp}-{randomPart}";
            return customID;
        }
*/
    }
}