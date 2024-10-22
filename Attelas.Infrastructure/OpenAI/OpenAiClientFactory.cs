using OpenAI.Chat;

namespace Attelas.Infrastructure.OpenAI;

public abstract class OpenAiClientFactory
{
    public static ChatClient Create()
    {
        var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
                     ?? throw new InvalidOperationException("OpenAI API key not set");
        return new ChatClient("gpt-3.5-turbo", apiKey);
    }
}