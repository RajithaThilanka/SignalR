using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TaskManaget.API.TaskHubServices;

namespace TaskManaget.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly IHubContext<TaskHub, ITaskClient> _hubContext;

    public TaskController(IHubContext<TaskHub, ITaskClient> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost("broadcast")]
    public async Task<IActionResult> BroadcastMessage([FromBody] string message)
    {
        await _hubContext.Clients.All.ReceiveMessage(message);
        return Ok();
    }
    
}