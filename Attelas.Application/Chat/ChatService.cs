using Attelas.Domain.Dialogue;

namespace Attelas.Application.Chat;

/// <summary>
/// Chat service default implementation.
/// Since it is a simple demo, 1-turn conversation is supported.
/// 
/// </summary>
public class ChatService(IDialogueManager dialogueManager)
    : IChatService
{
    public ChatResponse Complete(ChatRequest request)
    {
        var conversationId = request.DialogueId;

        var dialogue = dialogueManager.GetConversation(conversationId) ??
                       dialogueManager.StartNewConversation();

        var message = dialogue.Receive(request.Text);

        var response = new ChatResponse()
        {
            Role = "Assistant",
            Content = message.Content
        };

        return response;
    }
}