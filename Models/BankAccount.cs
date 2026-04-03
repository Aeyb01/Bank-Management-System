// BankAccount.cs

// The Brain of the user's account

namespace BankManagementSystem
{
    public class BankAccount
    {
        public string FullName { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public string Deposit { get; set; } = string.Empty;


    public static void AccountData()
        {
            // This one is going to hold the user's data
            //UserData 
        }
    }
}