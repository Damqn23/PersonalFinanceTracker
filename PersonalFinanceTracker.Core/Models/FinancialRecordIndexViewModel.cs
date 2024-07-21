using PersonalFinanceTracker.Infrastructure.Data.Models;
using System.Collections.Generic;

namespace PersonalFinanceTracker.Core.Models
{
    public class FinancialRecordIndexViewModel
    {
        public List<FinancialRecord> Records { get; set; } = new List<FinancialRecord>();
    }
}
