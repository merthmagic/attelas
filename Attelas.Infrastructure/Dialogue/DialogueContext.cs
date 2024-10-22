using Attelas.Domain.Dialogue;
using Attelas.Domain.NLG;
using Attelas.Domain.NLU;

namespace Attelas.Infrastructure.Dialogue;

public class DialogueContext:IDialogueContext
{
    public IIntentClassifier IntentClassifier { get; set; }
    public IResponseGenerator ResponseGenerator { get; set; }
    public IInformationRetriever InformationRetriever { get; set; }
}