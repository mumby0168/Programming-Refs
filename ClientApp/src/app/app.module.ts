import { CurrentUser } from './user/current.user';
import { AuthenticationModule } from './authentication/authentication.module';
import { WelcomeComponent } from './welcome/welcome.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule } from'@angular/forms';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CreateUserAccountComponent } from './authentication/create-user-account/create-user-account.component';
import { LoginComponent } from '././authentication/login/login.component';
import { AutheticationGuard } from './authentication/authentication.guard';
import { CookieService } from 'angular2-cookie/services/cookies.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CreateUserAccountComponent,
    LoginComponent,
    WelcomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    AuthenticationModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'account/create', component: CreateUserAccountComponent },
      { path: 'account/login', component: LoginComponent},
      // Once Logged in
      { path: 'inside', canActivateChild: [AutheticationGuard], children: [
        { path: 'welcome', component: WelcomeComponent}
      ]}
    ])
  ],
  providers: [
    AutheticationGuard,
    CurrentUser,
    CookieService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
