import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario.service';
import { MatTableDataSource } from "@angular/material/table";
import { Usuario } from 'src/app/models/usuario';

@Component({
  selector: 'app-listar-usuarios',
  templateUrl: './listar-usuarios.component.html',
  styleUrls: ['./listar-usuarios.component.css']
})
export class ListarUsuariosComponent implements OnInit {
  usuarios: Usuario[] = [];
  matT!: MatTableDataSource<Usuario>;
  colunasExibidas: String[] = [
      "id",
      "nome",
      "sobrenome",
      "email",
      "dataNascimento",
      "escolaridade",
      "editar",
      "remover"
  ];

  constructor(private service: UsuarioService) {}

  ngOnInit(): void {  
    this.usuarios = [
      {id: 1, nome: "Teste", sobrenome: "Teste", email: "Teste@gmail.com", dataNascimento: "2022-01-31 00:00:00", escolaridade: "Infantil", criadoEm: "2022-01-31 00:00:00", atualizadoEm: "2022-01-31 00:00:00"}
    ];
    this.matT = new MatTableDataSource<Usuario>( this.usuarios );
  }

}
