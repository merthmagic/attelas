using Attelas.Application.Authentication;
using Attelas.Application.Chat;
using Attelas.Application.Client;
using Attelas.Application.Invoice;
using Attelas.Infrastructure;
using Attelas.Infrastructure.OpenAI;
using Microsoft.Extensions.DependencyInjection;

namespace Attelas.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        //word-around
        services.RegisterInfra();

        services.AddSingleton(OpenAiClientFactory.Create());
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IInvoiceService, InvoiceService>();
        services.AddScoped<IChatService, ChatService>();
        return services;
    }
}