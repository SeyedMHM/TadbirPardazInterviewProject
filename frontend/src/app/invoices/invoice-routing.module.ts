import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateOrUpdateInvoiceComponent } from './components/create-or-update/create-or-update-invoice.component';
import { InvoiceIndexComponent } from './components/index/invoice-index.component';
import { InvoiceViewComponent } from './components/view/invoice-view.component';

const routes: Routes = [
    { path: 'invoices', redirectTo: 'invoices/index', pathMatch: 'full' },
    { path: 'invoices/index', component: InvoiceIndexComponent },
    { path: 'invoices/view/:invoiceId', component: InvoiceViewComponent },
    { path: 'invoices/create-or-update', component: CreateOrUpdateInvoiceComponent },
    { path: 'invoices/create-or-update/:invoiceId', component: CreateOrUpdateInvoiceComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class InvoiceRoutingModule { }
