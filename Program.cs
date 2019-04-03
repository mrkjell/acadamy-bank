using System;

namespace bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You are about to create a bank account");
            var person = GetPersonInformation();
            var account = OpenBankAccount(person);
            var userInput = -1;

            while(userInput != 0) {
                userInput = DisplayMenu();
                switch(userInput)
                {
                    case 1: 
                        TryMakeDeposit(account);
                        break;
                    case 2: 
                        TryMakeWithdrawal(account);
                        break;
                    case 3:
                        Console.WriteLine(account.GetAccountHistory());
                        break;
                }
            }
        }

        private static int DisplayMenu() 
        {
            Console.WriteLine("");
            Console.WriteLine("Menu");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Witdraw");
            Console.WriteLine("3. Account history");
            Console.WriteLine("0. Exit");
            Console.WriteLine("");
            var result = Console.ReadLine();

            // Implemented crash 
            return Convert.ToInt32(result);
        }

        private static void TryMakeDeposit(BankAccount account) {
            Console.WriteLine("You can't deposit any money at this time, please try again later");
        }

        public static void TryMakeWithdrawal(BankAccount account){
            try {
                Console.WriteLine("How much do you want to withdraw");
                var withdrawalAmount = 0;
                var withdrawalAmountInput = Console.ReadLine();
                var success = Int32.TryParse(withdrawalAmountInput, out withdrawalAmount);

                if(!success)
                {
                    Console.WriteLine($"Cold not insert {withdrawalAmountInput}, please try again later");
                    return;
                }

                Console.WriteLine("Add withdrawal note");
                var note = Console.ReadLine();

                account.MakeWithdrawal(withdrawalAmount, DateTime.Now, note);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("");
                Console.WriteLine("You can't withdraw more money than you have");
            }
        }
        

        private static Person GetPersonInformation()
        {
            var person = new Person();

            Console.WriteLine("First name: ");
            person.FirstName = Console.ReadLine();

            Console.WriteLine("Last name: ");
            person.LastName = Console.ReadLine();

            Console.WriteLine("Social security number: ");
            person.SocialSecurityNumber = Console.ReadLine();

            Console.WriteLine("Phone number: ");
            person.PhoneNumber = Console.ReadLine();

            Console.Clear();

            return person;
        }

        private static BankAccount OpenBankAccount(Person person){
            Console.WriteLine($"Hi {person.Fullname}, Do you want to add some initial balance to the account?");
            
            var initialBalance = 0;
            var balanceInput = Console.ReadLine();
            var success = Int32.TryParse(balanceInput, out initialBalance);

            if(!success)
                Console.WriteLine($"Cold not insert {balanceInput} to account, please try again when creation is complete");

            return new BankAccount(person, initialBalance);
        }
    }
}
