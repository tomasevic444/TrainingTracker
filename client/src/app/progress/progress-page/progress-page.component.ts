import { Component, OnInit } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { MaterialModule } from '../../material.module';
import { WorkoutService } from '../../dashboard/workout.service';
import { WeeklySummary } from '../../core/models/weekly-summary.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';

// For the month picker
import { MomentDateAdapter, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import moment from 'moment';

// This defines the format for the month picker display
export const MY_FORMATS = {
  parse: { dateInput: 'MM/YYYY' },
  display: {
    dateInput: 'MMMM YYYY',
    monthYearLabel: 'MMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY',
  },
};

@Component({
  selector: 'app-progress-page',
  standalone: true,
  imports: [CommonModule, MaterialModule, ReactiveFormsModule, DatePipe],
  templateUrl: './progress-page.component.html',
  styleUrls: ['./progress-page.component.scss'],
  providers: [
    // Providers for the month picker functionality
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS] },
    { provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
  ]
})
export class ProgressPageComponent implements OnInit {
  summaries: WeeklySummary[] = [];
  isLoading = true;
  selectedDate = new FormControl(moment());

  constructor(private workoutService: WorkoutService) {}

  ngOnInit(): void {
    this.fetchSummary();

    this.selectedDate.valueChanges.subscribe(() => {
      this.fetchSummary();
    });
  }

   fetchSummary(): void {
    const momentDate = this.selectedDate.value;
    if (!momentDate) return;

    this.isLoading = true;
    
    const year = momentDate.year(); 
    const month = momentDate.month() + 1;

    this.workoutService.getWeeklySummary(year, month).subscribe({
      next: (data) => {
        this.summaries = data;
        this.isLoading = false;
      },
      error: (err) => {
        this.isLoading = false;
      }
    });
  }

  monthSelected(momentDate: moment.Moment, datepicker: any): void {
    datepicker.close();
    this.selectedDate.setValue(momentDate);
  }
}