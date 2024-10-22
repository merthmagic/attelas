namespace Attelas.Domain.Process;

public abstract class AbstractProcessExecutor : IProcessExecutor
{
    public abstract IProcessExecuteResult Execute(IProcessExecuteContext context);
}