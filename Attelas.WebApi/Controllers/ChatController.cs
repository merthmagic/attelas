using Attelas.Application.Chat;
using Microsoft.AspNetCore.Mvc;

namespace Attelas.WebApi.Controllers;

/// <summary>
/// Chat controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ChatController(IChatService chatService) : ControllerBase
{
    /// <summary>
    /// Chat completions
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public ActionResult<ChatResponse> Completions([FromBody] ChatRequest request)
    {
        var input = request.Text;

        var result = chatService.Complete(request);

        return Ok(result);
    }
}