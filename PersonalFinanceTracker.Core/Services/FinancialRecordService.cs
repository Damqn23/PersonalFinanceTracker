using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Core.Interfaces;
using PersonalFinanceTracker.Infrastructure.Data;
using PersonalFinanceTracker.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Core.Services
{
    public class FinancialRecordService : IFinancialRecordService
    {
        private readonly IRepository<FinancialRecord> _repository;
        private readonly FinanceDbContext _context;

        public FinancialRecordService(IRepository<FinancialRecord> repository, FinanceDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IEnumerable<FinancialRecord>> GetAllRecordsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<FinancialRecord> GetRecordByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        

        public async Task UpdateRecordAsync(FinancialRecord record)
        {
            await _repository.UpdateAsync(record);
        }

        public async Task DeleteRecordAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task AddRecordAsync(FinancialRecord record)
        {
            _context.FinancialRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<TransactionType>> GetAllTransactionTypesAsync()
        {
            return await _context.TransactionTypes.ToListAsync();
        }
    }
}
