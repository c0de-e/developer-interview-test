using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.Interfaces
{
    public interface ICalculateIncentive
    {
        IncentiveType IncentiveType { get; }

        decimal CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product);
        bool IsValidRequest(CalculateRebateRequest request, Rebate rebate, Product product);
    }
}