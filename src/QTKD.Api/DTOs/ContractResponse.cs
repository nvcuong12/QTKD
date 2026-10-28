namespace QtkdApi.DTOs;

public class ContractResponse
{
    public int Id { get; set; }

    public string ContractNo { get; set; } = string.Empty;

    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Status { get; set; } = string.Empty;
}