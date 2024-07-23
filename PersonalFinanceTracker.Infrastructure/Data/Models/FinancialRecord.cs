using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PersonalFinanceTracker.Infrastructure.DataConstants.Constants;

namespace PersonalFinanceTracker.Infrastructure.Data.Models
{
    public class FinancialRecord
    {
        [Key]
        [Comment("Financial record identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionMinLength)]
        [Comment("Description of the transaction")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(MinimumAmount, MaximumAmount,
               ErrorMessage = "Amount must be between 0 and 1,000,000.")]
        [Comment("Amount of the transaction")]
        public decimal Amount { get; set; }

        [Required]
        [Comment("Date of the transaction")]
        public DateTime Date { get; set; }

        [Required]
        [Comment("Category identifier")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;

        [Required]
        [Comment("Transaction type identifier")]
        public int? TransactionTypeId { get; set; }

        [ForeignKey("TransactionTypeId")]
        public TransactionType TransactionType { get; set; } = null!;

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;
    }
}