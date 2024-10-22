using Attelas.Application.Client;
using Attelas.Domain.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Attelas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController(IClientService clientService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<Client> GetClient(string clientId)
        {
            var result = clientService.GetClient(clientId);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}