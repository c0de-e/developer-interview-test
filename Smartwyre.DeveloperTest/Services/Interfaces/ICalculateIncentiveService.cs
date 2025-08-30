
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.Interfaces;

public interface ICalculateIncentive
{
    decimal CalculateRebate(CalculateRebateRequest request, Product product, Rebate rebate);
    bool IsValidRequest(CalculateRebateRequest request, Rebate rebate, Product product);
}