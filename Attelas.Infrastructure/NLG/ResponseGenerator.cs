using System.Text;
using Attelas.Domain.Core;
using Attelas.Domain.Dialogue;
using Attelas.Domain.NLG;
using OpenAI.Chat;

namespace Attelas.Infrastructure.NLG;

public class ResponseGenerator(
    ChatClient chatClient,
    IInvoiceRepository invoiceRepository,
    IClientRepository clientRepository) : IResponseGenerator
{
    private const string prompt =
        """
        You are a helpful assistant named **Attelas JARVIS**. Now you are chating with an accountant who is working on invoices.
        Some more information about invoices or clients can be found in the help section.
        ## Help:
        """;

    public Message GenerateResponse(string input, List<Message> history)
    {
        return InternalGenerateResponse(input, history);
    }

    public Message GenerateResponse(string input, List<Message> history, string reference)
    {
        return InternalGenerateResponse(input, history, reference);
    }

    private Message InternalGenerateResponse(string input, List<Message> history, string reference = "")
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(prompt);
        stringBuilder.Append(reference);
        var messages = new List<ChatMessage> { new SystemChatMessage(stringBuilder.ToString()) };
        messages.AddRange(MapTo(history));
        messages.Add(new UserChatMessage(input));

        try
        {
            var result = chatClient.CompleteChat(messages);
            return new Message()
            {
                Role = "Assistant",
                Content = result.Value.Content[0].Text
            };
        }
        catch (Exception e)
        {
            return new Message()
            {
                Role = "Assistant",
                Content =
                    "Sorry, I am not able to help you right now due to a 3rd party service issue. Please try again later."
            };
        }
    }

    private List<ChatMessage> MapTo(List<Message> history)
    {
        var messages = new List<ChatMessage>();
        foreach (var message in history)
        {
            if (message.Role == "Assistant")
                messages.Add(new AssistantChatMessage(message.Content));
            else if (message.Role == "User")
                messages.Add(new UserChatMessage(message.Content));
        }

        return messages;
    }
}