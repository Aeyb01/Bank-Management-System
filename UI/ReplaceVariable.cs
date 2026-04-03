// UI Sub-Folder

// ReplaceVariable.cs

// This script is meant to replace the needed variable
// For the menu while keeping the UI intact
// It's used by UI scripts


namespace BankManagementSystem
{
    public class ReplaceVariable
    {
        /// <summary>
        /// Replaces a variable and the following spaces (up to the next '|') 
        /// with the value padded or truncated to exactly fill that region.
        /// </summary>
        public static string GetVariable(string line, string variable, string value)
        {
            int startIndex = line.IndexOf(variable);
            if (startIndex == -1) return line;

            // Find the next '|' after the variable
            int endIndex = line.IndexOf('|', startIndex + variable.Length);
            if (endIndex == -1) return line; // Should not happen with valid templates

            // Region length includes the placeholder and all spaces up to the '|'
            int regionLength = endIndex - startIndex;

            // Truncate or pad the value to exactly fit the region
            string adjustedValue = value.Length > regionLength
                ? value.Substring(0, regionLength)
                : value.PadRight(regionLength);

            // Rebuild the line: before region + adjusted value + after region (including the '|')
            return line.Substring(0, startIndex) + adjustedValue + line.Substring(endIndex);
        }
    }
}