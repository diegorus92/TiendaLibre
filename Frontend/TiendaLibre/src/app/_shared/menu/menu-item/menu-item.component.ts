import { Component, Input } from '@angular/core';
import { MenuItem } from 'src/app/_interfaces/menu/item_interface';

@Component({
  selector: 'app-menu-item',
  templateUrl: './menu-item.component.html',
  styleUrls: ['./menu-item.component.css']
})
export class MenuItemComponent {
  @Input() item:MenuItem= {label: "item", path: "#", active:true};
}
