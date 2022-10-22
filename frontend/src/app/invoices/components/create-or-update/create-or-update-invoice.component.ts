import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiResult } from 'src/app/common/models/api-Result';
import { IProductGetResponse } from 'src/app/products/models/product-get-response';
import { ProductService } from 'src/app/products/product.service';
import { InvoiceService } from '../../invoice.service';
import { InvoiceCreateOrUpdateCommand } from '../../models/invoice-create-or-update-command';
import { InvoiceDetailCreateOrUpdateCommand } from '../../models/invoice-detail-create-or-update-command';

@Component({
    selector: 'create-or-update-invoice',
    templateUrl: './create-or-update-invoice.component.html',
    styleUrls: ['./create-or-update-invoice.component.css']
})
export class CreateOrUpdateInvoiceComponent implements OnInit {

    model!: InvoiceCreateOrUpdateCommand;
    products: IProductGetResponse[] = [];
    constructor(
        public invoiceService: InvoiceService,
        private route: ActivatedRoute,
        private router: Router,
        private productService: ProductService
    ) { }

    ngOnInit(): void {
        this.model = new InvoiceCreateOrUpdateCommand();
        this.model.id = this.route.snapshot.params['invoiceId'];
        this.productService.getAll().subscribe((result: ApiResult) => {
            this.products = result.data;
        });

        if (this.model.id) {
            this.invoiceService.get(this.model.id).subscribe((result: ApiResult) => {
                this.model = result.data;
            });
        }
    }

    save() {
        if (this.model.id) {
            this.invoiceService.update(this.model).subscribe((res: any) => {
                this.router.navigateByUrl('invoices/index');
            });
        }
        else {
            this.invoiceService.create(this.model).subscribe((res: any) => {
                this.router.navigateByUrl('invoices/index');
            });
        }
    }
    addProduct() {
        let newDetail = new InvoiceDetailCreateOrUpdateCommand();
        this.model.invoiceDetails.push(newDetail);
    }

    removeProduct(invoiceDetails: InvoiceDetailCreateOrUpdateCommand) {
        debugger;
        const index = this.model.invoiceDetails.indexOf(invoiceDetails);
        if (index > -1) {
            this.model.invoiceDetails.splice(index, 1);
        }
    }

    calculateRow(invoiceDetails: InvoiceDetailCreateOrUpdateCommand) {
        let product = this.products.filter(q => q.id == invoiceDetails.productId)[0];

        invoiceDetails.productPrice = product.price;
        invoiceDetails.productPriceWithDiscount = product.price - (product.price * invoiceDetails.discountPercent / 100);
        invoiceDetails.sumOfProductPrice = product.price * invoiceDetails.quantity;
        invoiceDetails.sumOfProductPriceWithoutDiscount = invoiceDetails.sumOfProductPrice - (invoiceDetails.sumOfProductPrice * invoiceDetails.discountPercent / 100);
        invoiceDetails.customerProfitPerProduct = product.price - invoiceDetails.productPriceWithDiscount;
        invoiceDetails.sumOfCustomerProfit = invoiceDetails.sumOfProductPrice - invoiceDetails.sumOfProductPriceWithoutDiscount;

        this.model.invoiceDetails.forEach(item => {
            if (item.productId) {
                this.model.sumOfPrice += item.sumOfProductPrice;
                this.model.sumOfDiscount += item.sumOfCustomerProfit;
            }
        });

        this.model.finalAmount = this.model.sumOfPrice - this.model.sumOfDiscount;
    }
}