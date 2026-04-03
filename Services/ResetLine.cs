// Folder Services

// ResetLine.cs
// This script resets the line of the user's input
// It's mainly used to beautify the UI

namespace BankManagementSystem
{
	public class ResetLine
	{
		public static void LineResetter(int line)
		{
			// So here we're exactly going to delete the prompt in which
			// We've asked the user for an input
			// The only usage of this point is solely for elegance
			
			// We'll need to know the right location of the line to remove
			// And set the cursor right there
			Console.SetCursorPosition(0, line);
			
			// Now we'll crash the letters and replace them by spaces
			Console.Write(new string(' ', Console.WindowWidth));
			
			// The usage of `Console.WindowWidth` is meant to 
			// automate the process of crashing the entire line
			
			// Now we'll go back to the original line and set
			// The cursor there
			Console.SetCursorPosition(0, line);
		}
	}
}