using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.Calculations;

public class CalculateFixedCashAmountService : CalculateService
{
    public override decimal CalculateRebate(CalculateRebateRequest request, Product product, Rebate rebate)
    {
        return rebate.Amount;
    }

    public override bool IsValidRequest(CalculateRebateRequest request, Rebate rebate, Product product)
    {
        if (rebate == null || !product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount) || rebate.Amount == 0)
            return false;
        return true;
    }
}