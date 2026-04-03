// Service Folder

// FieldInputService.cs 

/// <summary>
/// Provides utilities for handling validated user input and updating the console UI,
/// including repeated prompting, validation, and synchronized field display.
/// </summary>
namespace BankManagementSystem
{
    public class FieldInputService
    {
        /// <summary>
        /// Handles the full lifecycle of a field input:
        /// prompts the user until valid input is provided, updates the UI,
        /// and restores the console cursor position.
        /// </summary>
        public static string ProcessField
        (
            string fieldLable,             // What we want to look for in the menu
            string prompt,                // The prompt that we'd display to the user
            Func<string, bool> validator, // The validation function we'll use
            string[] lines                // The menu that we pass and look inside of it
        )

        {
            // So first of all we need to know the bottom line 
            // Why do we need to know it in the first place? 
            // Because we'll be moving the console's cursor
            // Back and forther so we'd need to conserve the
            // bottom line's index for us later when we're resetting
            // the cursor and moving on to a new script
            // aka DataOfBirth.cs in this case

            int bottom = Console.CursorTop;

            
            string label = FieldInputService.PromptUntilValid
            (
                prompt,
                validator 
            );

            UpdateUI(fieldLable, label, lines);
            
            ResetLine.LineResetter(bottom);

            return label;
        }

        /// <summary>
        /// Continuously prompts the user until the provided validator returns true,
        /// ensuring only valid input is accepted before returning the result.
        /// </summary>
        public static string PromptUntilValid(string prompt, Func<string, bool> validator)
        {
            // So in order to create a new account we first
            // Need to knwo the user's name obviously
            // AND in order to align it beautifuly with the output
            // I'll need to keep prompting the user 
            // Over and over for inputs to check them up
            // I'll need to get the line's exact number
            // in order to crash it and make a new one

            while(true)
            {
                int inputRow = Console.CursorTop; // Save the current line of asking for the name
                Console.Write(prompt);
                string readInput = Console.ReadLine() ?? "";
                bool isValid = validator(readInput);
                if(isValid)
                {
                    ResetLine.LineResetter(inputRow);
                    return readInput;
                }
            }

        }

        /// <summary>
        /// Updates the console UI by placing the validated input value
        /// at the correct coordinates corresponding to the specified field label.
        /// </summary>
        public static void UpdateUI(string fieldLable, string label, string[] lines)
        {
            // We take the coordination from the UI menu here
            (int column, int row) = UIFieldCoordinates.GetCoordinates(fieldLable, lines);
            Console.SetCursorPosition(column, row);
            Console.Write(label);
        }
    }
}