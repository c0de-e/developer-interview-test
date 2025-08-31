using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.Calculations;

public class CalculateFixedCashAmountService : CalculateService
{
    public override IncentiveType IncentiveType => IncentiveType.FixedCashAmount;

    public override decimal CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product)
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