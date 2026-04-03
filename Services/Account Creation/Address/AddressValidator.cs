// Services => Account Creation Sub-Folder => Address Sub-Folder

// AddressValidator.cs

using System.Linq;

namespace BankManagementSystem
{
    public class AddressValidator
    {
        public static bool ValidateAddress(string address)
        {
            if (address.Length < 5 || address.Length > 25)
            {
                ConsoleNotifiers.InvalidMessage(
                    "Address length must be between 5 and 25 caracters."
                );
                return false;
            }

            if (address.Contains(' ') && !address.Split(' ').Any(word =>  word.Length >= 3))
            {
                ConsoleNotifiers.InvalidMessage(
                    "Adress must be having at least one three letters word."
                );
                return false;
            }

            return true;
        }
    }
}