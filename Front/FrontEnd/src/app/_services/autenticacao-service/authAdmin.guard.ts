import { Injectable } from '@angular/core';
import { TokenService } from './token.service';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({providedIn:'root'})
export class AuthGuardAdmin implements CanActivate{
    constructor(private authService:AuthService, private router:Router){}
    
    async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot){
        let v;
        await this.authService.hasPermissao().then(x=>v=x);
        return v;
    }  
    


}