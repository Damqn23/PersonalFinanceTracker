// Model for Delete View
public class FinancialRecordDeleteViewModel
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string UserId { get; set; } = null!;
}
