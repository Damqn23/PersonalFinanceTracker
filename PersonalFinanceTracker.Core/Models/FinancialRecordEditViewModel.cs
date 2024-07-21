// Model for Edit View
using System.ComponentModel.DataAnnotations;

public class FinancialRecordEditViewModel
{
    public int Id { get; set; }

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

    public string UserId { get; set; } = null!;
}
