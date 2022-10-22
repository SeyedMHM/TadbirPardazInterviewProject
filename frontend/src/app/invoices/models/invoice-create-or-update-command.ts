import { IInvoiceDetailCreateOrUpdateCommand, InvoiceDetailCreateOrUpdateCommand } from "./invoice-detail-create-or-update-command";

export interface IInvoiceCreateOrUpdateCommand {
    id: number;
    issuedDate: Date;
    issuedDatePersian: string;
    customerName: string;
    description: string | null;
    invoiceDetails: IInvoiceDetailCreateOrUpdateCommand[];
    sumOfPrice: number;
    sumOfDiscount: number;
    finalAmount: number;
}

export class InvoiceCreateOrUpdateCommand implements IInvoiceCreateOrUpdateCommand {
    id!: number;
    issuedDate!: Date;
    issuedDatePersian!: string;
    customerName!: string;
    description!: string | null;
    invoiceDetails!: InvoiceDetailCreateOrUpdateCommand[];
    sumOfPrice!: number;
    sumOfDiscount!: number;
    finalAmount!: number;

    constructor() {
        this.setDefaultValue();
    }

    setCustomValue(data: Partial<InvoiceCreateOrUpdateCommand>) {
        Object.assign(this, data);
    }

    private setDefaultValue() {
        this.id = 0;
        this.issuedDate = new Date();
        this.customerName = "";
        this.description = null;
        this.invoiceDetails = [new InvoiceDetailCreateOrUpdateCommand()];
        this.sumOfPrice = 0;
        this.sumOfDiscount = 0;
        this.finalAmount = 0;
    }
}