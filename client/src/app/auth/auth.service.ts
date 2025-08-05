import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs'; 
import { Router } from '@angular/router';
import { LoginResponse } from '../core/models/login-response.model'; 

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7226/api/Users';
  private readonly TOKEN_KEY = 'jwt_token';

  constructor(private http: HttpClient, private router: Router) { }

  login(data: any): Observable<LoginResponse> { 
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, data).pipe( 
      tap(response => this.setToken(response.token)) 
    );
  }


  register(data: any): Observable<string> {
    return this.http.post<string>(`${this.apiUrl}/register`, data);
  }

  // Method to save the token
  private setToken(token: string): void {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  // Method to get the token
  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  // Method to check if user is logged in
  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  // Method for logging out
  logout(): void {
    localStorage.removeItem(this.TOKEN_KEY);
    this.router.navigate(['/auth/login']);
  }
}