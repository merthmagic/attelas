using Attelas.Domain.Dialogue;

namespace Attelas.Domain.NLG;

public interface IResponseGenerator
{
    Message GenerateResponse(string input, List<Message> history);

    Message GenerateResponse(string input, List<Message> history, string reference);
}