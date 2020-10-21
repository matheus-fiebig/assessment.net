import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { TokenService } from './token.service';
import { ClienteModel } from 'src/app/_classes/ClienteModel';

const baseUrl = 'https://localhost:5001/api/Account';

@Injectable({providedIn:'root'})
export class AuthService{
    constructor(private http:HttpClient, private token:TokenService){}
    private id;
    login(userName: string, password:string)
    {
       return this.http.post(baseUrl+"/login", {userName, password}, {observe:'response'})
                       .pipe(tap(res=>{
                                    const authToken = res.headers.get('x-access-token');
                                    this.token.setToke(authToken);
                                    var response = (res.body) as ClienteModel;
                                    this.id = response.id; 
                                }));
    }

    logout()
    {
        this.token.removeToken();
        this.id=null;
        return this.http.post(baseUrl+"/logout",{});
    }

    register(email:string,userName:string,password:string){
        return this.http.post("https://localhost:5001/api/Cliente",{email,userName,password,saldo:{saldoAtual:0}});
    }

    getId()
    {
        return this.id;
    }

    hasPermissao(){
        return new Promise(resolve=>{
            this.http.get(baseUrl+"/permissao").subscribe(
                () => resolve(true), 
                err=> resolve(false));
        });
        
    }


}