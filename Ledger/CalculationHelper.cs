using System.Collections.Generic;
using WEAK_EVAL2.Models;

namespace WEAK_EVAL2.Ledger
{
    // Static helper class for ledger calculations
    internal static class LedgerCalculator
    {
        internal static decimal CalculateTotal<T>(List<T> entries) where T : Transaction
        {
            decimal total = 0;

            foreach (var entry in entries)
            {
                total += entry.Amount;
            }

            return total;
        }
    }
}
