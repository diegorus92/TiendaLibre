import { Injectable } from '@angular/core';
import { IUserAccount, IUserAccountResponse } from '../_interfaces/account/account_interface';
import { Environment } from 'src/assets/environment';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { Router } from '@angular/router';
import { JsonPipe } from '@angular/common';
import { PrincipalPageComponent } from '../_components/principal-page/principal-page.component';

@Injectable({
  providedIn: 'root'
})
export class UserAccountService {

  private url = `${Environment.baseUrl}/Account`;
  private userEmailSubject = new BehaviorSubject<string>("");

  constructor(private http:HttpClient, private router:Router) { }

  get userEmailSubject$():Observable<string>{
    return this.userEmailSubject.asObservable();
  }

  setUserEmailSubject$(email:string){
    this.userEmailSubject.next(email);
  }

  isUserLogged():boolean{
    if(localStorage.length > 0) return true;
    else return false;
  }

  login(userAccount:IUserAccount){
    return this.http.post(`${this.url}/login`, userAccount).
    pipe(
      map((response:any) => {
        localStorage.setItem('userId', JSON.stringify(response.userId));
        localStorage.setItem('userEmail', JSON.stringify(response.userEmail));
        localStorage.setItem('token', JSON.stringify(response.token));

        this.userEmailSubject.next(localStorage.getItem("userEmail") as string);
        this.router.navigateByUrl("");
        window.location.reload(); //refresh whole page (like F5)
      })
    )
  }

  logout(){
    localStorage.clear();
    this.userEmailSubject.next("");
    this.router.navigateByUrl("");
  }
}
