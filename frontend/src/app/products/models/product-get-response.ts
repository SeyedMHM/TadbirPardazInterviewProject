export interface IProductGetResponse {
    id: number;
    title: string;
    price: number;
}
export class ProductGetResponse implements IProductGetResponse {
    id!: number;
    title!: string;
    price!: number;

    constructor() {
        this.setDefaultValue();
    }

    setCustomValue(data: Partial<ProductGetResponse>) {
        Object.assign(this, data);
    }

    private setDefaultValue() {
        this.id = 0;
        this.title = "";
        this.price = 0;
    }
}