import { Component, OnInit, ViewContainerRef } from '@angular/core';

import { Customer } from '../models/Customer';
import { MatDialog } from '@angular/material/dialog';
import { CustomerInfoService } from '../services/customer-info.service';
import { AddCustomerDialogComponent } from '../add-customer-dialog/add-customer-dialog.component';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss']
})
export class CustomerListComponent implements OnInit {

  public customersColumns: (keyof Customer)[] = ['customerName', 'countryName'];
  public customers: Customer[] = [];

  constructor(
    private customerInfoService: CustomerInfoService,
    private dialog: MatDialog) {
  }

  public async ngOnInit() {
    await this.initCustomers();
  }

  public async add() {
    const result = await this.dialog
      .open(AddCustomerDialogComponent, {
        width: '500px'
      })
      .afterClosed()
      .toPromise();

    if (result) {
      await this.initCustomers();
    }
  }

  private async initCustomers() {
    this.customers = await this.customerInfoService
      .getCustomers()
      .toPromise();
  }

}
