// Service Folder => Account Creation Sub-Folder => Name Sub-Folder

// Name.cs

using System.Diagnostics;
using System.Text;

namespace BankManagementSystem
{
    public class Name
    {
        public static string NameHandler()
        {
            int bottom = Console.CursorTop;   

            string firstName = FieldInputService.PromptUntilValid
            (
                "Enter First Name: ",
                VerifyName.NameVerifier
            );
            
            // Now we take the lastName Here
            string lastName = FieldInputService.PromptUntilValid
            (
                "Enter Last Name: ",
                VerifyName.NameVerifier
            );
            

            string fullName = PolishName(firstName, lastName);

            //Now we'll update the output and reset the cursor

            FieldInputService.UpdateUI("Full Name: ", fullName, AccountCreationUI.accountCreationLines);

            ResetLine.LineResetter(bottom);

            return fullName;
        }
		


        static string PolishName(string firstName, string lastName)
        {
            // Here applying some basic polish to the full name
            
            string fullName = firstName + " " + lastName;
            
            // Remove name spaces
            fullName = fullName.Trim();

            // Normalise the name so it's easier to track
            fullName = fullName.Normalize(NormalizationForm.FormC);

            return fullName;
        }
    }
}