namespace Attelas.Domain.Process;

public interface IProcessExecutor
{
    IProcessExecuteResult Execute(IProcessExecuteContext context);
}