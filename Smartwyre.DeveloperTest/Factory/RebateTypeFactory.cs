using System;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Factory
{
    public static class RebateTypeFactory
    {
        public static IRebateType Build(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            return rebate.Incentive switch
            {
                IncentiveType.FixedCashAmount => new FixedCashAmountRebate(rebate,product),
                IncentiveType.FixedRateRebate => new FixedRateRebate(rebate, product, request),
                IncentiveType.AmountPerUom => new AmountPerUomRebate(rebate, product, request),
                _ => throw new NotImplementedException(),
            };
        }
    }
}

