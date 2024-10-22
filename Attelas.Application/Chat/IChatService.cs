namespace Attelas.Application.Chat;

/// <summary>
/// Chat service interface.
/// </summary>
public interface IChatService
{
    ChatResponse Complete(ChatRequest request);
}