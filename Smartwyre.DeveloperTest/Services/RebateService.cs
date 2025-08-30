using System;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Services.Calculations;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService(IRebateDataStore rebateDataStore, IProductDataStore productDataStore) : IRebateService
{
    private readonly IRebateDataStore _rebateDataStore = rebateDataStore;
    private readonly IProductDataStore _productDataStore = productDataStore;

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        Rebate rebate = _rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = _productDataStore.GetProduct(request.ProductIdentifier);

        CalculateService calculateService = rebate.Incentive switch
        {
            IncentiveType.FixedCashAmount => new CalculateFixedCashAmountService(),
            IncentiveType.FixedRateRebate => new CalculateFixedRateService(),
            IncentiveType.AmountPerUom => new CalculateAmountPerUomService(),
            _ => throw new NotSupportedException("Incentive type not yet supported"),
        };
        Console.WriteLine(rebate.Incentive.ToString());

        var result = new CalculateRebateResult { Success = calculateService.IsValidRequest(request, rebate, product) };
        if (result.Success)
        {
            decimal rebateAmount = calculateService.CalculateRebate(request, product, rebate);
            _rebateDataStore.StoreCalculationResult(rebate, rebateAmount);
        }
        return result;
    }
}
