import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterLink, RouterModule } from '@angular/router';
import { NavBarComponent } from './navbar.component';

@NgModule({
    declarations:[NavBarComponent],
    imports:[RouterModule,CommonModule],
    exports:[NavBarComponent],
})
export class NavBarModule{

}