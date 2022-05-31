import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-cadastro-usuario',
  templateUrl: './cadastro-usuario.component.html',
  styleUrls: ['./cadastro-usuario.component.css']
})
export class CadastroUsuarioComponent implements OnInit {

  usuario: Usuario = <Usuario>{};
  constructor(private funcionarioService: UsuarioService, private router: Router) { }

  ngOnInit(): void {
  }

  cadastrar(): void {
    this.funcionarioService.create(this.usuario).subscribe(() => {
      this.router.navigateByUrl('/');
  });
}

}
