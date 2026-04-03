
namespace BankManagementSystem
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");

            MenuManager.DisplayMenu();
        }
    }
}

// TODO: Rethink whether throwing errors in the `UserInputService.cs`
// And in `CommandExcutor.cs` were good ideas or not instead
// Of simply printing out red erros 

// TODO go back to the function public static string 
//DisplayVariable(string lineTemplate, string variable, string value) in 
//MainMenu Script
// TODO add a way to prevent badly placed caracters in phonenumber verifier
// TODO: Étape 6 - Séparer Thread.Sleep() de l'affichage dans ShowCreateAccountMenu()
// Thread.Sleep est une logique de timing indépendante de l'UI