using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Core.Models
{
    public class FinancialRecordCreateViewModel
    {
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; } = null!;

        [Required]
        [Display(Name = "Type")]
        public string Type { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;
    }
}
