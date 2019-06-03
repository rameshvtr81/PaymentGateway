import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PaymentOptions, Transaction } from './home.paymentoption';
import { Observable, of } from 'rxjs';
@Injectable({
  providedIn: 'root',
})

export class PaymentOptionService {
  public _baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  public getOptions(): Observable<PaymentOptions[]> {
    return this.http.get<PaymentOptions[]>(this._baseUrl + 'api/PaymentOption/');
  }


  public getBanks(): Observable<Banks[]> {
    return this.http.get<Banks[]>(this._baseUrl + 'api/banks/');
  }

  public saveTransaction(data: Transaction) {
    console.log('data',data);
    this.http.post(this._baseUrl + 'api/Transaction/', data).subscribe(res => {
    console.log('successfull')},err=>console.log(err));
  }
}

export interface Banks {
  Id: number,
  Name: string
}



