using PersonalFinanceTracker.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Core.Interfaces
{
    public interface IFinancialRecordService
    {
    Task<IEnumerable<FinancialRecord>> GetAllRecordsAsync();
    Task<FinancialRecord> GetRecordByIdAsync(int id);
    Task AddRecordAsync(FinancialRecord record);
    Task UpdateRecordAsync(FinancialRecord record);
    Task DeleteRecordAsync(int id);

    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<IEnumerable<TransactionType>> GetAllTransactionTypesAsync();
    }
}
