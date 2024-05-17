import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { IUserAccount, IUserAccountResponse } from 'src/app/_interfaces/account/account_interface';
import { UserAccountService } from 'src/app/_services/user-account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginForm = this.formBuilder.group({
    email: ["", [Validators.required, Validators.email]],
    password: ["", [Validators.required]]
  });

  

  constructor(private formBuilder:FormBuilder, private userAccountService:UserAccountService){}


  onSubmit(event:Event){
    event.preventDefault();
    if(this.loginForm.valid){
      const userAccount:IUserAccount = {
        userEmail: this.loginForm.value.email as string,
        password: this.loginForm.value.password as string
      };
      
      this.userAccountService.login(userAccount).subscribe();
    }
    else
      console.log("form invalid");
  }
  
}

