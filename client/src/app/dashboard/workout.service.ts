import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Workout } from '../core/models/workout.model'; 
import { CreateWorkoutCommand } from '../core/models/create-workout.model'; 
import { WeeklySummary } from '../core/models/weekly-summary.model';

@Injectable({
   providedIn: 'root' 
  })
export class WorkoutService {
  private apiUrl = 'https://localhost:7226/api/Workouts';

  constructor(private http: HttpClient) { }

  // Get all workouts for the logged-in user
  getWorkouts(): Observable<Workout[]> {
    return this.http.get<Workout[]>(this.apiUrl);
  }

  // Create a new workout
  createWorkout(workoutData: CreateWorkoutCommand): Observable<any> {
    return this.http.post(this.apiUrl, workoutData);
  }
  getWeeklySummary(year: number, month: number): Observable<WeeklySummary[]> {
    return this.http.get<WeeklySummary[]>(`${this.apiUrl}/summary`, {
      params: {
        year: year.toString(),
        month: month.toString()
      }
    });
  }
}