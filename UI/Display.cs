// Display.cs

namespace BankManagementSystem
{
   public class Display
   {
      public static void ShowMenu(string[] lines, BankAccount bankAccount)
      {
         Console.Clear();

         foreach (string line in lines)
         {
            string processedLine = line;

            // Process each variable if present (one per line)
            if (line.Contains("$Name"))
            {
               processedLine = ReplaceVariable.GetVariable(line, "$Name", bankAccount.FullName);
            }
            else if (line.Contains("$AccountType"))
            {
               processedLine = ReplaceVariable.GetVariable(line, "$AccountType", bankAccount.AccountType);
            }
            else if (line.Contains("$Balance"))
            {
               processedLine = ReplaceVariable.GetVariable(line, "$Balance", bankAccount.Deposit + "$");
            }

            Console.WriteLine(processedLine);
         }
      }
   }
}