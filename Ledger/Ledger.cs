using System.Collections.Generic;
using WEAK_EVAL2.Models;

namespace WEAK_EVAL2.Ledger
{
    // Generic ledger that owns data and workflow
    public class Ledger<T> where T : Transaction
    {
        // Internal storage
        private readonly List<T> _entries = new List<T>();

        // Add entry to ledger
        public void AddEntry(T entry)
        {
            _entries.Add(entry);
        }

        // Ledger controls calculation but delegates math
        public decimal CalculateTotal()
        {
            return LedgerCalculator.CalculateTotal(_entries);
        }

        // Used for reporting
        public List<T> GetAllEntries()
        {
            return _entries;
        }
    }
}
