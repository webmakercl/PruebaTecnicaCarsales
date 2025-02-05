import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

//Clase que representa la respuesta de la api
interface ApiResponse {
  info: Info;
  results: Character[];
}

//Clase encargada de mostrar info y paginacion
interface Info {
  count: number;
  pages: string;
  next: string;
  prev: string;
}

//Clase para representar la estructura de un personaje
interface Character {
  id: number;
  name: string;
  status: string;
  species: string;
  type: string;
  gender: string;
  origin: Origin;
  location: Location;
  image: string;
  episode: string[];
  Url: string;
  Created: string;
}

//Clase que muestra el objeto Origin de un personaje
interface Origin {
  name: string;
  url: string;
}

//Clase que muestra el objeto Location de un personaje
interface Location {
  name: string;
  url: string;
}

@Injectable({
  providedIn: 'root'
})
export class CharacterService {

  //Url de la api
  private apiUrl = 'http://localhost:5000/api/v1/Character';

  constructor(private http: HttpClient) { }

  //Metodo encargado de obtener los personajes
  getCharacter(pageUrl?: string): Observable<ApiResponse> {
    const url = pageUrl ? `${this.apiUrl}?pageUrl=${encodeURIComponent(pageUrl)}` : this.apiUrl;
    return this.http.get<ApiResponse>(url);
  }
}
