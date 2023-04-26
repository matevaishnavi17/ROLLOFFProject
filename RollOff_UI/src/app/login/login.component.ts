import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private loginAuth:AuthService,private router:Router){} 
  ngOnInit(): void {
    
  }

loginForm =new FormGroup({
  email:new FormControl("",[Validators.required, Validators.email]),
  password:new FormControl("",[
    Validators.required,Validators.minLength(6),Validators.maxLength(15)]),
  });

  isUserValid:boolean=false;
  
  loginSubmitted(){
    console.log(this.loginForm.value);
    this.loginAuth.loginUser(this.loginForm.value).subscribe(res=>{
    
      if(res=='Failure')
      {
        this.isUserValid=false;
        alert("Login unsuccesfull");
        
      }
    
      else{

      this.isUserValid=true;
      this.loginAuth.setToken(res);
        this.router.navigateByUrl("app-employees");
      

      }
    
    
    });
  }
    get Email():FormControl{ 
      return this.loginForm.get('email') as FormControl; 
  } 
    get Password():FormControl{ 
      return this.loginForm.get('password') as FormControl;
   }
}

