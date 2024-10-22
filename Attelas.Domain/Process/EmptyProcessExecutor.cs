namespace Attelas.Domain.Process;

internal class EmptyProcessExecutor:IProcessExecutor
{
    public IProcessExecuteResult Execute(IProcessExecuteContext context)
    {
        return ProcessExecuteResult.Empty;
    }
}