import { Component, OnInit } from '@angular/core';
import { SaldoModel } from 'src/app/_classes/SaldoModel';
import { AuthService } from 'src/app/_services/autenticacao-service/auth.service';
import { SaldoService } from 'src/app/_services/saldo-service/saldo.service';

@Component({
    templateUrl:'saldo-sacar.component.html',
    styleUrls:['saldo-sacar.component.css']
})
export class SaldoSacarComponent implements OnInit{
    
    private id;
    saldoTotal=0;
    valorParaSacar=0;
    notasList:number[]=[];

    constructor(private saldoService:SaldoService, private loginService:AuthService){
        this.id = this.loginService.getId();
    }

    ngOnInit(): void {
        this.saldoService.getSaldo(this.id).subscribe(x=>this.saldoTotal=(x) as number);
    }

    adicionarValor(num:number){
        this.valorParaSacar+=num;
    }

    sacar(){
        this.saldoService.sacar(this.id,this.valorParaSacar)
                         .subscribe(x=>{
                             this.notasList=(x.body) as number[];
                             this.saldoTotal-=this.valorParaSacar;
                            },
                            err=>alert("ERRO"));
    }

    zerar(){
        this.valorParaSacar=0;
    }
}