import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiResult } from 'src/app/common/models/api-Result';
import { InvoiceService } from '../../invoice.service';
import { IInvoiceGetResponse } from '../../models/invoice-get-response';

@Component({
    selector: 'invoice-view',
    templateUrl: './invoice-view.component.html',
    styleUrls: ['./invoice-view.component.css']
})
export class InvoiceViewComponent implements OnInit {

    id!: number;
    invoiceGetResponse!: IInvoiceGetResponse;

    constructor(
        public invoiceService: InvoiceService,
        private route: ActivatedRoute
    ) { }

    ngOnInit(): void {
        this.id = this.route.snapshot.params['invoiceId'];

        this.invoiceService.get(this.id).subscribe((result: ApiResult) => {
            this.invoiceGetResponse = result.data;
        });
    }
}