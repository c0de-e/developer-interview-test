using System;
using Xunit;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Services.Calculations;

namespace Smartwyre.DeveloperTest.Tests;

public class RebateServiceTests
{
    [Fact]
    public void CalculateAmountPerUomService_ShouldReturnSuccess_WhenValidRequest()
    {
        var request = new CalculateRebateRequest
        {
            Volume = 5m
        };

        var product = new Product
        {
            SupportedIncentives = SupportedIncentiveType.AmountPerUom
        };

        var rebate = new Rebate
        {
            Incentive = IncentiveType.AmountPerUom,
            Amount = 10m
        };

        var service = new CalculateAmountPerUomService();

        var result = service.CalculateRebate(request, rebate, product);
        var isValid = service.IsValidRequest(request, rebate, product);

        Console.WriteLine(isValid);
        Console.WriteLine(result);

        Assert.Equal(50m, result);
        Assert.True(isValid);
    }

    [Fact]
    public void CalculateFixedCashAmountService_ShouldReturnSuccess_WhenValidRequest()
    {
        var request = new CalculateRebateRequest { };

        var product = new Product
        {
            SupportedIncentives = SupportedIncentiveType.FixedCashAmount
        };

        var rebate = new Rebate
        {
            Incentive = IncentiveType.FixedCashAmount,
            Amount = 10m
        };

        var service = new CalculateFixedCashAmountService();

        var result = service.CalculateRebate(request, rebate, product);
        var isValid = service.IsValidRequest(request, rebate, product);

        Console.WriteLine(isValid);
        Console.WriteLine(result);

        Assert.Equal(10m, result);
        Assert.True(isValid);
    }

    [Fact]
    public void CalculateFixedRateService_ShouldReturnSuccess_WhenValidRequest()
    {
        var request = new CalculateRebateRequest
        {
            Volume = 5m
        };

        var product = new Product
        {
            Price = 1000m,
            SupportedIncentives = SupportedIncentiveType.FixedRateRebate
        };

        var rebate = new Rebate
        {
            Incentive = IncentiveType.FixedRateRebate,
            Percentage = 0.05m
        };

        var service = new CalculateFixedRateService();

        var result = service.CalculateRebate(request, rebate, product);
        var isValid = service.IsValidRequest(request, rebate, product);

        Console.WriteLine(isValid);
        Console.WriteLine(result);

        Assert.Equal(250m, result);
        Assert.True(isValid);
    }

    [Fact]
    public void CalculateAmountPerUomService_ShouldReturnZero_WhenVolumeIsZero()
    {
        var request = new CalculateRebateRequest { Volume = 0m };
        var product = new Product { SupportedIncentives = SupportedIncentiveType.AmountPerUom };
        var rebate = new Rebate { Incentive = IncentiveType.AmountPerUom, Amount = 10m };
        var service = new CalculateAmountPerUomService();

        var result = service.CalculateRebate(request, rebate, product);
        var isValid = service.IsValidRequest(request, rebate, product);

        Assert.Equal(0m, result);
        Assert.False(isValid);
    }

    [Fact]
    public void CalculateFixedCashAmountService_ShouldReturnZero_WhenAmountIsZero()
    {
        var request = new CalculateRebateRequest { Volume = 5m };
        var product = new Product { SupportedIncentives = SupportedIncentiveType.FixedCashAmount };
        var rebate = new Rebate { Incentive = IncentiveType.FixedCashAmount, Amount = 0m };
        var service = new CalculateFixedCashAmountService();

        var result = service.CalculateRebate(request, rebate, product);
        var isValid = service.IsValidRequest(request, rebate, product);

        Assert.Equal(0m, result);
        Assert.False(isValid);
    }

    [Fact]
    public void CalculateFixedRateService_ShouldReturnZero_WhenPercentageIsZero()
    {
        var request = new CalculateRebateRequest { Volume = 5m };
        var product = new Product { Price = 1000m, SupportedIncentives = SupportedIncentiveType.FixedRateRebate };
        var rebate = new Rebate { Incentive = IncentiveType.FixedRateRebate, Percentage = 0m };
        var service = new CalculateFixedRateService();

        var result = service.CalculateRebate(request, rebate, product);
        var isValid = service.IsValidRequest(request, rebate, product);

        Assert.Equal(0m, result);
        Assert.False(isValid);
    }
}
