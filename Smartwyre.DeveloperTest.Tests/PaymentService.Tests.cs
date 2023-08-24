using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    [Fact]
    public void FixedCashAmount_Rebate_Test1()
    {
        // Arrange
        RebateDataStore rebateDataStore = new();
        ProductDataStore productDataStore = new();
        RebateService service = new(rebateDataStore, productDataStore);
        var calculateRebateRequest = new CalculateRebateRequest();


        // Act
        var rebate = rebateDataStore.GetRebate("abc");
        var product = productDataStore.GetProduct("123");
        var rebateRequest = calculateRebateRequest.GetRebateRequest(1);
        var result = service.Calculate(rebateRequest);


        // Assert
        Assert.NotNull(rebate);
        Assert.NotNull(product);
        Assert.Equal(rebate.Identifier, rebateRequest.RebateIdentifier);
        Assert.Equal(product.Identifier, rebateRequest.ProductIdentifier);
        Assert.Equal(product.SupportedIncentives.ToString(), rebate.Incentive.ToString());
        Assert.True(result.Success);
        
    }

    [Fact]
    public void FixedCashAmount_Rebate_Test2()
    {
        // Arrange
        RebateDataStore rebateDataStore = new();
        ProductDataStore productDataStore = new();
        RebateService service = new(rebateDataStore, productDataStore);
        var calculateRebateRequest = new CalculateRebateRequest
        {
            RebateIdentifier = "abc1",
            ProductIdentifier = "123",
        };


        // Act
        var rebate = rebateDataStore.GetRebate("abc");
        var product = productDataStore.GetProduct("123");
        var rebateRequest = calculateRebateRequest;
        var result = service.Calculate(rebateRequest);


        // Assert
        Assert.NotNull(rebate);
        Assert.NotNull(product);
        Assert.NotEqual(rebate.Identifier, rebateRequest.RebateIdentifier);
        Assert.Equal(product.Identifier, rebateRequest.ProductIdentifier);
        Assert.Equal(product.SupportedIncentives.ToString(), rebate.Incentive.ToString());
        Assert.False(result.Success);

    }

    [Fact]
    public void FixedRateRebate_Rebate_Test3()
    {
        // Arrange
        RebateDataStore rebateDataStore = new();
        ProductDataStore productDataStore = new();
        RebateService service = new(rebateDataStore, productDataStore);
        var calculateRebateRequest = new CalculateRebateRequest
        {
            RebateIdentifier = "klm",
            ProductIdentifier = "123"
        };



        // Act
        var rebate = rebateDataStore.GetRebate("klm");  //doesn't exist
        var product = productDataStore.GetProduct("123");
        var rebateRequest = calculateRebateRequest;
        var result = service.Calculate(rebateRequest);


        // Assert
        Assert.Null(rebate);
        Assert.NotNull(product);
        Assert.False(result.Success);

    }

    [Fact]
    public void FixedRate_Rebate_Test1()
    {
        // Arrange
        RebateDataStore rebateDataStore = new();
        ProductDataStore productDataStore = new();
        RebateService service = new(rebateDataStore, productDataStore);
        var calculateRebateRequest = new CalculateRebateRequest();
     
        // Act
        var rebate = rebateDataStore.GetRebate("def");
        var product = productDataStore.GetProduct("456");
        var rebateRequest = calculateRebateRequest.GetRebateRequest(2);
        var result = service.Calculate(rebateRequest);


        // Assert
        Assert.NotNull(rebate);
        Assert.NotNull(product);
        Assert.Equal(rebate.Identifier, rebateRequest.RebateIdentifier);
        Assert.Equal(product.Identifier, rebateRequest.ProductIdentifier);
        Assert.Equal(product.SupportedIncentives.ToString(), rebate.Incentive.ToString());
        Assert.True(result.Success);

    }

    [Fact]
    public void FixedRate_Rebate_Test2()
    {
        // Arrange
        RebateDataStore rebateDataStore = new();
        ProductDataStore productDataStore = new();
        RebateService service = new(rebateDataStore, productDataStore);
        var calculateRebateRequest = new CalculateRebateRequest
        {
            RebateIdentifier = "def",
            ProductIdentifier = "333"
        };

        // Act
        var rebate = rebateDataStore.GetRebate("def");
        var product = productDataStore.GetProduct("333");  //doesn't exist
        var rebateRequest = calculateRebateRequest;
        var result = service.Calculate(rebateRequest);


        // Assert
        Assert.NotNull(rebate);
        Assert.Null(product);
        Assert.False(result.Success);

    }
}
