using System;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore
{
    public IEnumerable<Rebate> AllRebates => GetRebateData();

    private List<Rebate> GetRebateData()
    {
        List<Rebate> rebates =  new()
        {
            new Rebate
            {
                Identifier = "abc",
                Incentive = IncentiveType.FixedCashAmount,
                Amount = 50,
                Percentage = 8
            },
            new Rebate
            {
                Identifier = "def",
                Incentive = IncentiveType.FixedRateRebate,
                Amount = 30,
                Percentage = 12
            },
            new Rebate
            {
                Identifier = "xyz",
                Incentive = IncentiveType.AmountPerUom,
                Amount = 70,
                Percentage = 10
            },
            new Rebate
            {
                Identifier = "abc1",
                Incentive = IncentiveType.FixedCashAmount,
                Amount = 0,
                Percentage = 5
            },
        };

        return rebates;
    }

    public Rebate GetRebate(string rebateIdentifier)
    {
        // Access database to retrieve account, code removed for brevity
        return GetRebateData().Find(x => x.Identifier == rebateIdentifier);
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        // Update account in database, code removed for brevity
    }
}
