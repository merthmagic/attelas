using Attelas.Domain.NLU;

namespace Attelas.Domain.Process;

public interface IProcessDispatcher
{
    IProcessExecutor Dispatch(IntentClassification intent);
}