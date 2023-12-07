using BankInfo.TelegramBot.Client;
using Telegram.Bot;

namespace BankInfo.AppCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var botClient = new TelegramBotClient("6071781001:AAH_PDzLwbwj46-i-aNlDMT7uF4mMw3onTs");    
            var me = botClient.GetMeAsync();
            Console.WriteLine($"Hello, World! I am user {me.Id}.");
            Console.ReadLine();
            var userSpeaker = new UserSpeaker(botClient);
        }
    }
}
