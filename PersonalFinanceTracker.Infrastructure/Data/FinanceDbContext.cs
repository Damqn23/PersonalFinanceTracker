using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Infrastructure.Data.Models;

namespace PersonalFinanceTracker.Infrastructure.Data
{
    public class FinanceDbContext : IdentityDbContext<ApplicationUser>
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
            : base(options)
        {
        }
        public DbSet<FinancialRecord> FinancialRecords { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
    }
}
