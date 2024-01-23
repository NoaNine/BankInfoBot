using Newtonsoft.Json;

namespace BankInfo.TelegramBot.Client.Models;

public class CurrencyInfo
{
    [JsonProperty("date")]
    public DateTime Date { get; private set; }
    [JsonProperty("bank")]
    public string BankName { get; private set; }
    [JsonProperty("baseCurrency")]
    public int BaseCurrency { get; private set; }
    [JsonProperty("baseCurrencyLit")]
    public string BaseCurrencyLit { get; private set; }
    [JsonProperty("exchangeRate")]
    public ExchangeRate[] ExchangeRate { get; private set; }

    public CurrencyInfo(DateTime date, string bankName, int baseCurrency, string baseCurrencyLit, ExchangeRate[] exchangeRate)
    {
        Date = date;
        BankName = bankName;
        BaseCurrency = baseCurrency;
        BaseCurrencyLit = baseCurrencyLit;
        ExchangeRate = exchangeRate;
    }
}
