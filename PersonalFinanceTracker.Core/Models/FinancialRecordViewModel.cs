using PersonalFinanceTracker.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Core.Models
{
    public class FinancialRecordViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [Range(0, 1000000)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        
        public int CategoryId { get; set; }

        
        public int TransactionTypeId { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<TransactionType> TransactionTypes { get; set; }
    }
}
