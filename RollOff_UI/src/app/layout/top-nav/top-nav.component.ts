import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css']
})
export class TopNavComponent {
  user:any;
  Isloggedin:boolean = false;
   constructor(){}
   ngOnInit(): void {
   // this.checkstorage();
   }

   ngDoCheck(){
    this.checkstorage();
   }
  // public logOut = () => {
  //   localStorage.removeItem("jwt");
  //   this.router.navigate(["app-login"]);
  // }

  // public isUserAuthenticated = (): boolean => {
  //   const token = localStorage.getItem("jwt");
  //   if (token && !this.jwtHelper.isTokenExpired(token)) {
  //     return true;
  //   }
  //   return false;
  // }
  checkstorage()
  {
    this.user =localStorage.getItem('access_token');
    if(this.user!=null){
      this.Isloggedin =true;
    }
  }
  logout()
  {
    localStorage.clear();
    this.Isloggedin=false;
    console.log(this.Isloggedin);
  }
}
