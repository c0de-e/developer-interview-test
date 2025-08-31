using System;
using System.Linq;
using System.Collections.Generic;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Services.Interfaces;

namespace Smartwyre.DeveloperTest.Services.Calculations;

// We use this class to provide the correct calculation service based on the IncentiveType
public class CalculateIncentiveProvider(IEnumerable<ICalculateIncentive> services) : ICalculateIncentiveProvider
{
    private readonly Dictionary<IncentiveType, ICalculateIncentive> _services = services.ToDictionary(s => s.IncentiveType);

    public ICalculateIncentive GetService(IncentiveType incentiveType)
    {
        if (_services.TryGetValue(incentiveType, out var service))
            return service;
        throw new NotSupportedException($"Incentive type ({incentiveType}) not yet supported");
    }
}