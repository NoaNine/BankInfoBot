using BankInfo.TelegramBot.Client.Models;
using System.Text.Json;

namespace BankInfo.TelegramBot.Client.Services;

public class Converter
{
    public ExchangeRate JsonConvert(string jsonString) => JsonSerializer.Deserialize<ExchangeRate>(jsonString);
}
