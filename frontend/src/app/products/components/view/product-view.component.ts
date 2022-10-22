import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiResult } from 'src/app/common/models/api-Result';
import { IProductGetResponse } from '../../models/product-get-response';
import { ProductService } from '../../product.service';

@Component({
    selector: 'product-view',
    templateUrl: './product-view.component.html',
    styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent implements OnInit {

    id!: number;
    productGetResponse!: IProductGetResponse;

    constructor(
        public productService: ProductService,
        private route: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.id = this.route.snapshot.params['productId'];

        this.productService.get(this.id).subscribe((result: ApiResult) => {
            this.productGetResponse = result.data;
        });
    }
}