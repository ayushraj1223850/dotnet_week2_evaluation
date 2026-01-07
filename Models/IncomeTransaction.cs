using System;

namespace WEAK_EVAL2.Models
{   /*
     * IncomeTransaction represents money coming into
     * the petty cash system.
     * 
     * It inherits from Transaction and adds
     * income-specific information.
     */
    public class IncomeTransaction : Transaction
    {
         // Indicates where the income came froms
        public string Source { get; set; }
         /*
         * Constructor initializes both base class
         * properties and income-specific data.
         */
        public IncomeTransaction(
            int id,
            DateTime date,
            decimal amount,
            string description,
            string source)
            : base(id, date, amount, description)
        {
            Source = source;
        }

        /* Provides a formatted summary for income transactions.*/
        public override string GetSummary()
        {
            return $"[INCOME] {Date.ToShortDateString()} | Amount: {Amount} | Source: {Source}";
        }
    }
}
