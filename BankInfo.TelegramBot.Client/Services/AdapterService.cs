namespace BankInfo.TelegramBot.Client.Services;

public class AdapterService
{
    public static void ConsolePrint(string message) => Console.WriteLine(message);
    public static void ConsolePrint(string message, long chatId) => Console.WriteLine($"Received a '{message}' message in chat {chatId}.");
}
