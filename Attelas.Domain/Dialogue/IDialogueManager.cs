namespace Attelas.Domain.Dialogue;

public interface IDialogueManager
{
    Dialogue StartNewConversation();
    
    Dialogue? GetConversation(string? conversationId);
}