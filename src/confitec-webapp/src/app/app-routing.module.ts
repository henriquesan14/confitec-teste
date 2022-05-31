import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AtualizarUsuarioComponent } from './views/atualizar-usuario/atualizar-usuario.component';
import { CadastroUsuarioComponent } from './views/cadastro-usuario/cadastro-usuario.component';
import { ListarUsuariosComponent } from './views/listar-usuarios/listar-usuarios.component';

const routes: Routes = [
  {
    path: "",
    component: ListarUsuariosComponent,
  },
  {
    path: "cadastro",
    component: CadastroUsuarioComponent,
  },
  {
    path: "atualizar/:id",
    component: AtualizarUsuarioComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
