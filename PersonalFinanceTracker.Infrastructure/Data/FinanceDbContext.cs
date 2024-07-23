using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Infrastructure.Data.Models;
using System.Reflection.Emit;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food" },
                new Category { Id = 2, Name = "Transport" },
                new Category { Id = 3, Name = "Entertainment" }
            );

            // Seed transaction types
            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType { Id = 1, Name = "Income" },
                new TransactionType { Id = 2, Name = "Expense" }
            );

            // Seed an initial user (optional)
            var hasher = new PasswordHasher<ApplicationUser>();
            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "user@example.com",
                NormalizedUserName = "USER@EXAMPLE.COM",
                Email = "user@example.com",
                NormalizedEmail = "USER@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password123!"),
                SecurityStamp = string.Empty
            };
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            // Seed financial records
            modelBuilder.Entity<FinancialRecord>().HasData(
                new FinancialRecord
                {
                    Id = 1,
                    Description = "Grocery Shopping",
                    Amount = 50.75m,
                    Date = DateTime.Now,
                    CategoryId = 1,
                    TransactionTypeId = 2,
                    UserId = "1"
                },
                new FinancialRecord
                {
                    Id = 2,
                    Description = "Salary",
                    Amount = 1500.00m,
                    Date = DateTime.Now,
                    CategoryId = 2,
                    TransactionTypeId = 1,
                    UserId = "1"
                }
            );

        }
    }
}
