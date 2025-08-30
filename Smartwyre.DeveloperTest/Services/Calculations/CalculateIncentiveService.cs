
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.Calculations;

// Use an abstract class in case we want a default implementation in the future
public abstract class CalculateService : ICalculateIncentive
{
    public abstract decimal CalculateRebate(CalculateRebateRequest request, Product product, Rebate rebate);
    public abstract bool IsValidRequest(CalculateRebateRequest request, Rebate rebate, Product product);
}