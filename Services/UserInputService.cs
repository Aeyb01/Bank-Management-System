// Service Folder

// UserInputService.cs

// This file is the brain of handling input
// It's the orchestrator of the entire input logic
// AND WHERE TO DIRECT IT EXACTLY

namespace BankManagementSystem
{
    public class UserInputService
    {
        // So here we prompt the user to enter a numeric choice from the menu
        // And because we've passed a dynamic enum to this method
        // We'll be comparing the input option to the enum option
        // And call a dictionary action based on that 
        public static void HandleInput<T>(Dictionary<T, Action> dictionary) where T : Enum
        {
            while (true)
            {
                T selectedEnum;

                Console.Write("Enter your choice: ");
                string input = Console.ReadLine() ?? "";

                try
                {
                    selectedEnum = InputValidator.VerifyInput<T>(input);
                }
                catch (Exception ex) when (ex is FormatException ||
                                ex is ArgumentOutOfRangeException)
                {
                    // We'll colour the Error in order to make it look prettier
                    ConsoleNotifiers.InvalidMessage(ex.Message);
                    continue;
                }

                CommandExecutor.ExecuteCommand(selectedEnum, dictionary);

                break;
            }
        }

        public static void HandleInputWithParam<T>(Dictionary<T, Action<BankAccount>> dictionary, BankAccount bankAccount)
        where T : Enum
        {
            while (true)
            {
                T selectedEnum;

                Console.Write("Enter your choice: ");
                string input = Console.ReadLine() ?? "";

                try
                {
                    selectedEnum = InputValidator.VerifyInput<T>(input);
                }
                catch (Exception ex) when (ex is FormatException ||
                                ex is ArgumentOutOfRangeException)
                {
                    // We'll colour the Error in order to make it look prettier
                    ConsoleNotifiers.InvalidMessage(ex.Message);
                    continue;
                }

                CommandExecutor.ExecuteCommandWithParam<T>(selectedEnum, bankAccount, dictionary);

                break;
            }
        }
    }
}