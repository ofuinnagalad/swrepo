using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Factory;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly RebateDataStore rebateDataStore;
    private readonly ProductDataStore productDataStore;

    public RebateService(RebateDataStore rebateStore, ProductDataStore productStore)
    {
        rebateDataStore = rebateStore;
        productDataStore = productStore;
    }

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        Rebate rebate = rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = productDataStore.GetProduct(request.ProductIdentifier);

        var result = new CalculateRebateResult();
        IRebateType rebateType = RebateTypeFactory.Build(rebate, product, request);

        result.Success = rebateType != null && rebateType.IsValidRebate();

        if (result.Success)
        {
            decimal rebateAmount = rebateType.CalculateRebateAmount();
            rebateDataStore.StoreCalculationResult(rebate, rebateAmount);
        }
        
        return result;
    }
}
