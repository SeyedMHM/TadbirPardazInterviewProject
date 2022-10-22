export interface IProductCreateOrUpdateCommand {
    id: number;
    title: string;
    price: number;
}

export class ProductCreateOrUpdateCommand implements IProductCreateOrUpdateCommand{
    id!: number;
    title!: string;
    price!: number;

    constructor() {
        this.setDefaultValue()
    }

    setCustomValue(data: Partial<ProductCreateOrUpdateCommand>) {
        Object.assign(this, data);
    }

    private setDefaultValue() {
        this.id = 0;
        this.title = "";
        this.price = 0;
    }
}