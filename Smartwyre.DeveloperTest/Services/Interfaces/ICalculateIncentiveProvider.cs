using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.Interfaces;

public interface ICalculateIncentiveProvider
{
    ICalculateIncentive GetService(IncentiveType incentiveType);
}