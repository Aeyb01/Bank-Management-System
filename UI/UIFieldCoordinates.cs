// UI Folder

// UIFieldCoordinates.cs
// This script is used to modify the menu's UI
// according to what user's enter

namespace BankManagementSystem
{
    public class UIFieldCoordinates
    {
        public static (int column, int row) GetCoordinates(string word, string[] lines)
        {
            // Search each line in the menu for the given field label
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(word))
                {
                    // Find the position of ':' to determine column start for user input.
                    int column = lines[i].IndexOf(":");
            
                    if (column == -1)
                    {
                        // We expect every field label to have a ':'.
                        throw new InvalidOperationException($"The field '{word}' does not contain ':'");
                    }

                    // Offset by 5 to align with the input area.
                    column += 5;

                    // Return coordinates as (column, row)
                    return (column, i);
                }
            }
            
            // The label wasn't found; this should not happen if the UI is correctly set up.
            throw new InvalidOperationException($"The field '{word}' wasn't found in the UI.");
            
        }
    }
}