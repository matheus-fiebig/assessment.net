import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AutenticacaoComponent } from './autenticacao/autenticacao.component';
import { LoginComponent } from './autenticacao/login/login.component';
import { RegistrarComponent } from './autenticacao/registrar/registrar.component';
import { ClienteDetalheComponent } from './clientes/cliente-detalhes/cliente-detalhe.component';
import { ClienteLista } from './clientes/cliente-lista/cliente-lista.component';
import { SaldoSacarComponent } from './saldos/saldo-sacar/saldo-sacar.component';
import { AuthGuard } from './_services/autenticacao-service/auth.guard';
import { AuthGuardAdmin } from './_services/autenticacao-service/authAdmin.guard';


const routes: Routes = [  
  {
    path:'',
    component:AutenticacaoComponent,
    children:[
      {
        path:'',
        component:LoginComponent
      },
      {
        path:'registrar',
        component:RegistrarComponent
      }
    ]
  },
  {
    path:'sacar',
    component:SaldoSacarComponent,
    canActivate:[AuthGuard],
  },
  {
    path:'cliente',
    canActivate:[AuthGuard,AuthGuardAdmin],
    children:[
      {
        path:'',
        component:ClienteLista
      },
      {
        path:'detalhes/:id',
        component:ClienteDetalheComponent
      }
    ]
  } ,
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
