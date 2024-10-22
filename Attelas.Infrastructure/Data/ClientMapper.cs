using Attelas.Domain.Core;
using Dapper.FluentMap.Mapping;

namespace Attelas.Infrastructure.Data;

public class ClientMapper : EntityMap<Client>
{
    public ClientMapper()
    {
        Map(p => p.ClientId).ToColumn("client_id");
    }
}