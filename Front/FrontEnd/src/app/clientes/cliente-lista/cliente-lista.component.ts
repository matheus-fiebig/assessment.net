import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClienteModel } from 'src/app/_classes/ClienteModel';
import { ClienteService } from 'src/app/_services/cliente-service/cliente.service';


@Component({
    templateUrl:'cliente-lista.component.html'
})
export class ClienteLista implements OnInit{
    items:ClienteModel[]=[];
    
    constructor(private clienteService:ClienteService,private router:Router){}

    ngOnInit(): void {
        this.getCliente();
    }

    getCliente(){
        this.clienteService.getCliente().subscribe(x=>{
            this.items=(x)as ClienteModel[];
            console.log(this.items);
        },err=>alert("ERRO"));
    }

    delete(id:string){
        console.log(id);
        this.clienteService.deleteCliente(id).subscribe(x=>this.getCliente(),err=>alert("ERRO"));
    }

}