
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.Calculations;

public class CalculateFixedRateService : CalculateService
{
    public override decimal CalculateRebate(CalculateRebateRequest request, Product product, Rebate rebate)
    {
        return product.Price * rebate.Percentage * request.Volume;
    }

    public override bool IsValidRequest(CalculateRebateRequest request, Rebate rebate, Product product)
    {
        if (rebate == null
        || product == null
        || !product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate)
        || rebate.Percentage == 0
        || product.Price == 0
        || request.Volume == 0)
            return false;
        return true;
    }
}