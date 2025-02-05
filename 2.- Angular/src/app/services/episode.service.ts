import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


//Clase que representa la respuesta de la api
interface ApiResponse {
  info: Info;
  results: Episode[];
}

//Clase encargada de mostrar info y paginacion
interface Info {
  count: number;
  pages: string;
  next: string;
  prev: string;
}

//Clase encargada de la estructura de datos de los episodios
interface Episode {
  id: number;
  name: string;
  air_date: string;
  episode: string;
  Characters: string[];
  Url: string;
  Created: string;
}

@Injectable({
  providedIn: 'root'
})
export class EpisodeService {


  //Url de la api
  private apiUrl = 'http://localhost:5000/api/v1/Episodes';

  constructor(private http: HttpClient) { }

  //Metodo encargado de obtener los episodios
  getEpisodes(pageUrl?: string): Observable<ApiResponse> {
    const url = pageUrl ? `${this.apiUrl}?pageUrl=${encodeURIComponent(pageUrl)}` : this.apiUrl;
    return this.http.get<ApiResponse>(url);
  }
}
