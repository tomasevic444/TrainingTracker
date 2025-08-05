import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

export const AUTH_ROUTES: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent }
    // You can add a default redirect within this module too if you want
    // { path: '', redirectTo: 'login', pathMatch: 'full' }
];