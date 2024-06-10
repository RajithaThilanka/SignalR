using Microsoft.AspNetCore.SignalR;

namespace TaskManaget.API.TaskHubServices;

public sealed class TaskHub  : Hub <ITaskClient>
{
    public override async Task OnConnectedAsync()
    {
        await Clients.All.ReceiveMessage($"{Context.ConnectionId} joined the hub");
    }

    public async Task SendMessageAsync(string message)
    {
        await Clients.All.ReceiveMessage($"{Context.ConnectionId}: {message}");
    }
}
