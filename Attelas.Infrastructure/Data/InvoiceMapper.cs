using Attelas.Domain.Core;
using Dapper.FluentMap.Mapping;

namespace Attelas.Infrastructure.Data;

public class InvoiceMapper : EntityMap<Invoice>
{
    public InvoiceMapper()
    {
        Map(p => p.ClientId).ToColumn("client_id");
        Map(p => p.InvoiceNumber).ToColumn("invoice_number");
        Map(p => p.DueDate).ToColumn("due_date");
        Map(p => p.LineItems).Ignore();
    }
}

public class InvoiceItemMapper : EntityMap<InvoiceItem>
{
    public InvoiceItemMapper()
    {
        Map(p => p.InvoiceNumber).ToColumn("invoice_number");
    }
}