import { Component, OnInit } from '@angular/core';
import { ApiResult } from 'src/app/common/models/api-Result';
import { SelectItem } from 'src/app/common/models/select-item';
import { PagedListMetadata } from 'src/app/common/pagination/models/paged-list-metadata';
import { IProductGetResponse } from '../../models/product-get-response';
import { ProductService } from '../../product.service';

@Component({
    selector: 'product-index',
    templateUrl: './product-index.component.html',
    styleUrls: ['./product-index.component.css']
})
export class ProductIndexComponent implements OnInit {
    pageId: number = 1;
    pageSize: number = 5;

    products: IProductGetResponse[] = [];
    productCount!: number;
    paginationData!: PagedListMetadata;

    pageSizes: SelectItem[] = [
        { id: 5, text: "5" },
        { id: 10, text: "10" },
        { id: 20, text: "20" },
        { id: 50, text: "50" },
    ];

    constructor(
        public productService: ProductService) { }

    ngOnInit(): void {
        this.getPagedListData();
    }

    deleteProduct(product: IProductGetResponse) {
        if (confirm(`از حذف '${product.title}' مطمئن هستید؟`)) {
            this.productService.delete(product.id).subscribe(res => {
                this.products = this.products.filter(item => item.id !== product.id);
                alert("عملیات حذف با موفقیت انجام شد");
            });
        }
    }


    getPagedListData() {
        this.productService.getPagedList(this.pageId, this.pageSize)
            .subscribe((result: ApiResult) => {
                this.products = result.data.items;
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