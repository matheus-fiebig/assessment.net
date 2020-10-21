import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { ClienteModelUpdate } from 'src/app/_classes/ClienteModelUpdate';

const baseUrl = 'https://localhost:5001/api/Cliente';

@Injectable({providedIn:'root'})
export class ClienteService{
    constructor(private http:HttpClient){}

    getCliente(id='0'){
        if(id=='0'){
            return this.http.get(baseUrl);
        }
        return this.http.get(baseUrl+'/'+id);
    }

    updateCliente(model:ClienteModelUpdate,id){
        return this.http.put(baseUrl+'/'+id,model);
    }

    deleteCliente(id:string){
        return this.http.delete(baseUrl+"/"+id);
    }

}