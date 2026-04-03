// Services => Account Creation Sub-Folder => Phone Number Sub-Folder

// PhoneNumber.cs

using System;
using System.Linq;

namespace BankManagementSystem
{
    public static class PhoneNumberValidator
    {
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                ConsoleNotifiers.InvalidMessage("Phone number cannot be empty.");
                return false;
            }

            // Extract digits and non-digit characters
            string digits = new string(phoneNumber.Where(char.IsDigit).ToArray());
            string nonDigits = new string(phoneNumber.Where(c => !char.IsDigit(c)).ToArray());

            // Check if there are digits
            if (string.IsNullOrEmpty(digits))
            {
                ConsoleNotifiers.InvalidMessage("No numbers were given.");
                return false;
            }

            // Validate allowed non-digit characters
            if (!nonDigits.All(c => c == '(' || c == ')' || c == '-' || c == ' ' || c == '+'))
            {
                ConsoleNotifiers.InvalidMessage(
                    "Number can only contain digits, spaces, '()', '-', or '+'."
                );
                return false;
            }

            // Ensure the phone number starts with '+'
            if (!phoneNumber.StartsWith("+"))
            {
                ConsoleNotifiers.InvalidMessage("Number must start with country code '+'.");
                return false;
            }

            // Check digit length
            if (digits.Length < 6 || digits.Length > 15)
            {
                ConsoleNotifiers.InvalidMessage("Phone number must have between 6 and 15 digits.");
                return false;
            }

            for (int i = 0; i < phoneNumber.Length - 1; i++)
            {
                if(
                    phoneNumber[i] == phoneNumber[i+1] &&
                    !char.IsDigit(phoneNumber[i]) &&
                    !char.IsDigit(phoneNumber[i+1]))
                {
                    ConsoleNotifiers.InvalidMessage(
                        "Caracters and spaces cannot be repeated consecutively."
                    );
                    return false;
                }


            }

            return true;
        }
    }
}