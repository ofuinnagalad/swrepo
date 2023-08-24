using System;

namespace Smartwyre.DeveloperTest.Types;

public class CalculateRebateRequest
{
    public string RebateIdentifier { get; set; }

    public string ProductIdentifier { get; set; }

    public decimal Volume { get; set; }

    //Set up sample Rebate requests
    public CalculateRebateRequest GetRebateRequest(int option)
    {
        return option switch
        {
            1 => new CalculateRebateRequest
            {
                ProductIdentifier = "123",
                RebateIdentifier = "abc",
                Volume = 0
            },
            2 => new CalculateRebateRequest
            {
                ProductIdentifier = "456",
                RebateIdentifier = "def",
                Volume = 10
            },
            3 => new CalculateRebateRequest
            {
                ProductIdentifier = "789",
                RebateIdentifier = "xyz",
                Volume = 2
            },
            _ => throw new NotImplementedException(),
        };
    }
}
