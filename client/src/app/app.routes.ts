import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: '/auth/login', pathMatch: 'full' },
  
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.routes').then(routes => routes.AUTH_ROUTES)
  },
{
  path: 'dashboard',
  loadChildren: () => import('./dashboard/dashboard.routes').then(r => r.DASHBOARD_ROUTES)
},
{
  path: 'progress',
  loadChildren: () => import('./progress/progress.routes').then(r => r.PROGRESS_ROUTES)
},

  { path: '**', redirectTo: '/auth/login' }
];