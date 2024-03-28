using BankInfo.TelegramBot.Client.Exceptions.Base;

namespace BankInfo.TelegramBot.Client.Exceptions;

class JsonConvertException : BaseCustomException
{
    public JsonConvertException() { }

    public JsonConvertException(string message)
        : base(message) { }

    public JsonConvertException(string message, Exception inner)
        : base(message, inner) { }
}
