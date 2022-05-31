import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";

import { MatButtonModule } from "@angular/material/button";
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatGridListModule } from "@angular/material/grid-list";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatListModule } from "@angular/material/list";
import { MatSelectModule } from "@angular/material/select";
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatTableModule } from "@angular/material/table";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatNativeDateModule } from '@angular/material/core';
import { MAT_DATE_LOCALE } from '@angular/material/core'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ListarUsuariosComponent } from './views/listar-usuarios/listar-usuarios.component';
import { FormUsuarioComponent } from './components/form-usuario/form-usuario.component';
import { FormsModule } from '@angular/forms';
import { CadastroUsuarioComponent } from './views/cadastro-usuario/cadastro-usuario.component';

@NgModule({
  declarations: [
    AppComponent,
    ListarUsuariosComponent,
    FormUsuarioComponent,
    CadastroUsuarioComponent,
  ],
  imports: [
    FormsModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatListModule,
    MatGridListModule,
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
