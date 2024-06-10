namespace TaskManaget.API.TaskHubServices;

public interface ITaskClient
{
    Task ReceiveMessage(string message);
    Task ReceiveGroupNotification(string message);
    Task ReceiveTypingNotification(string message);
}