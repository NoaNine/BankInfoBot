namespace BankInfo.TelegramBot.Client.Services;

public class ReplicaTemplates
{
    public static string GetReplica_AllCommandList()
    {
        return "list";
    }

    public static string GetReplica_Greeting() => 
        "Hello.\n" +
        "Welcome to bank info bot, it can show the current exchange rate currency or the exchange rate currency for a specific date.";

    public static string GetReplica_AllCommadDetails()
    {
        return "details";
    }

    public static string GetReplica_WrongCommand() => "Wrong command. Try again.";
}
