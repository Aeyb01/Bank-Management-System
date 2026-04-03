// Service Folder

// InputValidator.cs
// This script is dedicated to solely verify
// The user's input and prints it out


namespace BankManagementSystem
{
    public class InputValidator
    {
        // This method needs to be generic in order to be dynamic
        // The usage of the `where T : Enum` specifies that
        // The type of T is specifically an enum
        public static T VerifyInput<T>(string input) where T : Enum
        {
            // So here we'll figure out how many members in the enum 
            // Are there relatively to the user's input
            //  and based on that we'll return an enum that 
            // Corresponds with that number, else we'll throw an error

            // So first we'll need to figure out how many components 
            // are there in the enum
            
            int length = Enum.GetValues(typeof(T)).Length;

            // Now let's actually parse the user's input and say whether it
            // Corresponds to the amount of options that were given
            int Number;

            if (!int.TryParse(input, out Number))
            {
                throw new FormatException("Error: The user's input isn't a valid number.");
            }
            else if (Number < 0 || Number >= length)
            {
                throw new ArgumentOutOfRangeException("Error: Index out of range.");
            }

            // Now the problem is that our code switch statement needs
            // To be dynamic to work accordingly to  each enum
            // The question is how???
            // I guess I'll have to abandon the usage of switch statement
            // And replace it with a For loop that returns the first
            // Element in that enum
            // Never really mind even a for loop doesn't work for that
            // I guess I'll have to learn a new syntax for that one
            
            // Found it!!! I'll have to get the values out of the enum
            // First and store them into an Array!
            // Then return the exact value that corresponds to the
            // Given number!
            T[] Values = (T[])Enum.GetValues(typeof(T));
            // Now return the corresponding enum!
            T selected = Values[Number];

            return selected;
        }
    }
}