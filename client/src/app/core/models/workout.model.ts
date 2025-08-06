export interface Workout  { 
    id: string;
    exerciseType: string;
    durationInMinutes: number;
    caloriesBurned: number;
    intensity: number;
    fatigue: number;
    notes?: string;
    date: Date;
}