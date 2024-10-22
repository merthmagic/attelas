namespace Attelas.Application.Invoice;

/// <summary>
/// Invoice application service
/// </summary>
public interface IInvoiceService
{
    /// <summary>
    /// Fetch invoice by invoice number
    /// </summary>
    /// <param name="invoiceNumber"></param>
    /// <returns></returns>
    Domain.Core.Invoice GetInvoice(string invoiceNumber);
}