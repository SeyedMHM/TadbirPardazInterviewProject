import { IProductGetResponse, ProductGetResponse } from "src/app/products/models/product-get-response";

export interface IInvoiceDetailCreateOrUpdateCommand {
    productId: number;
    quantity: number;
    discountPercent: number;
}

export class InvoiceDetailCreateOrUpdateCommand implements IInvoiceDetailCreateOrUpdateCommand {
    productId!: number;
    quantity!: number;
    discountPercent!: number;
    
    productPrice!: number;
    productPriceWithDiscount!: number;
    sumOfProductPrice!: number;
    sumOfProductPriceWithoutDiscount!: number;
    customerProfitPerProduct!: number;
    sumOfCustomerProfit!: number;


    constructor() {
        this.setDefaultValue();
    }

    setCustomValue(data: Partial<InvoiceDetailCreateOrUpdateCommand>) {
        Object.assign(this, data);
    }

    private setDefaultValue() {
        this.productId = 0;
        this.quantity = 1;
        this.discountPercent = 0;
    }
}