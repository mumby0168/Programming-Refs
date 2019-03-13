
import { NgModule } from "@angular/core";
import { AutheticationGuard } from "./authentication.guard";
import { AuthenticationService } from './services/authentication-service';

@NgModule({
    providers: [AutheticationGuard, AuthenticationService]
})
export class AuthenticationModule {}
