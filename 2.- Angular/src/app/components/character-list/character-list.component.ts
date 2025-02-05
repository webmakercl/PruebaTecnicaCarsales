import { Component, OnInit, Signal, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-character-list',
  standalone: true, 
  imports: [CommonModule],
  templateUrl: './character-list.component.html',
  styleUrls: ['./character-list.component.css']
})
export class CharacterListComponent implements OnInit {

  //Declaracion de variables
  characters = signal<any[]>([]); 
  loading = signal(false); 
  errorMessage = signal(''); 
  currentPage = signal(1); 
  totalPages = signal(1); 
  prevPageUrl = signal<string | null>(null);
  nextPageUrl = signal<string | null>(null); 
  showModal = signal(false); 

  //Constructor
  constructor(private http: HttpClient) { }

  // Metodo inicial de carga
  ngOnInit(): void {
    this.loadCharacters();
  }

  //Metodo para cargar los personajes desde la api
  loadCharacters(pageUrl?: string | null): void {
    this.loading.set(true);

    let apiUrl = pageUrl || 'http://localhost:5000/api/v1/Character';

    this.http.get<any>(apiUrl).subscribe({
      next: (data) => {
        this.characters.set(data.results);
        this.prevPageUrl.set(data.info.prev);
        this.nextPageUrl.set(data.info.next);
        this.totalPages.set(data.info.pages);
        this.currentPage.set(pageUrl ? this.extractPageNumber(pageUrl) : 1);
        this.loading.set(false);
        this.showModal.set(false); 
        this.errorMessage.set('');  

      },
      error: () => {
        this.errorMessage.set('Error al cargar personajes');
        this.loading.set(false);
        this.showModal.set(true); 
      }
    });
  }

  //Metodo para saber cual es el numero de pagina
  extractPageNumber(url: string): number {
    const match = url.match(/page=(\d+)/);
    return match ? parseInt(match[1], 10) : 1;
  }

  //Metodo para pasar a la siguiente pagina
  loadNextPage(): void {
    if (this.nextPageUrl()) {
      this.loadCharacters(this.nextPageUrl());
    }
  }

  //Metodo para volver a la pagina anterior
  loadPrevPage(): void {
    if (this.prevPageUrl()) {
      this.loadCharacters(this.prevPageUrl());
    }
  }

  //Metodo para cerrar el modal
  closeModal(): void {
    this.errorMessage.set('');  
  }

  //Metodo para reintentar
  retry(): void {
    this.errorMessage.set('');
    this.loadCharacters();
  }
}
