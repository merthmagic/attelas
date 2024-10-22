namespace Attelas.Domain.Core;

public interface IInvoiceRepository
{
    Invoice GetInvoice(string invoiceNumber);
    
    void SaveInvoice(Invoice invoice);
    
    IEnumerable<Invoice> listInvoicesByCompany(string company);
}