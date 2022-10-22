import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { InvoiceRoutingModule } from './invoice-routing.module';
import { InvoiceIndexComponent } from './components/index/invoice-index.component';
import { InvoiceViewComponent } from './components/view/invoice-view.component';
import { InvoiceCreateOrUpdateCommand } from './models/invoice-create-or-update-command';
import { CreateOrUpdateInvoiceComponent } from './components/create-or-update/create-or-update-invoice.component';

@NgModule({
    declarations: [
        InvoiceIndexComponent,
        InvoiceViewComponent,
        CreateOrUpdateInvoiceComponent,
    ],
    imports: [
        CommonModule,
        InvoiceRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        MatSelectModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule,
        MatDialogModule
    ]
})
export class InvoiceModule {}
