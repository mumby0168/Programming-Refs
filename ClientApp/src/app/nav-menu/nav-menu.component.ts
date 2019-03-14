import { Router } from '@angular/router';
import { CurrentUser } from './../user/current.user';
import { AuthenticationService } from './../authentication/services/authentication-service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(public authService: AuthenticationService, public currentUser: CurrentUser, private router: Router) {}

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.authService.logout().subscribe(
      res => {
        if (res) {
          this.router.navigateByUrl('/account/login');
          this.authService.isAuthenticated = false;
          this.currentUser.email = '';
        }
      },
      error => console.log(error.error));
  }
}
