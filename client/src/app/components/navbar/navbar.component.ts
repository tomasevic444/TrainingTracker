import { Component } from '@angular/core';
import { RouterLink } from '@angular/router'; 
import { MaterialModule } from '../../material.module'; 
import { CommonModule } from '@angular/common'; 

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, MaterialModule, RouterLink], 
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
}