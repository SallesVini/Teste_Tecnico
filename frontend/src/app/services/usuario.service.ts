import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usuario } from '../models/Usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  // Pegando a url da API .Net que está no arquivo environment e vamos guardar no atributo apiUrl
  private apiUrl = `${environment.ApiUrl}/usuarios`;

  constructor( private http: HttpClient ) { }

  // Método responsável por buscar todos os usuários na API .Net
  // Utilizamos o HttpClient, que é o módulo do Angular usado
  // para realizar requisições HTTP (GET, POST, PUT, DELETE)

  // Criamos também a interface Usuario dentro da pasta models,
  // que representa a estrutura do objeto (o tipo do objeto) retornado pela API .Net
  // O retorno deste método é um Observable contendo uma lista de usuários do tipo Usuario
  GetUsuarios() : Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.apiUrl);
  }


  // Método responsável por buscar todos os posts de um usuário específico
  // O ID do usuário é recebido como parâmetro e enviado na requisição
  // para a API do JSONPlaceholder utilizando o parâmetro userId
  getPostsByUsuario(id: number){
    return this.http.get<any[]>(`https://jsonplaceholder.typicode.com/posts?userId=${id}`);
  }
}
