import { Component } from '@angular/core';
import { RouterLink } from '@angular/router'; 
import { MaterialModule } from '../../material.module'; 
import { CommonModule } from '@angular/common'; 
import { AuthService } from '../../auth/auth.service';
@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, MaterialModule, RouterLink], 
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  constructor(public authService: AuthService) { } 

  logout(): void {
    this.authService.logout();
  }
}