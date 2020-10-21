import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AuntenticacaoModule } from './autenticacao/autenticacao.module';
import { SaldosModule } from './saldos/saldos.module';
import { RouterModule } from '@angular/router';
import { ClienteModule } from './clientes/cliente.module';
import { NavBarModule } from './_shared/navbar/navbar.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AppRoutingModule,
    NavBarModule,
    HttpClientModule,
    AuntenticacaoModule,
    ClienteModule,
    SaldosModule,
    BrowserModule,
    RouterModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
