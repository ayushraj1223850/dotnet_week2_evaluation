using System;
using WEAK_EVAL2.Interfaces;

namespace WEAK_EVAL2.Models
{
    // Base abstract class for all transactions
    public abstract class Transaction : IReportable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        /*
         * Protected constructor ensures that only
         * derived classes can initialize a transaction.
         */
        protected Transaction(int id, DateTime date, decimal amount, string description)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Description = description;
        }

        // Must be implemented by derived classes
        public abstract string GetSummary();
    }
}
