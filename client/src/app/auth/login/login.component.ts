import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms'; 
import { Router, RouterLink } from '@angular/router'; 
import { AuthService } from '../auth.service';
import { MaterialModule } from '../../material.module';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true, 
  imports: [        
    CommonModule,
    ReactiveFormsModule,
    MaterialModule,
    RouterLink // Allows us to use routerLink in the template
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      loginIdentifier: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  onSubmit(): void {
    if (this.loginForm.invalid) {
      return;
    }

    this.authService.login(this.loginForm.value).subscribe({
  next: (response) => {
    console.log('Login successful!', response);
    this.router.navigate(['/dashboard']); // Redirect to the dashboard
  },
  error: (err) => {
    console.error('Login failed', err);
    alert('Login Failed: ' + (err.error.message || 'Please try again'));
  }
});
  }
}