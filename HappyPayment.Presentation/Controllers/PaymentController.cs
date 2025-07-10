using HappyPayment.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyPayment.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("Pay")]
        public IActionResult Pay(PaymentData paymentData)
        {
            return Ok();
        }
    }
}
