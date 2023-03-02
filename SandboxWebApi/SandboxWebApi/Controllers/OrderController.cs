using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SandboxWebApi.Hubs;
using SandboxWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SandboxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private IHubContext<AgoraOrderHub> _hub;
        //private AgoraOrderHub _hub;

        public OrderController(ILogger<OrderController> logger
            , IHubContext<AgoraOrderHub> hub)
        {
            _logger = logger;
            _hub = hub;
        }

        [HttpGet("snapshot")] 
        public ActionResult<IEnumerable<AgoraOrder>> Get()
        {
            return Ok(JsonSerializer.Serialize(Helper.GetOrders(50)));
        }

        [HttpGet("ordernotification")]
        public IActionResult GetNewOrder()
        {
            var result = _hub.Clients.All.SendAsync("receiveorder", JsonSerializer.Serialize(Helper.GetOrders(5)));
            return Ok(new { Status = "Order sent to all clients completed" });
        }
    }
}
