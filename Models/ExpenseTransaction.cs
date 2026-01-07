using System;

namespace WEAK_EVAL2.Models
{
    /*
     * ExpenseTransaction represents money spent
     * from the petty cash system.
     * 
     * It extends Transaction and adds
     * expense-specific classification.
     */
    public class ExpenseTransaction : Transaction
    {
        public string Category { get; set; }

        /*
         * Constructor initializes base transaction data
         * along with expense category.
         */
        public ExpenseTransaction(
            int id,
            DateTime date,
            decimal amount,
            string description,
            string category)
            : base(id, date, amount, description)
        {
            Category = category;
        }
         /*
         * Provides a formatted summary for expense transactions.
         */
        public override string GetSummary()
        {
            return $"[EXPENSE] {Date.ToShortDateString()} | Amount: {Amount} | Category: {Category}";
        }
    }
}
