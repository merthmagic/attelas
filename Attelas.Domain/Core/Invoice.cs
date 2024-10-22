namespace Attelas.Domain.Core;

public class Invoice
{
    public string InvoiceNumber { get; set; }

    public string ClientId { get; set; }

    public DateTime DueDate { get; set; }

    public string Status { get; set; }

    public IEnumerable<InvoiceItem> LineItems { get; set; }
}

public class InvoiceItem
{
    public string InvoiceNumber { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}