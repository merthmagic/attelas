using Attelas.Domain.NLG;
using Attelas.Domain.NLU;

namespace Attelas.Domain.Dialogue;

/// <summary>
/// The dialogue context 
/// </summary>
public interface IDialogueContext
{
    IIntentClassifier IntentClassifier { get; }
    IResponseGenerator ResponseGenerator { get; }
    IInformationRetriever InformationRetriever { get; }
}