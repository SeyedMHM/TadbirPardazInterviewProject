import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductRoutingModule } from './product-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { ProductIndexComponent } from './components/index/product-index.component';
import { ProductViewComponent } from './components/view/product-view.component';
import { CreateOrUpdateProductComponent } from './components/create-or-update/create-or-update-product.component';


@NgModule({
    declarations: [
        ProductIndexComponent,
        ProductViewComponent,
        CreateOrUpdateProductComponent,
    ],
    imports: [
        CommonModule,
        ProductRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        MatSelectModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule,
        MatDialogModule
    ]
})
export class ProductModule { }
