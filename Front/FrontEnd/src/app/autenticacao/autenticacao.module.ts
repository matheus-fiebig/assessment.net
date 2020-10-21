import { CommonModule } from '@angular/common';
import { NgModule } from "@angular/core";
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AutenticacaoComponent } from './autenticacao.component';
import { LoginComponent } from './login/login.component';
import { RegistrarComponent } from './registrar/registrar.component';

@NgModule({
    declarations:[LoginComponent,AutenticacaoComponent,RegistrarComponent],
    imports:[CommonModule, RouterModule, ReactiveFormsModule],
    exports:[],
})

export class AuntenticacaoModule{

}