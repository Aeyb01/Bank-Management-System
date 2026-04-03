// Service Folder

// CommandExecutor.cs
// The file that excutes the user's input


namespace BankManagementSystem
{
    public class CommandExecutor
    {
        public static void ExecuteCommand<T>(T selectedEnum, Dictionary<T, Action> dictionary) where T : Enum
        {
            // Now this method needs to be also dynamic
            // More like modifying the original enum itself
            // And assigning each of its values with a certain
            // Direction. For example if the enum has `Exit`
            // The proram needs to automatically know how to 
            // Exit. I think I'll now need to assign each
            // Component with a certain value/direction

            // Great I've already done it in a dictionary!
            // Now I'll have to implement it


            // Here we try to get the action value that is associated with
            // The selectedEnum IF it exists we'll create a varible named
            // `action` AND we'll invoke it OTHERWISE we'll print out an 
            // Error

            // Important thing to say is: We're passing the enum component
            // To our dictionary script of which it'll automatically find it
            // and excutes the associated action
            if (dictionary.TryGetValue(selectedEnum, out Action? action))
            {
                action.Invoke();
            }
            else
            {
                ConsoleNotifiers.InvalidMessage("Error Action is not defined yet");
            }

        }

            public static void ExecuteCommandWithParam<T>(T selectedEnum, BankAccount bankAccount, Dictionary<T, Action<BankAccount>> dictionary)
            where T : Enum
        {
            if(dictionary.ContainsKey(selectedEnum))
            {
                dictionary[selectedEnum](bankAccount);
            }
            else
            {
                ConsoleNotifiers.InvalidMessage("Error Action is not defined yet");
            }
        }
    }
}