import { Component, Injectable, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { AuthService } from 'src/app/_services/autenticacao-service/auth.service';
import { TokenService } from 'src/app/_services/autenticacao-service/token.service';

@Component({
    selector:'<app-navbar>',
    templateUrl:'navbar.component.html',
    styleUrls:['navbar.component.css']
})
@Injectable({providedIn:'root'})
export class NavBarComponent{
    constructor(private authService:AuthService, private router:Router){
 
    }

    logout(){
        var id = this.authService.getId();
        if(id)
        this.authService.logout().subscribe(x=>{ 
                this.router.navigateByUrl('')
        });
    }
}