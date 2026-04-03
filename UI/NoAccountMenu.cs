// UI Folder
// NoAccountMenu.cs

namespace BankManagementSystem
{
    public class NoAccountMenu
    {
        public static void DisplayNoAccountMenu()
        {
            Console.Clear();
            
            foreach (string line in noAccountMenuLines)
            {
                Console.WriteLine(line);
            }

        }

        public static string[] noAccountMenuLines  = new string[]
        {
            "+--------------------------------------------------+",
            "|                                                  |",
            "|              BANK MANAGEMENT SYSTEM              |",
            "|                                                  |",
            "+--------------------------------------------------+",
            "",
            "   Welcome!",
            "",
            "   It looks like no accounts are currently",
            "   registered in the system.",
            "",
            "   --------------------------------------------",
            "   Available options:",
            "   --------------------------------------------",
            "",
            "   +------------------------------------------+",
            "   |  1) Make a new account                   |",
            "   |  0) Exit                                 |",
            "   +------------------------------------------+",
            "",
            "   --------------------------------------------",
            "   Tip: You must create an account to start.",
            "",
        };
    }
}