import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import{JwtHelperService} from '@auth0/angular-jwt';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  currentuser:BehaviorSubject<any>=new BehaviorSubject("null");
  baseServerUrl=environment.baseApiUrl+"api/"
  //'https://localhost:44385/api/'
  jwtHelperService=new JwtHelperService();
  constructor(private http:HttpClient) { }

  registerUser(reg:any){
    //reg:Array<String>
    return this.http.post(this.baseServerUrl+"User/CreateUser",reg,
    
    {
      responseType:'text',
    });
  } 
  
  loginUser(reg: any){
     return this.http.post(this.baseServerUrl+"User/LoginUser",reg,
    
      {responseType:'text',}
    );
 }


  setToken(token:string){
  localStorage.setItem("access_token",token);
  this.loadCurrentUser();
  }

  loadCurrentUser(){
  const Token=localStorage.getItem("Access_token");
  const userInfo=Token!=null?this.jwtHelperService.decodeToken(Token):null;
  console.log(userInfo);
  }
}
