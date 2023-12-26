using Newtonsoft.Json;

namespace BankInfo.TelegramBot.Client.Models;

public class ExchangeRate
{
    [JsonProperty("baseCurrency")]
    public string BaseCurrency { get; private set; }
    [JsonProperty("currency")]
    public string Currency { get; private set; }
    [JsonProperty("saleRateNB")]
    public double SaleRateNB { get; private set; }
    [JsonProperty("purchaseRateNB")]
    public double PurchaseRateNB { get; private set; }
    [JsonProperty("saleRate")]
    public double SaleRate { get; private set; }
    [JsonProperty("purchaseRate")]
    public double PurchaseRate { get; private set; }

    public ExchangeRate(string baseCurrency, string currency, double saleRateNB, double purchaseRateNB, double saleRate, double purchaseRate)
    {
        BaseCurrency = baseCurrency;
        Currency = currency;
        SaleRateNB = saleRateNB;
        PurchaseRateNB = purchaseRateNB;
        SaleRate = saleRate;
        PurchaseRate = purchaseRate;
    }
}
