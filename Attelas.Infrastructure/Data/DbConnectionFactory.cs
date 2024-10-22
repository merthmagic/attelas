using System.Data;
using Npgsql;

namespace Attelas.Infrastructure.Data;

public abstract class DbConnectionFactory
{
    public static IDbConnection CreateConnection(string connectionString)
    {
        return new NpgsqlConnection(connectionString);
    }
}