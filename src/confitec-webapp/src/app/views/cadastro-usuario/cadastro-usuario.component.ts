import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-cadastro-usuario',
  templateUrl: './cadastro-usuario.component.html',
  styleUrls: ['./cadastro-usuario.component.css']
})
export class CadastroUsuarioComponent {

  usuario: Usuario = <Usuario>{};
  constructor(private usuarioService: UsuarioService, private router: Router) { }

  cadastrar(): void {
    this.usuarioService.create(this.usuario).subscribe(() => {
      this.router.navigateByUrl('/');
    });
  }

}
