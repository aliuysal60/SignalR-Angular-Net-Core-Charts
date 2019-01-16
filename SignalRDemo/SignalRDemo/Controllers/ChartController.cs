using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.DataStorage;
using SignalRDemo.HubConfig;
using SignalRDemo.TimerFeatures;

namespace RealTimeCharts_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private IHubContext<ChartHub> _hub;

        public ChartController(IHubContext<ChartHub> hub)
        {
            _hub = hub;
        }

        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("receivechartdata", DataManager.GetData()));

            return Ok(new { Message = "Request Completed" });
        }
    }
}