
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.Calculations;

public class CalculateAmountPerUomService : CalculateService
{
    public override decimal CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product)
    {
        return rebate.Amount * request.Volume;
    }

    public override bool IsValidRequest(CalculateRebateRequest request, Rebate rebate, Product product)
    {
        if (rebate == null
        || product == null
        || !product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom)
        || rebate.Amount == 0
        || request.Volume == 0)
            return false;
        return true;
    }
}