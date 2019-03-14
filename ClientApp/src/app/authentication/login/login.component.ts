import { CurrentUser } from './../../user/current.user';
import { LoginViewModel } from './../viewModels/login.viewModel';
import { AuthenticationService } from './../services/authentication-service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authenticationService: AuthenticationService,
     private router: Router,
     private currentUser: CurrentUser) { }

  model = new LoginViewModel();

  ngOnInit() {
  }

  onSubmit()  {

      const result = this.authenticationService.login(this.model).subscribe(
        res => {
          if (res === true) {
            this.authenticationService.isAuthenticated = true;
            this.router.navigateByUrl('/inside/welcome');
            this.currentUser.email = this.model.email;
            this.authenticationService.setAuthCookie();
           }
        },
        error => {
          console.log(error.error);
        });
  }

}
