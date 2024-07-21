using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PersonalFinanceTracker.Infrastructure.DataConstants.Constants;

namespace PersonalFinanceTracker.Infrastructure.Data.Models
{
    public class TransactionType
    {
        [Key]
        [Comment("The unique identifier of the transaction type")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TransactionNameMaxLength)]
        [MinLength(TransactionNameMinLength)]
        [Comment("The name of the transaction type")]
        public string Name { get; set; } = string.Empty;

        public ICollection<FinancialRecord> FinancialRecords { get; set; } = new List<FinancialRecord>();
    }
}