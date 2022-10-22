import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IInvoiceCreateOrUpdateCommand } from './models/invoice-create-or-update-command';
import { SharedService } from '../common/services/shared.service';

@Injectable({
    providedIn: 'root'
})
export class InvoiceService extends SharedService<IInvoiceCreateOrUpdateCommand>{

    constructor(private httpClient:HttpClient) {
        super();
        super.apiURL = "https://localhost:7122/Invoices/";
        super.httpClientService = httpClient;
    }
}