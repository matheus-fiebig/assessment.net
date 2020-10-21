import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/autenticacao-service/auth.service';
import { NavBarComponent } from 'src/app/_shared/navbar/navbar.component';


@Component({
    templateUrl:'login.component.html',
    styleUrls:['login.component.css']
})
export class LoginComponent implements OnInit{
    
    loginForm:FormGroup;

    constructor(private router:Router, private formBuilder:FormBuilder, private authService:AuthService,
                private menuComponent:NavBarComponent){}
    
    ngOnInit(): void {
        this.loginForm = this.formBuilder.group({
            userName: ['', Validators.required],
            password: ['', Validators.required],
        }); 
    }

    login()
    {
        const userName = this.loginForm.get('userName').value;
        const password = this.loginForm.get('password').value;
        this.authService.login(userName,password).subscribe(()=>
            {
                this.router.navigateByUrl('sacar')
            },
            err=>alert("ERRO"));
    }

}