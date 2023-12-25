namespace BankInfo.TelegramBot.Client.Services;

public class PrivateBankCurrentcyExchnageMonitor
{
    private readonly string _baseAddress;
    private readonly HttpClient _httpClient;

    public PrivateBankCurrentcyExchnageMonitor(HttpClient httpClient, string address)
    {
        _baseAddress = address ?? throw new ArgumentNullException(nameof(address));
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public string GetCurrencyRateToday()
    {

        return null;
    }

    public string GetCurrencyRateByDate(DateTime date)
    {

        return null;
    }

    public List<string> GetCurrencyRateByDateRange(DateTime startDate, DateTime endDate)
    {
        return new List<string> { };
    }

    public async Task<string> CallBankApi(string address)
    {
        try
        {
            using (var response = await _httpClient.GetAsync(new Uri(_baseAddress)))
            {
                var result = await response.Content.ReadAsStringAsync();
            }
        }
        catch (Exception ex)
        {
            Adapter.ConsolePrint(ex.Message);
        }
        return null;
    }
}
