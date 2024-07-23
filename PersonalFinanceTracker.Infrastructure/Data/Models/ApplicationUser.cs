using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [PersonalData]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 50 characters")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [PersonalData]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 50 characters")]
        public string LastName { get; set; } = string.Empty;
        public ICollection<FinancialRecord> FinancialRecords { get; set; } = new List<FinancialRecord>();

        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }
}
