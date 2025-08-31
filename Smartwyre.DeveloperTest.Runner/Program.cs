using System;
using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Services.Calculations;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Types;


namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
        .AddTransient<IRebateService, RebateService>()
        .AddTransient<IProductDataStore, ProductDataStore>()
        .AddTransient<IRebateDataStore, RebateDataStore>()
        .AddSingleton<ICalculateIncentive, CalculateAmountPerUomService>()
        .AddSingleton<ICalculateIncentive, CalculateFixedCashAmountService>()
        .AddSingleton<ICalculateIncentive, CalculateFixedRateService>()
        .BuildServiceProvider();

        var rebateService = serviceProvider.GetRequiredService<IRebateService>();

        Console.WriteLine("Please enter the Product Identifier:");
        string productIdentifier = Console.ReadLine();

        Console.WriteLine("Please enter the Rebate Identifier:");
        string rebateIdentifier = Console.ReadLine();

        Console.WriteLine("Please enter the Volume:");
        string volumeInput = Console.ReadLine();
        if (!decimal.TryParse(volumeInput, out decimal volume))
        {
            Console.WriteLine("Volume must be a decimal.");
            return;
        }

        var request = new CalculateRebateRequest()
        {
            ProductIdentifier = productIdentifier,
            RebateIdentifier = rebateIdentifier,
            Volume = volume
        };
        Console.WriteLine($"ProductIdentifier: {productIdentifier}\nRebateIdentifier: {rebateIdentifier}\nVolume: {volume}\n");

        CalculateRebateResult result = rebateService.Calculate(request);

        Console.WriteLine("Success?: " + result.Success.ToString());
    }
}
