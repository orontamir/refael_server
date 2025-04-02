using Microsoft.AspNetCore.Mvc;
using RefaelServer.Interfaces;
using RefaelServer.Models;


namespace RefaelServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _ordertService;
        public OrderController(IOrderService ordertService)
        {
            _ordertService = ordertService;
        }

        // POST api/<OrderController>
        [HttpPost("SubmitOrder")]
        public ActionResult SubmitOrder([FromBody] Order order)
        {

            _ordertService.SubmitOrder(order);
            return Ok();
        }

    }
}
