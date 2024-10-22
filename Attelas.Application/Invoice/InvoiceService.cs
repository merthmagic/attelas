using Attelas.Domain.Core;

namespace Attelas.Application.Invoice;

/// <summary>
/// Invoice application service default implementation
/// </summary>
/// <param name="invoiceRepository"></param>
internal class InvoiceService(IInvoiceRepository invoiceRepository) : IInvoiceService
{
    public Domain.Core.Invoice GetInvoice(string invoiceNumber)
    {
        return invoiceRepository.GetInvoice(invoiceNumber);
    }
}