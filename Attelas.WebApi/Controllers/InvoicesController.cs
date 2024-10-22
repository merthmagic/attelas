using Attelas.Application.Invoice;
using Attelas.Domain.Core;
using Microsoft.AspNetCore.Mvc;

namespace Attelas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController(IInvoiceService invoiceService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<Invoice> GetInvoice(string invoiceNumber)
        {
            var result = invoiceService.GetInvoice(invoiceNumber);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}