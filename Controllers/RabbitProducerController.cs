using Microsoft.AspNetCore.Mvc;
using RabbitMQAsService.Models;
using RabbitMQAsService.Support;

namespace RabbitMQAsService.Controllers
{
    [Route("api/producer")]
    public class RabbitProducerController : Controller
    {
        private readonly AmqpService amqpService;

        public RabbitProducerController(AmqpService amqpService)
        {
            this.amqpService = amqpService;
        }


        [HttpPost]
        public IActionResult PublishMessage([FromBody] CustomerDto customer)
        {
            try
            {
                amqpService.PublishMessage(customer);
                return Ok($"Mensaje producido: {customer.name}");
            }
            catch (Exception)
            {
                return BadRequest($"Problema el producir: {customer.name}");
            }
        }

    }
}
