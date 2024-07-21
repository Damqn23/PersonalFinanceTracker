using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PersonalFinanceTracker.Infrastructure.DataConstants.Constants;


namespace PersonalFinanceTracker.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [MinLength(CategoryNameMinLength)]
        [Comment("Name of the category")]
        public string Name { get; set; } = string.Empty;

        public ICollection<FinancialRecord> FinancialRecords { get; set; } = new List<FinancialRecord>();
    }
}