namespace Attelas.Domain.Dialogue;

public interface IInformationRetriever
{
    string RetrieveInvoice(string invoiceNumber);

    string RetrieveInvoice(IDictionary<string, object> searchCriteria);
}