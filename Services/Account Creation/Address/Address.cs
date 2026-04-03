// Services => Account Creation Sub-Folder => Address Sub-Folder

// Address.cs

namespace BankManagementSystem
{
    public class Address
    {
        public static string GetAddress()
        {
            string address = FieldInputService.ProcessField
            (
                "| Address: ",
                "Enter Address: ",
                AddressValidator.ValidateAddress,
                AccountCreationUI.accountCreationLines
            );

            return address;
        }
    }
}