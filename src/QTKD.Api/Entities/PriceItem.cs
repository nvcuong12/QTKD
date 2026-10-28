namespace QtkdApi.Entities;

public class PriceItem
{
    public int Id { get; set; }

    public int PriceListId { get; set; }

    public PriceList PriceList { get; set; } = null!;

    public string ServiceCode { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }
}