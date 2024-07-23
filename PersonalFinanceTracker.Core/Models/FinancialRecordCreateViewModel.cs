using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker.Core.Models
{
    public class FinancialRecordCreateViewModel
    {
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();

        public int TransactionTypeId { get; set; }
        public IEnumerable<SelectListItem> TransactionTypes { get; set; } = new List<SelectListItem>();
    }
}
