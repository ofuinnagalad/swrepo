namespace Smartwyre.DeveloperTest.Types
{
    public class FixedRateRebate : IRebateType
    {
        readonly Rebate rebate;
        readonly Product product;
        readonly CalculateRebateRequest request;
        decimal rebateAmount;

        public FixedRateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            this.rebate = rebate;
            this.product = product;
            this.request = request;
        }

        public decimal CalculateRebateAmount()
        {
            if (product != null && rebate != null && request != null)
            {
                rebateAmount += product.Price * rebate.Percentage * request.Volume;

                return rebateAmount;
            }

            return 0;
        }

        public bool IsValidRebate()
        {
            if (rebate == null)
            {
                return false;
            }
            else if (product == null)
            {
                return false;
            }
            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate))
            {
                return false;
            }
            else if (rebate.Percentage == 0 || product.Price == 0 || request.Volume == 0)
            {
                return false;
            }

            return true;
        }
    }
}

