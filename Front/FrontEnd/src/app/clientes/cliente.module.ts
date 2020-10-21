import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ClienteDetalheComponent } from './cliente-detalhes/cliente-detalhe.component';
import { ClienteLista } from './cliente-lista/cliente-lista.component';

@NgModule({
    declarations:[ClienteLista, ClienteDetalheComponent],
    imports:[CommonModule,RouterModule, ReactiveFormsModule]
})
export class ClienteModule{

}