using BankInfo.TelegramBot.Client.Services;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace BankInfo.TelegramBot.Client;

public class Listener
{
    private readonly ITelegramBotClient _client;
    public Listener(ITelegramBotClient telegramBotClient, ReceiverOptions receiverOptions, CancellationTokenSource cts) 
    {
        _client = telegramBotClient ?? throw new ArgumentNullException(nameof(telegramBotClient));
        StartReceiving(receiverOptions, cts);
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
        AdapterService.ConsolePrint(ErrorMessage);
        return Task.CompletedTask;
    }

    private void StartReceiving(ReceiverOptions receiverOptions, CancellationTokenSource cts)
    {
        _client.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync, receiverOptions, cts.Token);
    }
}
