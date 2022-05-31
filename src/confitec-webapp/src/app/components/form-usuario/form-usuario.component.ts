import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Usuario } from 'src/app/models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-form-usuario',
  templateUrl: './form-usuario.component.html',
  styleUrls: ['./form-usuario.component.css']
})
export class FormUsuarioComponent {
  nome!: string;
  sobrenome!: string;
  email!: string;
  dataNascimento!: Date;
  escolaridade!: string;

  @Input() usuario: Usuario = <Usuario>{};
  @Output() outputUsuario: EventEmitter<Usuario> = new EventEmitter();
  
  escolaridades: string[] = [
    "INFANTIL", "FUNDAMENTAL", "MEDIO", "SUPERIOR"
  ];

    constructor(
        private funcionarioService: UsuarioService
    ) {}

    onSubmit() {
      this.outputUsuario.emit(this.usuario);
    }

}
