using Attelas.Domain.Core;

namespace Attelas.Application.Client;

/// <summary>
/// Client application service default implementation
/// </summary>
/// <param name="clientRepository"></param>
internal class ClientService(IClientRepository clientRepository) : IClientService
{
    public Domain.Core.Client GetClient(string clientId)
    {
        return clientRepository.GetClient(clientId);
    }
}