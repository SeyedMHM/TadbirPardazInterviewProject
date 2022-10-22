import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateOrUpdateProductComponent } from './components/create-or-update/create-or-update-product.component';
import { ProductIndexComponent } from './components/index/product-index.component';
import { ProductViewComponent } from './components/view/product-view.component';

const routes: Routes = [
    { path: 'products', redirectTo: 'products/index', pathMatch: 'full' },
    { path: 'products/index', component: ProductIndexComponent },
    { path: 'products/view/:productId', component: ProductViewComponent },
    { path: 'products/create-or-update', component: CreateOrUpdateProductComponent },
    { path: 'products/create-or-update/:productId', component: CreateOrUpdateProductComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProductRoutingModule { }
