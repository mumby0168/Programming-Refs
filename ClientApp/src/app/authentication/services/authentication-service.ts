import { CookieService } from 'angular2-cookie/services/cookies.service';
import { LoginViewModel } from './../viewModels/login.viewModel';
import { CreateUserViewModel } from './../viewModels/createUser.viewModel';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { stringify } from '@angular/core/src/render3/util';
import "rxjs/add/operator/map";
import { createOfflineCompileUrlResolver, ThrowStmt, flatten } from '@angular/compiler';
import { CookieOptions } from 'angular2-cookie/services/base-cookie-options';

@Injectable()
export class AuthenticationService{
      constructor(private client: HttpClient, @Inject('BASE_URL') private baseUrl: string, private cookieService: CookieService) {
          this.checkCookie();
      }

      headerOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json' })
      };

      public isAuthenticated: Boolean;

      public checkCookie() {
        const cookie = this.cookieService.get('auth');
        console.log(cookie);
        if (cookie !== undefined) { this.isAuthenticated = true; } else { this.isAuthenticated = false; }
      }

      public login(loginViewModel: LoginViewModel)  {
            return this.client.post(this.baseUrl + 'api/Account/' + 'Login', JSON.stringify(loginViewModel),
             this.headerOptions);
      }

      public logout() {
        this.cookieService.remove('auth');
          return this.client.post(this.baseUrl + 'api/Account/Logout', null, this.headerOptions);
      }

      public createUser(createUserViewModel: CreateUserViewModel): Observable<any> {
            return this.client.post(this.baseUrl + 'api/Account/' + 'Create', JSON.stringify(createUserViewModel), this.headerOptions);
      }

      public setAuthCookie() {
        const date = new Date();
        date.setMinutes(date.getMinutes() + 30);

        this.cookieService.put("auth", "true", new CookieOptions({
          expires: date
        }));
      }
}
