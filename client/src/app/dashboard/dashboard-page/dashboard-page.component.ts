import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkoutService } from '../workout.service';
import { Workout } from '../../core/models/workout.model';
import { MaterialModule } from '../../material.module';
import { MatDialog } from '@angular/material/dialog';
import { AddWorkoutDialogComponent } from '../add-workout-dialog/add-workout-dialog.component';
import { CreateWorkoutCommand } from '../../core/models/create-workout.model';
import { NotificationService } from '../../core/notification.service';

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

  constructor(
    private workoutService: WorkoutService,
    public dialog: MatDialog,
    private notificationService: NotificationService
  ) { }

  ngOnInit(): void {
    this.loadWorkouts();
  }

  loadWorkouts(): void {
    this.isLoading = true;
    this.workoutService.getWorkouts().subscribe({
      next: (data) => {
        this.workouts = data;
        this.isLoading = false;
      },
      error: (err) => {
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
  openAddWorkoutDialog(): void {
    const dialogRef = this.dialog.open(AddWorkoutDialogComponent, {
      width: '500px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.saveWorkout(result);
      }
    });
  }

  private saveWorkout(workoutData: CreateWorkoutCommand): void {
    this.workoutService.createWorkout(workoutData).subscribe({
      next: () => {
        this.notificationService.showSuccess('Workout Added!');
        this.loadWorkouts();
      },
      error: (err) => {
        this.notificationService.showError('Error saving workout.');
      }
    });
  }
}