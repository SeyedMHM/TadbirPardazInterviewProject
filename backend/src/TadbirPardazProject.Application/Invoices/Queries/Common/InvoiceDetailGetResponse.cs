namespace TadbirPardazProject.Application.Invoices.Queries.Common
{
    public class InvoiceDetailGetResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }//قیمت واحد بدون احتساب تخفیف

        byte _discountPercent;
        public byte DiscountPercent
        {
            get
            {
                return (_discountPercent < 0 && _discountPercent > 100)
                    ? throw new ArgumentOutOfRangeException("مقدار 'درصد تخفیف' نمی تواند کمتر از 0 یا بیشتر از 100 درصد باشد")
                    : _discountPercent;
            }
            set => _discountPercent = value;
        }
        public decimal ProductPriceWithDiscount => ProductPrice - (ProductPrice * _discountPercent / 100);//قیمت واحد با احتساب تخفیف
        public decimal SumOfProductPrice => ProductPrice * Quantity;//قیمت سرجمع کالا بدون احتساب تخفیف
        public decimal SumOfProductPriceWithoutDiscount => SumOfProductPrice - (SumOfProductPrice * _discountPercent / 100);//قیمت سرجمع کالا با احتساب تخفیف
        public decimal CustomerProfitPerProduct => ProductPrice - ProductPriceWithDiscount;//سود مشتری از تخفیف واحد
        public decimal SumOfCustomerProfit => SumOfProductPrice - SumOfProductPriceWithoutDiscount;//سود مشتری از تخفیف کل:
    }
}
