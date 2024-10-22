using Attelas.Domain.Dialogue;
using Attelas.Domain.NLG;
using Attelas.Domain.NLU;

namespace Attelas.Infrastructure.Dialogue;

public class InMemoryDialogueManager(
    IIntentClassifier intentClassifier,
    IResponseGenerator responseGenerator,
    IInformationRetriever informationRetriever)
    : IDialogueManager
{
    private static Dictionary<string, Domain.Dialogue.Dialogue?> dialogues = new();

    public Domain.Dialogue.Dialogue? GetConversation(string? conversationId)
    {
        if (string.IsNullOrEmpty(conversationId))
            return StartNewConversation();

        return dialogues.ContainsKey(conversationId) ? dialogues[conversationId] : null;
    }

    private void RegisterConversation(Domain.Dialogue.Dialogue dialogue)
    {
        ArgumentNullException.ThrowIfNull(dialogue);

        if (string.IsNullOrEmpty(dialogue.Id))
            throw new ArgumentException("Conversation ID cannot be empty", nameof(dialogue));

        dialogues[dialogue.Id] = dialogue;
    }

    public Domain.Dialogue.Dialogue StartNewConversation()
    {
        var ctx = new DialogueContext()
        {
            IntentClassifier = intentClassifier, ResponseGenerator = responseGenerator,
            InformationRetriever = informationRetriever
        };
        var dialogue = new Domain.Dialogue.Dialogue(ctx);
        dialogue.Id = new Guid().ToString();
        RegisterConversation(dialogue);
        return dialogue;
    }
}