import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarUsuariosComponent } from './views/listar-usuarios/listar-usuarios.component';

const routes: Routes = [
  {
    path: "",
    component: ListarUsuariosComponent,
},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
