import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from 'src/app/models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-atualizar-usuario',
  templateUrl: './atualizar-usuario.component.html',
  styleUrls: ['./atualizar-usuario.component.css']
})
export class AtualizarUsuarioComponent implements OnInit {

  usuario: Usuario = <Usuario>{};
  constructor(private usuarioService: UsuarioService,
     private activatedRoute: ActivatedRoute,
     private router: Router) { }
  
  ngOnInit(): void {
    this.buscarPorId();
  }

  buscarPorId(){
    let id = this.activatedRoute.snapshot.params['id'];
    this.usuarioService.getById(id).subscribe((result) => {
      this.usuario = result;
    })
  }

  atualizar(): void {
    this.usuarioService.update(this.usuario).subscribe(() => {
      this.router.navigateByUrl('/');
    });
  }

}
