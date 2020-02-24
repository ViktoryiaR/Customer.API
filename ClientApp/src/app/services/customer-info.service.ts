import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Customer } from '../models/Customer';
import { Country } from '../models/Country';

@Injectable()
export class CustomerInfoService {

  constructor(
    private httpClient: HttpClient,
    @Inject('BASE_API_URL') private baseUrl: string) { }

  getCustomers(): Observable<Customer[]> {
    const url = `${this.baseUrl}/api/customers`;
    return this.httpClient.get(url).pipe(
      map((body: any) => body),
      catchError(err => throwError(err))
    );
  }

  getCountries(): Observable<Country[]> {
    const url = `${this.baseUrl}/api/countries`;
    return this.httpClient.get(url).pipe(
      map((body: any) => body),
      catchError(err => throwError(err))
    );
  }

  addCustomer(customer: Customer): Observable<Customer> {
    const url = `${this.baseUrl}/api/customers`;
    return this.httpClient.post(url, customer).pipe(
      map((body: any) => body),
      catchError(err => throwError(err))
    );
  }
}

