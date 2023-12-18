using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace BankInfo.TelegramBot.Client;

public class Listener
{
    public readonly ITelegramBotClient _client;
    public Listener(ITelegramBotClient telegramBotClient, ReceiverOptions receiverOptions, CancellationTokenSource cts) 
    {
        _client = telegramBotClient ?? throw new ArgumentNullException(nameof(telegramBotClient));
        _client.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync, receiverOptions, cts.Token);
    }

    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message)
            return; 
        if (message.Text is not { } messageText)
            return;

        var chatId = message.Chat.Id;

        //Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

        Message sentMessage = await botClient.SendTextMessageAsync(chatId, "You said:\n" + messageText, cancellationToken: cancellationToken);
    }

    public static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}", 
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}
