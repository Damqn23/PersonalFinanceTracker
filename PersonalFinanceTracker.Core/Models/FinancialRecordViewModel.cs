using Microsoft.AspNetCore.Mvc.Rendering;
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
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        [Required]
        public int TransactionTypeId { get; set; }
        public IEnumerable<SelectListItem> TransactionTypes { get; set; }
    }

}
