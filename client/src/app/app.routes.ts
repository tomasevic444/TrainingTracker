import { Routes } from '@angular/router';

export const routes: Routes = [
    // Redirect the base URL to the login page by default
    { path: '', redirectTo: '/auth/login', pathMatch: 'full' },

    // Lazy-load the AuthModule for any routes starting with 'auth'
    {
        path: 'auth',
        loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)
    },

    // Lazy-load the DashboardModule for the 'dashboard' route
    {
        path: 'dashboard',
        loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
    },

    // Lazy-load the ProgressModule for the 'progress' route
    {
        path: 'progress',
        loadChildren: () => import('./progress/progress.module').then(m => m.ProgressModule)
    },

    // Optional: Add a "wildcard" route to handle any URLs that don't match
    { path: '**', redirectTo: '/auth/login' }
];