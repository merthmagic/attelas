using Attelas.Domain.NLU;

namespace Attelas.Domain.Process;

/// <summary>
/// Dispatch intent to a specific process executor
/// </summary>
public class ProcessDispatcher : IProcessDispatcher
{
    public IProcessExecutor Dispatch(IntentClassification intent)
    {
        IProcessExecutor processExecutor = null;
        switch (intent.Intent)
        {
            case IntentConstants.Chat:
            {
                processExecutor = new EmptyProcessExecutor();
                break;
            }
            case IntentConstants.Query:
            {
                break;
            }
            case IntentConstants.Notification:
            {
                break;
            }
            case IntentConstants.SubmitInvoice:
            {
                break;
            }
        }

        return processExecutor;
    }
}