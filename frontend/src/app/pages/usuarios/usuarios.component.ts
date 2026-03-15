import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/models/Posts';
import { Usuario } from 'src/app/models/Usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  // Atributo usuario que vai ser um array(lista) do tipo da interface Usuario para pegar e armazenar
  // todos os usuarios trazidos pelo retorno do método GetUsuarios() do servico UsuarioService
  usuario: Usuario[] = [];

  // Atributo posts que vai ser um array(lista) do tipo da interface Post para pegar os posts retornados
  posts: Post[] = [];

  // Para utilizar o servico aqui, UsuarioService vamos utilizar injecao de dependencia no construtor
  // Do componente UsuariosCompoent
  constructor( private usuarioService: UsuarioService ) { }

  ngOnInit(): void {

    this.usuarioService.GetUsuarios().subscribe(data => {
      console.log(data);

      this.usuario = data;
    });
  }

  carregarPosts(id: number){

  this.usuarioService.getPostsByUsuario(id)
    .subscribe(data => {

      console.log(data);
      this.posts = data;
    });

  }
}
