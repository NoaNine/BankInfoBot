namespace BankInfo.TelegramBot.Client.Models;

public class ExchangeRate
{
    public string BaseCurrency { get; private set; }
    public string Currency { get; private set; }
    public double SaleRateNB { get; private set; }
    public double PurchaseRateNB { get; private set; }
    public double SaleRate { get; private set; }
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
