import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MenuItem } from 'src/app/_interfaces/menu/item_interface';
import { UserAccountService } from 'src/app/_services/user-account.service';

@Component({
  selector: 'app-menu-bar',
  templateUrl: './menu-bar.component.html',
  styleUrls: ['./menu-bar.component.css']
})
export class MenuBarComponent implements OnInit {
  menuButtons = ["Categorias", "Sobre", "Nosotros", "Contacto"]
  categoryButtonName = "Categorias";
  categoriesItems = ["Electrónica", "Informática", "Herramientas", "Ropa"];
  userItems: MenuItem[] = [
    {label: "Registro", path: "register", active: true}, 
    {label: "Mi Cuenta", path: "my-acount", active: true},
    {label: "login", path: "login", active: true}
  ]

  userIconClicked = false;

  constructor(private userAccountService:UserAccountService){}

  ngOnInit(){
    this.refresh();
  }


  toggleIcon(icon:boolean):void{
    this.userIconClicked = !icon;
  }

  logout(){
    this.userAccountService.logout();
    this.refresh();
  }

  changeMenuItemState(menuItems:MenuItem[], labelTarget:string, isActive:boolean){
    this.userItems.find(item => item.label == labelTarget)!.active = isActive;
  }

  refresh(){ 
    if(this.userAccountService.isUserLogged()){
      this.changeMenuItemState(this.userItems, "login", false);
    }
    else{
      this.changeMenuItemState(this.userItems, "login", true);
    }
  }
}
