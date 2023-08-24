using System;
namespace Smartwyre.DeveloperTest.Types
{
	public interface IRebateType
	{
        decimal CalculateRebateAmount();
        bool IsValidRebate();
    }
}

