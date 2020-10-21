import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SaldoSacarComponent } from './saldo-sacar/saldo-sacar.component';

@NgModule({
    declarations:[SaldoSacarComponent],
    imports:[RouterModule,CommonModule],
    exports:[]
})
export class SaldosModule{

}