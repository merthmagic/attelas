using System.Text.Json;
using Attelas.Domain.Core;
using Attelas.Domain.Dialogue;

namespace Attelas.Infrastructure.NLG;

public class InformationRetriever(IClientRepository clientRepository, IInvoiceRepository invoiceRepository)
    : IInformationRetriever
{
    public string RetrieveInvoice(string invoiceNumber)
    {
        var invoice = invoiceRepository.GetInvoice(invoiceNumber);
        if (invoice == null)
            return $"System contains no invoice with number {invoiceNumber}.";
        else
        {
            return $"System contains invoices information :{JsonSerializer.Serialize(invoice)}";
        }
    }

    public string RetrieveInvoice(IDictionary<string, object> searchCriteria)
    {
        //search criteria can be invoice number, client name, and they have different priorities.
        //if invoice number is provided, it should be used to search for the invoice.
        if (searchCriteria.ContainsKey("Number"))
        {
            var number = searchCriteria["Number"].ToString();
            return RetrieveInvoice((string)number);
        }
        else if (searchCriteria.ContainsKey("Company"))
        {
            var company = searchCriteria["Company"].ToString();
            var invoices = invoiceRepository.listInvoicesByCompany((string)company);
            return $"System contains invoices information :{JsonSerializer.Serialize(invoices)}";
        }
        else
        {
            return $"System contains no invoice with search criteria {JsonSerializer.Serialize(searchCriteria)}";
        }
    }
}