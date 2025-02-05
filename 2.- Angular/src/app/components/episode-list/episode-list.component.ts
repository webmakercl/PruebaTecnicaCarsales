import { Component, OnInit, Signal, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EpisodeService } from '../../services/episode.service';

@Component({
  selector: 'app-episode-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './episode-list.component.html',
  styleUrls: ['./episode-list.component.css']
})
export class EpisodeListComponent implements OnInit {

  //Declaracion de variables
  episodes = signal<any[]>([]); 
  loading = signal(false); 
  errorMessage = signal(''); 
  currentPage = signal(1);
  totalPages = signal(''); 
  prevPageUrl = signal<string | null>(null); 
  nextPageUrl = signal<string | null>(null); 
  selectedEpisode = signal<any | null>(null); 
  selectedCharacter = signal<any | null>(null);


  constructor(private episodeService: EpisodeService) { }

  //Metodo de carga inicial
  ngOnInit(): void {
    this.loadEpisodes();
  }

  //Metodo para cargar los episodios desde la api
  loadEpisodes(pageUrl?: string): void {
    this.loading.set(true);
    let apiUrl = pageUrl || 'https://rickandmortyapi.com/api/episode';


    this.episodeService.getEpisodes(apiUrl).subscribe({
      next: (data) => {
        this.episodes.set(data.results);
        this.prevPageUrl.set(data.info.prev);
        this.nextPageUrl.set(data.info.next);
        this.totalPages.set(data.info.pages);
        this.currentPage.set(pageUrl ? this.extractPageNumber(pageUrl) : 1);
        this.loading.set(false);
      },
      error: () => {
        this.errorMessage.set('Error al cargar episodios');
        this.loading.set(false);
      }
    });
  }

  //Metodo para saber el numero de pagina actual
  extractPageNumber(url: string): number {
    const match = url.match(/page=(\d+)/);
    return match ? parseInt(match[1], 10) : 1;
  }

  //Modal para el detalle del episodio
  openModal(episode: any): void {
    this.selectedEpisode.set(episode);
  }

  //Cierro el modal
  closeModal(): void {
    this.selectedEpisode.set(null);
    this.errorMessage.set('');
  }

  //Metodo para modal del personaje una vez seleccionado un episodio
  openCharacterModal(character: any): void {
    this.selectedCharacter.set(character);
    console.log(this.selectedCharacter);
  }

  //Metodo para cerrar el modal del personaje del capitulo seleccionado
  closeCharacterModal(): void {
    this.selectedCharacter.set(null);
  }

  //Metodo para reintentar
  retry(): void {
    this.errorMessage.set('');
    this.loadEpisodes(); 
  }
}
