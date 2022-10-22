import { Component, OnInit } from '@angular/core';
import { ApiResult } from 'src/app/common/models/api-Result';
import { SelectItem } from 'src/app/common/models/select-item';
import { IPagedListMetadata } from 'src/app/common/pagination/models/paged-list-metadata';
import { InvoiceService } from '../../invoice.service';
import { IInvoiceGetResponse } from '../../models/invoice-get-response';

@Component({
    selector: 'invoice-index',
    templateUrl: './invoice-index.component.html',
    styleUrls: ['./invoice-index.component.css']
})
export class InvoiceIndexComponent implements OnInit {
    pageId: number = 1;
    pageSize: number = 5;
    paginationData!: IPagedListMetadata;
    pageSizes: SelectItem[] = [
        { id: 5, text: "5" },
        { id: 10, text: "10" },
        { id: 20, text: "20" },
        { id: 50, text: "50" },
    ];

    invoiceGetResponses: IInvoiceGetResponse[] = [];

    constructor(
        public invoiceService: InvoiceService) { }

    ngOnInit(): void {
        this.getPagedListData();
    }

    deleteInvoice(invoiceGetResponse: IInvoiceGetResponse) {
        if (confirm(`از حذف '${invoiceGetResponse.id}' مطمئن هستید؟`)) {
            this.invoiceService.delete(invoiceGetResponse.id).subscribe(res => {
                this.invoiceGetResponses = this.invoiceGetResponses.filter(item => item.id !== invoiceGetResponse.id);
                alert("عملیات حذف با موفقیت انجام شد");
            });
        }
    }


    getPagedListData() {
        this.invoiceService.getPagedList(this.pageId, this.pageSize)
            .subscribe((result: ApiResult) => {
                this.invoiceGetResponses = result.data.items;
                this.paginationData = result.data;
            });
    }

    getPrevious() {
        if (this.pageId > 1) {
            this.pageId -= 1;
            this.getPagedListData();
        }
    }

    getNext() {
        if (this.pageId < this.paginationData.totalPages) {
            this.pageId += 1;
            this.getPagedListData();
        }
    }

    getDataWithPageId(pageId: number) {
        this.pageId = pageId;
        this.getPagedListData();
    }

    changePageSize() {
        this.pageId = 1;
        this.getPagedListData();
    }
}