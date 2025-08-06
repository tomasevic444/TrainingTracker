import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkoutService } from '../workout.service';
import { Workout } from '../../core/models/workout.model';
import { MaterialModule } from '../../material.module';


@Component({
  selector: 'app-dashboard-page',
  standalone: true,
  imports: [CommonModule, MaterialModule], 
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss']
})
export class DashboardPageComponent implements OnInit {
  workouts: Workout[] = [];
  isLoading = true;

  constructor(private workoutService: WorkoutService) {}

  ngOnInit(): void {
    this.loadWorkouts();
  }

  loadWorkouts(): void {
    this.isLoading = true;
    this.workoutService.getWorkouts().subscribe({
      next: (data) => {
        this.workouts = data;
        this.isLoading = false;
        console.log('Workouts loaded', this.workouts);
      },
      error: (err) => {
        console.error('Failed to load workouts', err);
        this.isLoading = false;
      }
    });
  }

  getIconForExercise(type: string): string {
  switch (type.toLowerCase()) {
    case 'cardio': return 'directions_run';
    case 'strength': return 'fitness_center';
    case 'flexibility': return 'self_improvement';
    default: return 'exercise';
  }
}
}