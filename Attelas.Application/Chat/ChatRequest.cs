namespace Attelas.Application.Chat;

/// <summary>
/// Chat request object
/// </summary>
public class ChatRequest
{
    /// <summary>
    /// Conversation id, used to track the conversation if in a multi-turn conversation
    /// </summary>
    public string? DialogueId { get; set; }
    /// <summary>
    /// User input text
    /// </summary>
    public required string Text { get; set; }
}

