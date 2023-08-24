using System;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    
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

            var calculateRebateRequest = new CalculateRebateRequest().GetRebateRequest(option);

            var result = service.Calculate(calculateRebateRequest);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        

        
    }
}
