using PersonalFinanceTracker.Infrastructure.Data.Models;

namespace PersonalFinanceTracker.Core.Models
{
    public class FinancialRecordDetailsViewModel
    {
        public FinancialRecord Record { get; set; } = new FinancialRecord();
    }
}
