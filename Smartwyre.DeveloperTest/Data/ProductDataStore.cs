using System.Collections.Generic;
using System.Linq;
using Smartwyre.DeveloperTest.Types;


namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore
{
    private List<Product> GetProductData()
    {
        List<Product> productList = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Identifier = "123",
                SupportedIncentives = SupportedIncentiveType.FixedCashAmount,
                Price = 40,
                Uom = "A"
            },
            new Product
            {
                Id = 2,
                Identifier = "456",
                SupportedIncentives = SupportedIncentiveType.FixedRateRebate,
                Price = 20,
                Uom = "B"
            },
            new Product
            {
                Id = 3,
                Identifier = "789",
                SupportedIncentives = SupportedIncentiveType.AmountPerUom,
                Price = 60,
                Uom = "C"
            }
        };

        return productList;
    }

    public Product GetProduct(string productIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        return GetProductData().Single(x => x.Identifier == productIdentifier);
    }
}
