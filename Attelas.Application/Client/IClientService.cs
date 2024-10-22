namespace Attelas.Application.Client;

/// <summary>
/// Client application service
/// </summary>
public interface IClientService
{
    /// <summary>
    /// Fetch client by client id
    /// </summary>
    /// <param name="clientId"></param>
    /// <returns></returns>
    Domain.Core.Client GetClient(string clientId);
    
}