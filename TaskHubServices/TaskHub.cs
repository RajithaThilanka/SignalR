using Microsoft.AspNetCore.SignalR;

namespace TaskManaget.API.TaskHubServices;

public sealed class TaskHub  : Hub <ITaskClient>
{
    private readonly ILogger<TaskHub> _logger;

    public TaskHub(ILogger<TaskHub> logger)
    {
        _logger = logger;
    }
    
    public override async Task OnConnectedAsync()
    {   
        _logger.LogInformation("Client connected: {ConnectionId}", Context.ConnectionId);
        await Clients.All.ReceiveMessage($"{Context.ConnectionId} joined the hub");
    }
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        _logger.LogInformation("Client disconnected: {ConnectionId}", Context.ConnectionId);
        await Clients.All.ReceiveMessage($"{Context.ConnectionId} left the hub");
        await base.OnDisconnectedAsync(exception);
    }

    public async Task SendMessageAsync(string message)
    {
        _logger.LogInformation("Message from {ConnectionId}: {Message}", Context.ConnectionId, message);
        await Clients.All.ReceiveMessage($"{Context.ConnectionId}: {message}");
    }
}
