using System;

namespace BankingTransactionSystem
{
    // Custom Exception: Invalid Amount
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message) : base(message) { }
    }

    // Custom Exception: Insufficient Balance
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    // BankAccount Class
    public class BankAccount
    {
        public string AccountHolderName { get; set; }
        public double Balance { get; private set; }

        public BankAccount(string name, double initialBalance)
        {
            if (initialBalance < 1000)
                throw new ArgumentException("Initial balance must be at least ₹1000");

            AccountHolderName = name;
            Balance = initialBalance;
        }

        // Deposit Method
        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Deposit amount must be greater than 0");

            Balance += amount;
            Console.WriteLine($"₹{amount} deposited successfully.");
        }

        // Withdraw Method
        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Withdrawal amount must be greater than 0");

            if (amount > Balance)
                throw new InsufficientBalanceException("Withdrawal exceeds available balance");

            if ((Balance - amount) < 1000)
                throw new InsufficientBalanceException("Minimum balance ₹1000 must be maintained");

            Balance -= amount;
            Console.WriteLine($"₹{amount} withdrawn successfully.");
        }

        // Check Balance
        public void CheckBalance()
        {
            Console.WriteLine($"Current Balance: ₹{Balance}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BankAccount account = new BankAccount("Akshay", 5000);

                while (true)
                {
                    Console.WriteLine("\n--- Banking Menu ---");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Check Balance");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter choice: ");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter deposit amount: ");
                            double depositAmount = Convert.ToDouble(Console.ReadLine());
                            account.Deposit(depositAmount);
                            break;

                        case 2:
                            Console.Write("Enter withdrawal amount: ");
                            double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                            account.Withdraw(withdrawAmount);
                            break;

                        case 3:
                            account.CheckBalance();
                            break;

                        case 4:
                            Console.WriteLine("Thank you!");
                            return;

                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine("Invalid Amount Error: " + ex.Message);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Balance Error: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument Error: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Input format is incorrect!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nTransaction completed.");
            }
        }
    }
}

