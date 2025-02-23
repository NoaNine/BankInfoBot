﻿using BankInfo.TelegramBot.Client;
using BankInfo.TelegramBot.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace BankInfo.AppCore;

internal class Program
{
    static async Task Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(app =>
            {
                app.SetBasePath(Directory.GetCurrentDirectory());
                app.AddJsonFile("appsettings.json");
            })
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton(new TelegramBotClient(context.Configuration.GetConnectionString("BotApi")));
                services.AddSingleton(new ReceiverOptions() { AllowedUpdates = Array.Empty<UpdateType>() });
                services.AddSingleton(new CancellationTokenSource());
                services.AddSingleton(new HttpClient());
                services.AddScoped(p => new PrivateBankCurrentcyExchnageMonitor(
                    (HttpClient)p.GetService(typeof(HttpClient)), 
                    context.Configuration.GetConnectionString("BankApi")));
                services.AddScoped(p => new BotEngine(
                    (TelegramBotClient)p.GetService(typeof(TelegramBotClient)),
                    (ReceiverOptions)p.GetService(typeof(ReceiverOptions)),
                    (CancellationTokenSource)p.GetService(typeof(CancellationTokenSource))
                    ));
            })
            .Build();
        var listener = host.Services.GetRequiredService<BotEngine>();
        var test = host.Services.GetRequiredService<PrivateBankCurrentcyExchnageMonitor>();
        Console.ReadLine();
    }
}
