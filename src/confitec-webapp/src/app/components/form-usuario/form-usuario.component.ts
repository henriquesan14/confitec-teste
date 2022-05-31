import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Usuario } from 'src/app/models/usuario';
import {Location} from '@angular/common';

@Component({
  selector: 'app-form-usuario',
  templateUrl: './form-usuario.component.html',
  styleUrls: ['./form-usuario.component.css']
})
export class FormUsuarioComponent {
  
  @Input() usuario: Usuario = <Usuario>{};
  @Output() outputUsuario: EventEmitter<Usuario> = new EventEmitter();
  
  escolaridades: string[] = [
    "INFANTIL", "FUNDAMENTAL", "MEDIO", "SUPERIOR"
  ];

    constructor(
      private location: Location
    ) {}

    onSubmit() {
      this.outputUsuario.emit(this.usuario);
    }

    back(){
      this.location.back();
    }

}
