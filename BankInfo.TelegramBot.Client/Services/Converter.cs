using BankInfo.TelegramBot.Client.Exceptions;
using BankInfo.TelegramBot.Client.Models;
using Newtonsoft.Json;

namespace BankInfo.TelegramBot.Client.Services;

public class Converter
{
    public CurrencyInfo Convert(string jsonString) => JsonConvert.DeserializeObject<CurrencyInfo>(jsonString, new JsonSerializerSettings() { DateFormatString = "yyyy-MM-DD" }) ?? throw new JsonConvertException();
}
