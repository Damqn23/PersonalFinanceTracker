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

        public FinancialRecordService(IRepository<FinancialRecord> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FinancialRecord>> GetAllRecordsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<FinancialRecord> GetRecordByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddRecordAsync(FinancialRecord record)
        {
            await _repository.AddAsync(record);
        }

        public async Task UpdateRecordAsync(FinancialRecord record)
        {
            await _repository.UpdateAsync(record);
        }

        public async Task DeleteRecordAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
