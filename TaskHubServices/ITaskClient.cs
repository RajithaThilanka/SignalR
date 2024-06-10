namespace TaskManaget.API.TaskHubServices;

public interface ITaskClient
{
    Task ReceiveMessage(string message);
}