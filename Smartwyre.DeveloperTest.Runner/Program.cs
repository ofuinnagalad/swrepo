using System;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    //Set up sample Rebate requests
    private static CalculateRebateRequest SetUpRebateRequest(int option)
    {
        return option switch
        {
            1 => new CalculateRebateRequest {
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

    private static ProductDataStore GetProductDataStore()
    {
        return new();
    }

    static void Main(string[] args)
    {
        //throw new NotImplementedException();
        Console.WriteLine("Enter a number for the incentive type and press enter");
        Console.WriteLine("1. Fixed Cash Amount");
        Console.WriteLine("2. Fixed Rate Rebate");
        Console.WriteLine("3. Amount Per Uom");

        try
        {
            var option = Convert.ToInt32(Console.ReadLine());

            RebateDataStore rebateDataStore = new();
            ProductDataStore productDataStore = new();
            RebateService service = new(rebateDataStore, productDataStore);

            CalculateRebateRequest calculateRebateRequest = SetUpRebateRequest(option);

            var result = service.Calculate(calculateRebateRequest);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        

        
    }
}
