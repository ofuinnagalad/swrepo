namespace Smartwyre.DeveloperTest.Types
{
    public class AmountPerUomRebate: IRebateType
	{
        readonly Rebate rebate;
        readonly Product product;
        readonly CalculateRebateRequest request;
        decimal rebateAmount;

        public AmountPerUomRebate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            this.rebate = rebate;
            this.product = product;
            this.request = request;
        }

        public decimal CalculateRebateAmount()
        {
            if (rebate != null && request != null)
            {
                rebateAmount = rebate.Amount * request.Volume;

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
            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom))
            {
                return false;
            }
            else if (rebate.Amount == 0 || request.Volume == 0)
            {
                return false;
            }

            return true;
        }

    }
}

