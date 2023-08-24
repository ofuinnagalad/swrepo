using System;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore
{
    private List<Rebate> GetRebateData()
    {
        List<Rebate> rebateList =  new List<Rebate>()
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
            }
        };

        return rebateList;
    }

    public Rebate GetRebate(string rebateIdentifier)
    {
        // Access database to retrieve account, code removed for brevity
        return GetRebateData().Single(x => x.Identifier == rebateIdentifier);
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        // Update account in database, code removed for brevity
    }
}
