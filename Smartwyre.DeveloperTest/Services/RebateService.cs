using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService(IRebateDataStore rebateDataStore, IProductDataStore productDataStore, ICalculateIncentiveProvider incentiveProvider) : IRebateService
{
    private readonly IRebateDataStore _rebateDataStore = rebateDataStore;
    private readonly IProductDataStore _productDataStore = productDataStore;
    private readonly ICalculateIncentiveProvider _incentiveProvider = incentiveProvider;

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        Rebate rebate = _rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = _productDataStore.GetProduct(request.ProductIdentifier);

        ICalculateIncentive calculateService = _incentiveProvider.GetService(rebate.Incentive);

        var result = new CalculateRebateResult { Success = calculateService.IsValidRequest(request, rebate, product) };
        if (result.Success)
        {
            decimal rebateAmount = calculateService.CalculateRebate(request, rebate, product);
            _rebateDataStore.StoreCalculationResult(rebate, rebateAmount);
        }
        return result;
    }
}
