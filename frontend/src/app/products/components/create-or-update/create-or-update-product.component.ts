import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiResult } from 'src/app/common/models/api-Result';
import { ProductCreateOrUpdateCommand } from '../../models/product-create-or-update-command';
import { ProductService } from '../../product.service';

@Component({
    selector: 'create-or-update-product',
    templateUrl: './create-or-update-product.component.html',
    styleUrls: ['./create-or-update-product.component.css']
})
export class CreateOrUpdateProductComponent implements OnInit {

    model!: ProductCreateOrUpdateCommand;

    constructor(
        public productService: ProductService,
        private route: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.model = new ProductCreateOrUpdateCommand();
        this.model.id = this.route.snapshot.params['productId'];

        if (this.model.id) {
            this.productService.get(this.model.id).subscribe((result: ApiResult) => {
                this.model = result.data;
            });
        }
    }

    save() {
        if (this.model.id) {
            this.productService.update(this.model).subscribe((res: any) => {
                this.router.navigateByUrl('products/index');
            });
        }
        else {
            this.productService.create(this.model).subscribe((res: any) => {
                this.router.navigateByUrl('products/index');
            });
        }
    }
}