import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario.service';
import { MatTableDataSource } from "@angular/material/table";
import { Usuario } from 'src/app/models/usuario';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent, ConfirmDialogModel } from 'src/app/components/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-listar-usuarios',
  templateUrl: './listar-usuarios.component.html',
  styleUrls: ['./listar-usuarios.component.css']
})
export class ListarUsuariosComponent implements OnInit {
  result: string = '';
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
  usuarioSelecionado!: number;

  constructor(private service: UsuarioService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.listarUsuarios();
  }

  listarUsuarios(){
    this.service.list().subscribe((response: any) => {
      this.usuarios = response.items;
      this.matT = new MatTableDataSource<Usuario>( response.items );
  });
  }

  confirmRemocaoUsuario(id: number): void {
    this.usuarioSelecionado = id;
    const message = `Tem certeza que deseja remover este usuário`;

    const dialogData = new ConfirmDialogModel("Confirmar Ação", message);

    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      maxWidth: "400px",
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.removerUsuario();
      }
    });
  }

  removerUsuario(){
    this.service.delete(this.usuarioSelecionado).subscribe(() => {
      this.listarUsuarios();
    });
  }

}
