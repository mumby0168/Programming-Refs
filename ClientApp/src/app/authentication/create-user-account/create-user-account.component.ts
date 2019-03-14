import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CreateUserViewModel } from '../viewModels/createUser.viewModel';
import { Component, OnInit, Inject } from '@angular/core';
import "rxjs/add/operator/map";


@Component({
  selector: 'app-create-user-account',
  templateUrl: './create-user-account.component.html',
  styleUrls: ['./create-user-account.component.css']
})
export class CreateUserAccountComponent implements OnInit {

  model = new CreateUserViewModel('');

  public models: CreateUserViewModel[];

  constructor(public client: HttpClient, @Inject('BASE_URL') public baseUrl: string) { }

  headerOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json' })
  };

  ngOnInit() {
    console.log(this.baseUrl);
  }

  onSubmit() {
    console.log("post");
    console.log(this.diagnostics)
    this.client.post(this.baseUrl + 'api/Account/Create', this.diagnostics, this.headerOptions);
  }


  get diagnostics() {return JSON.stringify(this.model); }
}
