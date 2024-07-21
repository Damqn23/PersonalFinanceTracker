using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static PersonalFinanceTracker.Infrastructure.DataConstants.Constants;

namespace PersonalFinanceTracker.Infrastructure.Data.Models
{
    public class Budget
    {
        [Key]
        [Comment("Budget Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        [Comment("A descriptive name for the budget (e.g., \"Monthly Rent\").")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(MinimumAmount, MaximumAmount,
               ErrorMessage = "Amount must be between 0 and 1,000,000.")]
        [Comment("The total amount allocated for this budget.")]
        public decimal Amount { get; set; }

        [Required]
        [Comment("Define the period during which the budget is active.")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("Define the period during which the budget is active.")]
        public DateTime EndDate { get; set; }
        [Required]
        [Comment("Links the budget to a specific user.")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;

        public ICollection<FinancialRecord> FinancialRecords { get; set; } = new List<FinancialRecord>();
    }
}