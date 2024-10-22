using System.Data;
using Attelas.Domain.Core;
using Attelas.Domain.Dialogue;
using Attelas.Domain.NLG;
using Attelas.Domain.NLU;
using Attelas.Infrastructure.Data;
using Attelas.Infrastructure.Dialogue;
using Attelas.Infrastructure.NLG;
using Attelas.Infrastructure.NLU;
using Dapper.FluentMap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Attelas.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterInfra(this IServiceCollection services)
    {
        RegisterConnection(services);

        //initialize dapper fluent mapper
        FluentMapper.Initialize(c =>
        {
            c.AddMap(new ClientMapper());
            c.AddMap(new InvoiceMapper());
            c.AddMap(new InvoiceItemMapper());
        });

        services.AddSingleton<IIntentClassifier, IntentClassifier>();
        //register repositories
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<IDialogueManager, InMemoryDialogueManager>();
        services.AddScoped<IResponseGenerator, ResponseGenerator>();
        services.AddScoped<IInformationRetriever, InformationRetriever>();
        return services;
    }

    private static void RegisterConnection(IServiceCollection services)
    {
        services.AddScoped<IDbConnection>(sp =>
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            return DbConnectionFactory.CreateConnection(connectionString);
        });
    }
}