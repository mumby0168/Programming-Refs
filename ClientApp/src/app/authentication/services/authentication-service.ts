import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthenticationService{
      constructor(private client: HttpClient) {}

      public isAuthenticated = false;

      public login(loginViewModel: any)  {
            // do some code


            // TODO: Remove allowing login all the time
            this.isAuthenticated = false;
      }

      public logout() {

      }
}
