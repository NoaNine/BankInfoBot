using BankInfo.TelegramBot.Client.Exceptions.Base;

namespace BankInfo.TelegramBot.Client.Exceptions
{
    class InvalidCommandException : BaseCustomException
    {
        public InvalidCommandException() { }

        public InvalidCommandException(string message)
            : base(message) { }

        public InvalidCommandException(string message, Exception inner)
            : base(message, inner) { }
    }

}
