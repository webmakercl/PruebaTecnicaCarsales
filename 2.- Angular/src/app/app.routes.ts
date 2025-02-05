import { Routes } from '@angular/router';
import { EpisodeListComponent } from './components/episode-list/episode-list.component';
import { CharacterListComponent } from './components/character-list/character-list.component';

export const appRoutes: Routes = [
  { path: 'episodios', component: EpisodeListComponent },
  { path: 'personajes', loadComponent: () => import('./components/character-list/character-list.component').then(m => m.CharacterListComponent) },
  { path: '', redirectTo: '/episodios', pathMatch: 'full' }
];
