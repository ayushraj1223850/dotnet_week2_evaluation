using System;
using WEAK_EVAL2.Models;
using WEAK_EVAL2.Ledger;

namespace WEAK_EVAL2
{
    class Program
    {
        static void Main()
        {
            // Creating separate ledgers for Income and Expense
            // This ensures type safety and avoids mixing transactions
            Ledger<IncomeTransaction> incomeLedger = new Ledger<IncomeTransaction>();
            Ledger<ExpenseTransaction> expenseLedger = new Ledger<ExpenseTransaction>();

            Console.WriteLine("=== DIGITAL PETTY CASH LEDGER ===\n");

            // ---------------- INCOME INPUT ----------------
            Console.WriteLine("Enter Income Details");

            // Read and validate income amount
            decimal incomeAmount = ReadValidDecimal("Enter income amount: ");

            // Read income source (string validation)
            string incomeSource = ReadNonEmptyString("Enter income source: ");

            // Create and add income transaction to income ledger
            incomeLedger.AddEntry(
                new IncomeTransaction(
                    id: 1,
                    date: DateTime.Today,
                    amount: incomeAmount,
                    description: "Income Entry",
                    source: incomeSource
                )
            );

            // ---------------- EXPENSE INPUT ----------------
            Console.WriteLine("\nEnter Expense Details");

            // Read and validate expense amount
            decimal expenseAmount = ReadValidDecimal("Enter expense amount: ");

            // Read expense category
            string expenseCategory = ReadNonEmptyString("Enter expense category: ");

            // Create and add expense transaction to expense ledger
            expenseLedger.AddEntry(
                new ExpenseTransaction(
                    id: 1,
                    date: DateTime.Today,
                    amount: expenseAmount,
                    description: "Expense Entry",
                    category: expenseCategory
                )
            );

            // ---------------- CALCULATIONS ----------------
            // Ledger controls calculation and internally uses static helper
            decimal totalIncome = incomeLedger.CalculateTotal();
            decimal totalExpense = expenseLedger.CalculateTotal();
            decimal balance = totalIncome - totalExpense;

            // ---------------- OUTPUT ----------------
            Console.WriteLine("\n---- PETTY CASH SUMMARY ----");
            Console.WriteLine($"Total Income  : {totalIncome}");
            Console.WriteLine($"Total Expense : {totalExpense}");
            Console.WriteLine($"Net Balance   : {balance}");

            Console.WriteLine("\n---- TRANSACTION DETAILS ----");

            // Demonstrating polymorphism using base class reference
            foreach (var txn in incomeLedger.GetAllEntries())
            {
                Console.WriteLine(txn.GetSummary());
            }

            foreach (var txn in expenseLedger.GetAllEntries())
            {
                Console.WriteLine(txn.GetSummary());
            }

            Console.WriteLine("\nProgram execution completed successfully.");
        }

        // ---------------- HELPER METHODS ----------------

        // Method to read and validate decimal input
        // Ensures user enters a valid positive number
        static decimal ReadValidDecimal(string message)
        {
            decimal value;
            bool isValid;

            do
            {
                Console.Write(message);
                string input = Console.ReadLine() ?? string.Empty;

                // TryParse avoids runtime exceptions
                isValid = decimal.TryParse(input, out value) && value > 0;

                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter a positive numeric value.");
                }

            } while (!isValid);

            return value;
        }

        // Method to read non-empty string input
        // Prevents empty or whitespace-only values
        static string ReadNonEmptyString(string message)
        {
            string input;

            do
            {
                Console.Write(message);
                input = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                }

            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }
    }
}
