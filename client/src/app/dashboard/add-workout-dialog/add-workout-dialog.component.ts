import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MaterialModule } from '../../material.module';
import { MatDialogRef } from '@angular/material/dialog'; 

@Component({
  selector: 'app-add-workout-dialog',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MaterialModule],
  templateUrl: './add-workout-dialog.component.html',
  styleUrls: ['./add-workout-dialog.component.scss']
})
export class AddWorkoutDialogComponent {
  workoutForm: FormGroup;
  maxDate: Date; 
  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<AddWorkoutDialogComponent> 
  ) {
    this.maxDate = new Date(); 
    
    this.workoutForm = this.fb.group({
      exerciseType: ['Cardio', Validators.required],
      durationInMinutes: [30, [Validators.required, Validators.min(1)]],
      caloriesBurned: [200, [Validators.required, Validators.min(0)]],
      intensity: [5, [Validators.required, Validators.min(1), Validators.max(10)]],
      fatigue: [5, [Validators.required, Validators.min(1), Validators.max(10)]],
      notes: [''],
      date: [new Date(), Validators.required]
    });
  }

  onCancel(): void {
    this.dialogRef.close(); 
  }

  onSave(): void {
    if (this.workoutForm.invalid) {
      return;
    }
    this.dialogRef.close(this.workoutForm.value); 
  }
}