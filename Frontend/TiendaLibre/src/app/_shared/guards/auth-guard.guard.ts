import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { UserAccountService } from 'src/app/_services/user-account.service';
import { MenuBarComponent } from '../menu/menu-bar/menu-bar.component';


export const authGuardGuard: CanActivateFn = (route, state) => {
  const menuItemInjection = inject(MenuBarComponent);
  if(inject(UserAccountService).isUserLogged()){
    inject(Router).navigate([""]);
    return false;
  }
  return true;
};
