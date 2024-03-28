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
        if (await IsInvalidCommand(update))
        {
            return;
        }
        var message = update.Message;
        var chatId = message.Chat.Id;

        Adapter.ConsolePrint(message.Text, chatId);

        Message sentMessage = await botClient.SendTextMessageAsync(chatId, "You said:\n" + message.Text, cancellationToken: cancellationToken);
    }

    public static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}", 
            _ => exception.ToString()
        };
        Adapter.ConsolePrint(ErrorMessage);
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
            Adapter.ConsolePrint(ex.Message);
        }
    }

    private static async Task<bool> IsInvalidCommand(Update update)
    {
        if(update == null
            || update.Message == null
            || update.Message.Text == null
            || update.Message.From == null
            || update.Message.From.Username == null)
        {
            return true;
        }
        return false;
    }
}
