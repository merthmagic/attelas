using System.Data;
using Attelas.Domain.Core;
using Dapper;

namespace Attelas.Infrastructure.Data;

internal class ClientRepository(IDbConnection connection) : IClientRepository
{
    public Client GetClient(string clientId)
    {
        return connection.QuerySingleOrDefault<Client>(@"select * from Clients where client_id=@clientId",
            new { clientId });
    }

    public void SaveClient(Client client)
    {
        throw new NotImplementedException();
    }
}