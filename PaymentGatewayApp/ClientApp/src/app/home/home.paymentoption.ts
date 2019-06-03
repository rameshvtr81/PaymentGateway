export interface PaymentOptions {
  Id: number;
  Name: string;
}


export interface Transaction {
  Id: number;
  TransactionMethod: string;
  CardNumber: number;
  CVV: number;
  BankName: string
  Amount: number;
  Reference: string;
  MerchantId:string
}
