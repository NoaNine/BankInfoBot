using BankInfo.TelegramBot.Client;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace BankInfo.AppCore
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var botClient = new TelegramBotClient("6071781001:AAH_PDzLwbwj46-i-aNlDMT7uF4mMw3onTs");
            using CancellationTokenSource cts = new();
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };
            botClient.StartReceiving(Listener.HandleUpdateAsync, Listener.HandlePollingErrorAsync, receiverOptions, cts.Token);
            var me = await botClient.GetMeAsync();
            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();
            var listener = new Listener(botClient);
            cts.Cancel();
        }
    }
}
