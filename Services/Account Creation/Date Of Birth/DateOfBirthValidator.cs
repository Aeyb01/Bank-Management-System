// Service Folder => Account Creation Sub-Folder => Date Of Birth Sub-Folder

// DateOfBirthValidator.cs

using System.Globalization;

namespace BankManagementSystem
{
    public class DateOfBirthValidator
    {
        public static bool ValidateDateOfBirth(string birthDate)
        {
            int currentYear =   DateTime.Now.Year;
            
            // We need to refine the user's input first
            birthDate = birthDate.Trim();

            // We need to be cautious we don't know what sort of input the user
            // Has given, thus we'll TRY to parse it and if it fails
            // We'll return false
            DateTime date;
            if (
                !DateTime.TryParseExact(birthDate, 
                "yyyy/MM/dd", 
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, 
                out date
                ))
            {
                PrintError();
                return false;
            }

            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (year < 1920 || year > currentYear)
            {
                ConsoleNotifiers.InvalidMessage("Invalid year of birth.");
                return false;
            }
            
            if (date > DateTime.Today)
            {
                ConsoleNotifiers.InvalidMessage("Birth date cannot be in the future.");
                return false;
            }

            // Age Limit
            int verifyAge = AgeVerification(year);

            if (verifyAge < 13)
            {
                ConsoleNotifiers.InvalidMessage("User must be older than 13");
                return false;
            }


            return true;
        }


        static void PrintError() => ConsoleNotifiers.InvalidMessage("Error: The given birthday must be in the format of YYYY/MM/DD");


        static int AgeVerification(int birthYear)
        {
            int year = DateTime.Now.Year;

            int years = year - birthYear;

            return years;
        }
    }

}