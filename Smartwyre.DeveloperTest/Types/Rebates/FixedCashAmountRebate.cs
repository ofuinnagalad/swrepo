namespace Smartwyre.DeveloperTest.Types
{
    public class FixedCashAmountRebate : IRebateType
    {
        readonly Rebate rebate;
        readonly Product product;
        decimal rebateAmount;

        public FixedCashAmountRebate(Rebate rebate, Product product)
        {
            this.rebate = rebate;
            this.product = product;
        }

        public decimal CalculateRebateAmount()
        {
            rebateAmount = rebate.Amount;

            return rebateAmount;
        }

        public bool IsValidRebate()
        {
            if (rebate == null)
            {
                return false;
            }
            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
            {
                return false;
            }
            else if (rebate.Amount == 0)
            {
                return false;
            }

            return true;
        }
    }
}

