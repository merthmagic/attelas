namespace Attelas.Domain.Core;

public interface IClientRepository
{
    Client GetClient(string clientId);
    
    void SaveClient(Client client);
}