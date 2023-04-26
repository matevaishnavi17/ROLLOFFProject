import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  repeatPass:string='none';
   displayMsg :string='';
   isAccountCreated:boolean=false;
   constructor(private authService:AuthService){}
    ngOnInit(): void {
      
     }

     selectedTeam = '';
     onSelected(value:string): void {
       this.selectedTeam = value;
      }
     registerForm=new FormGroup({
       firstname:new FormControl("",[Validators.required,Validators.minLength(2),Validators.pattern("[a-zA-z].*")]),
       lastname:new FormControl("",[Validators.required,Validators.minLength(2),
         Validators.pattern("[a-zA-z].*")]),
          email:new FormControl("",[Validators.required,Validators.email]),
          Password:new FormControl("",[Validators.required,Validators.minLength(6),Validators.maxLength(12)]),
          cpwd:new FormControl(""),
          role:new FormControl("",[Validators.required])
        });

        registerSubmitted(){
          if(this.Password.value==this.CPWD.value)
          {
            console.log("this.registerForm.valid");
            console.log("Submitted");
             this.repeatPass='none'
             console.log(this.registerForm.value);
             this.authService.registerUser(this.registerForm.value).subscribe(res=>
              {
              if(res=='User created'){
                alert('Account Created Successfully');
                this.isAccountCreated=true;
              }else if(res=='Already Exist'){
                alert("User Already Exist.")
                this.isAccountCreated=false;
              }else {
                alert('Something Went Wrong');
                this.isAccountCreated=false;
              }
              //console.log(res);
             });
            }else{
               this.repeatPass='inline'
               } 
        }
              get Firstname():FormControl{
                return this.registerForm.get("firstname") as FormControl;
              }
              get Lastname():FormControl{
                return this.registerForm.get("lastname") as FormControl;
              }
              get Email():FormControl{
                return this.registerForm.get("email") as FormControl;
              }
              get Password():FormControl{
                return this.registerForm.get("Password") as FormControl;
              }
              
              get Role():FormControl{
                return this.registerForm.get("role") as FormControl;
              }
              get CPWD():FormControl{
                return this.registerForm.get("cpwd") as FormControl;
              }
}
