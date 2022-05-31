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
    this.service.list().subscribe((response: any) => {
        this.usuarios = response.items;
        this.matT = new MatTableDataSource<Usuario>( response.items );
    });
  }

}
