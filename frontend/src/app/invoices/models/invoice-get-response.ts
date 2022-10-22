import { IInvoiceDetailGetResponse } from "./invoice-detail-get-response";

export interface IInvoiceGetResponse {
    id: number;
    issuedDate: string;
    issuedDatePersian: string;
    customerName: string;
    description: string;
    invoiceDetails: IInvoiceDetailGetResponse[];
    sumOfPrice: number;
    sumOfDiscount: number;
    finalAmount: number;
}

// export class InvoiceGetResponse implements IInvoiceGetResponse{
//     id!: number;
//     issuedDate!: string;
//     issuedDatePersian!: string;
//     customerName!: string;
//     description!: string;
//     invoiceDetails!: InvoiceDetailGetResponse[];
//     sumOfPrice!: number;
//     sumOfDiscount!: number;
//     finalAmount!: number;
// }
