import { Component} from '@angular/core';
import { PaymentOptionService, Banks } from './home.service';
import { PaymentOptions, Transaction } from './home.paymentoption';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public options: PaymentOptions[];
  public banks: Banks[];
  public selectedOption: string;
  public selectedBank: string;
  public IsBankSelected: boolean
  public IsCardSelected: boolean;
  public transaction: Transaction = <Transaction>{ }; 

  constructor(private service: PaymentOptionService) {
    this.service.getOptions().subscribe(result => {
      console.log(result);
      this.options = result;
    }, error => {
      console.error(error);
      });

    this.service.getBanks().subscribe(res => {
      this.banks =res
    },err=>console.log(err));

    this.selectedOption = "---select---";
    this.selectedBank = "---select---";

  }

  public changeSelection(option) {
    if (option == "Online Banking") {
      this.IsBankSelected = true;
      this.IsCardSelected = false;
    } else if (option == "Debit/Credit Card") {
      this.IsBankSelected = false;
      this.IsCardSelected = true;
    } else {
      this.IsBankSelected = false;
      this.IsCardSelected = false;
    }

    this.selectedOption = option;
  }

  public changeBank(bankname) {
   
    this.selectedBank = bankname;
  }


  public onClickSubmit(data) {
    console.log(data);
    console.log(this.transaction);
    if (this.selectedBank != "---select---") {
      this.transaction.BankName = this.selectedBank;
    }
    this.transaction.TransactionMethod = this.selectedOption;
    this.transaction.Amount = data.amount;
    this.transaction.CardNumber = data.cardnumber;
    this.transaction.CVV = data.cvv;
    this.transaction.MerchantId = data.merchantID;
    this.transaction.Reference = data.reference;

    //send request to API
    this.service.saveTransaction(this.transaction);
  }
}


