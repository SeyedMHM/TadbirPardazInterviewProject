export interface IInvoiceDetailGetResponse {
    id: number;
    productId: number;
    productTitle: string;
    quantity: number;
    productPrice: number;
    discountPercent: number;
    productPriceWithDiscount: number;
    sumOfProductPrice: number;
    sumOfProductPriceWithoutDiscount: number;
    customerProfitPerProduct: number;
    sumOfCustomerProfit: number;
}
// export class InvoiceDetailGetResponse implements IInvoiceDetailGetResponse {
//     id!: number;
//     productId!: number;
//     productTitle!: string;
//     quantity!: number;
//     productPrice!: number;
//     discountPercent!: number;
//     productPriceWithDiscount!: number;
//     sumOfProductPrice!: number;
//     sumOfProductPriceWithoutDiscount!: number;
//     customerProfitPerProduct!: number;
//     sumOfCustomerProfit!: number;
// }