import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Usuario } from '../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) {}

    list(): Observable<Usuario[]> {
        return this.http.get<Usuario[]>(`${this.baseUrl}/Usuario`);
    }
    getById(id: number): Observable<Usuario> {
        return this.http.get<Usuario>(`${this.baseUrl}/Usuario/${id}`);
    }
    create(usuario: Usuario): Observable<Usuario> {
        return this.http.post<Usuario>(`${this.baseUrl}/Usuario`, usuario);
    }
    delete(id: number) {
      return this.http.delete(`${this.baseUrl}/Usuario/${id}`);
    }
    update(usuario: Usuario) {
      return this.http.put(`${this.baseUrl}/Usuario`, usuario);
    }
}
