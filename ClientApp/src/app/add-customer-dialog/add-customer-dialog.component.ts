import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { CustomerInfoService } from '../services/customer-info.service';
import { Customer } from '../models/Customer';
import { Country } from '../models/Country';

@Component({
  selector: 'app-add-customer-dialog',
  templateUrl: './add-customer-dialog.component.html',
  styleUrls: ['./add-customer-dialog.component.scss']
})
export class AddCustomerDialogComponent implements OnInit {

  public editForm: FormGroup;

  public countries: Country[] = [];

  constructor(
    private dialogRef: MatDialogRef<AddCustomerDialogComponent>,
    private customerInfoService: CustomerInfoService) {
  }

  public async ngOnInit() {
    await this.init();
  }

  public onCancel() {
    this.dialogRef.close();
  }

  public onSave() {
    const country: Country = this.editForm.value.country;

    const customer: Customer = {
      customerId: undefined,
      customerName: this.editForm.value.customerName,
      countryId: country.countryId,
      countryName: country.countryName
    };

    this.customerInfoService.addCustomer(customer)
      .subscribe(res => this.dialogRef.close(res));
  }

  private async init() {
    this.countries = await this.customerInfoService.getCountries().toPromise();

    this.editForm = new FormGroup({
      customerName: new FormControl('', Validators.required),
      country: new FormControl('', Validators.required)
    });
  }

}
