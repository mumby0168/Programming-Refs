import { AuthenticationService } from './services/authentication-service';
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

@Injectable()
export class AutheticationGuard {

  constructor(private authenticationService: AuthenticationService, private router: Router) {}

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

    this.authenticationService.checkCookie();

    if (this.authenticationService.isAuthenticated) {
      return true;
    } else {
      console.log('redirecting')
      this.router.navigateByUrl('/account/login');
    }

  }

}
