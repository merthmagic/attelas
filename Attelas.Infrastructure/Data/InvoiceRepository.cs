using System.Data;
using Attelas.Domain.Core;
using Dapper;

namespace Attelas.Infrastructure.Data;

internal class InvoiceRepository(IDbConnection dbConnection) : IInvoiceRepository
{
    public Invoice GetInvoice(string invoiceNumber)
    {
        var invoice = dbConnection.QuerySingleOrDefault<Invoice>(
            @"select * from invoices where invoice_number=@invoiceNumber",
            new { invoiceNumber });

        if (invoice == null)
            return null;

        var items =
            dbConnection.Query<InvoiceItem>(@"select * from invoice_items where invoice_number=@invoiceNumber",
                new { invoiceNumber });

        invoice.LineItems = items;

        return invoice;
    }

    public void SaveInvoice(Invoice invoice)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Invoice> listInvoicesByCompany(string company)
    {
        return dbConnection.Query<Invoice>(
            @"select x.* from invoices x join clients y on x.client_id=y.client_id where y.name = @company",
            new { company });
    }
}