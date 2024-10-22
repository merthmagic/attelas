namespace Attelas.Domain.NLU;

public interface IIntentClassifier
{
    IntentClassification Recognize(string input);
}