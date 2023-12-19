using BankInfo.TelegramBot.Client.Services;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace BankInfo.TelegramBot.Client;

public class BotEngine
{
    private readonly ITelegramBotClient _client;
    private readonly ReceiverOptions _receiverOptions;
    private readonly CancellationTokenSource _cts;
    public BotEngine(ITelegramBotClient telegramBotClient, ReceiverOptions receiverOptions, CancellationTokenSource cts) 
    {
        _client = telegramBotClient ?? throw new ArgumentNullException(nameof(telegramBotClient));
        _receiverOptions = receiverOptions ?? throw new ArgumentNullException(nameof(receiverOptions));
        _cts = cts ?? throw new ArgumentNullException(nameof(cts));
        StartReceiving();
    }

    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message)
            return; 
        if (message.Text is not { } messageText)
            return;

        var chatId = message.Chat.Id;

        AdapterService.ConsolePrint(messageText, chatId);

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

    private void StartReceiving()
    {
        try
        {
            _client.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync, _receiverOptions, _cts.Token);
        }
        catch (Exception ex)
        {
            AdapterService.ConsolePrint(ex.Message);
        }
    }
}
