using Attelas.Domain.NLU;

namespace Attelas.Domain.Dialogue;

/// <summary>
/// Conversation domain object
/// </summary>
/// <param name="context"></param>
public class Dialogue(IDialogueContext context)
{
    private readonly List<Message> _messages = [];

    public IEnumerable<Message> Messages => _messages;

    public string Id { get; set; }

    /// <summary>
    /// Conversation receive a message and return a response
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public Message Receive(string input)
    {
        var intentClassification = context.IntentClassifier.Recognize(input);
        Message ret = null!;
        switch (intentClassification.Intent)
        {
            case IntentConstants.Chat:
            {
                ret = context.ResponseGenerator.GenerateResponse(input, _messages);
                break;
            }
            case IntentConstants.Query:
            {
                var info = context.InformationRetriever.RetrieveInvoice(intentClassification.Slots);
                ret = context.ResponseGenerator.GenerateResponse(input, _messages, info);
                break;
            }
            case IntentConstants.Command:
            {
                ret = context.ResponseGenerator.GenerateResponse(input, _messages);
                break;
            }
            default:
            {
                ret = context.ResponseGenerator.GenerateResponse(input, _messages);
                break;
            }
        }

        return ret;
    }

    public bool IsNew => _messages.Count == 0;
}

public class Message
{
    public string Role { get; set; }

    public string Content { get; set; }

    public static Message AssistantMessage(string content)
    {
        if (string.IsNullOrEmpty(content))
            throw new ArgumentException("Content cannot be null or empty", nameof(content));

        return new Message() { Role = "Assistant", Content = content };
    }

    public static Message UserMessage(string content)
    {
        if (string.IsNullOrEmpty(content))
            throw new ArgumentException("Content cannot be null or empty", nameof(content));
        return new Message() { Role = "User", Content = content };
    }
}