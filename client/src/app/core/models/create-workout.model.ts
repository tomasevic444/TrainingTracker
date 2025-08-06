export interface CreateWorkoutCommand { 
    exerciseType: string;
    durationInMinutes: number;
    caloriesBurned: number;
    intensity: number;
    fatigue: number;
    notes?: string;
    date: Date;
}