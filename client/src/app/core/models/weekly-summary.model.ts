export interface WeeklySummary {
    weekNumber: number;
    weekStartDate: Date;
    weekEndDate: Date;
    totalDurationInMinutes: number;
    totalWorkouts: number;
    averageIntensity: number;
    averageFatigue: number;
}