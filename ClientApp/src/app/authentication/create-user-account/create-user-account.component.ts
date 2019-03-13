import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CreateUserViewModel } from '../viewModels/createUser.viewModel';
import { Component, OnInit, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';


@Component({
  selector: 'app-create-user-account',
  templateUrl: './create-user-account.component.html',
  styleUrls: ['./create-user-account.component.css']
})
export class CreateUserAccountComponent implements OnInit {

  model = new CreateUserViewModel('');

  public models: CreateUserViewModel[];

  constructor(public client: HttpClient, @Inject('BASE_URL') public baseUrl: string) { }

  header = new HttpHeaders({
    'Content-Type': 'application/json'
  });

  headerOptions = {
    headers: this.header
  };

  ngOnInit() {
    console.log(this.baseUrl);

    this.client.get<CreateUserViewModel[]>(this.baseUrl + 'api/Account/GetUsers').subscribe(result => {
      this.models = result;
    }, error => console.error(error));
  }

  onSubmit() {
    console.log("post");
    console.log(this.diagnostics)
    this.client.post(this.baseUrl + 'api/Account/Create', this.diagnostics, this.headerOptions).subscribe(res => console.log(res));
  }


  get diagnostics() {return JSON.stringify(this.model); }
}
