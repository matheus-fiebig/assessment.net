import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClienteModel } from 'src/app/_classes/ClienteModel';
import { ClienteModelUpdate } from 'src/app/_classes/ClienteModelUpdate';
import { ClienteService } from 'src/app/_services/cliente-service/cliente.service';
import { SaldoService } from 'src/app/_services/saldo-service/saldo.service';

@Component({
    templateUrl:'cliente-detalhe.component.html'
})
export class ClienteDetalheComponent implements OnInit{
    cliente:ClienteModel;
    id='';
    clienteForm:FormGroup;
    isLoad=false;
    funcao:number=1;
    
    constructor(private clienteService:ClienteService, private activatedRoute:ActivatedRoute,
                private formBuilder:FormBuilder, private router:Router, private saldoSerivce:SaldoService){
        this.activatedRoute.paramMap.subscribe(x=>this.id=x.get('id'));
    }

    ngOnInit() :void {
        this.clienteService.getCliente(this.id).subscribe((c:ClienteModel)=>{
            this.cliente=c;
    
            this.clienteForm = this.formBuilder.group({
                userName: [c[0].userName, Validators.required],
                email: [c[0].email, Validators.required],
                cpassword: [''],
                npassword: [''],
                saldo: [0, Validators.required],
            }); 

            this.isLoad=true;
        });
 
    }


    salvar(){
        var model = this.clienteForm.getRawValue() as ClienteModelUpdate
        var saldo = this.clienteForm.get('saldo').value;
       
        saldo *= this.funcao;

        this.saldoSerivce.adicionarSaldo(this.id,saldo).subscribe(x=>{
            this.clienteService.updateCliente(model,this.id)
                                 .subscribe(x=>this.router.navigateByUrl('cliente'),
                                             err=>alert("ERRO")
                                 );
        });
        
    }


}