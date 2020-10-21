import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenService } from '../autenticacao-service/token.service';

const baseUrl = 'https://localhost:5001/api/Saldo';

@Injectable({providedIn:'any'})
export class SaldoService{
    constructor(private http:HttpClient, private token:TokenService){}
    
    getSaldo(id:number){
        return this.http.get(baseUrl+'/'+id);
    }

    sacar(id: string, valor:number){
       return this.http.post(baseUrl+"/sacar", {id:id,saldoAtual:valor}, {observe:'response'});
    }

    adicionarSaldo(id:string,valor:number){
        return this.http.post(baseUrl+"/adicionarSaldo",{id,saldoAtual:valor},{observe:'response'})
    }


}