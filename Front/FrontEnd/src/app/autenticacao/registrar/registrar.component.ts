import { Route } from '@angular/compiler/src/core';
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/autenticacao-service/auth.service';

@Component({
    templateUrl:'registrar.component.html',
    styleUrls:['registrar.component.css']
})
export class RegistrarComponent{
    registerForm: any;


    constructor(private formBuilder: FormBuilder, private authService:AuthService,private router:Router){}

    ngOnInit(): void {
        this.registerForm = this.formBuilder.group({
            email:['', [Validators.required, Validators.email]],       
            userName:['', [Validators.required] ],       
            password:['', [Validators.required, ] ],            
        });
    }

    register(){
        const email =  this.registerForm.get('email').value;
        const userName = this.registerForm.get('userName').value;
        const password = this.registerForm.get('password').value;
        
        this.authService.register(email,userName,password)
                        .subscribe(x=>this.router.navigateByUrl('sacar'),
                                    err=>alert("ERRO"));
    }
}