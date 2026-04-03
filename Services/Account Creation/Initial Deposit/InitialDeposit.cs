// Services => Account Creation Sub-Folder => Address Sub-Folder


// InitialDeposit.cs

namespace BankManagementSystem
{
    public class InitialDeposit
    {
        public static string GetInitialDeposit()
        {
            string initialDeposit = FieldInputService.ProcessField
            (
                "Initial Deposit: ",
                "Enter Initial Deposit ",
                DepositValidator.ValidateDeposit,
                AccountCreationUI.accountCreationLines
            );

            return initialDeposit;
        }
    }
}