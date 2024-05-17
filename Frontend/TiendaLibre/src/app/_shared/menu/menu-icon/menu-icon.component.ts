import { Component, Input } from '@angular/core';
import { MenuItem } from 'src/app/_interfaces/menu/item_interface';

@Component({
  selector: 'app-menu-icon',
  templateUrl: './menu-icon.component.html',
  styleUrls: ['./menu-icon.component.css']
})
export class MenuIconComponent {
  @Input() xmlns = "";
  @Input() viewBox = "";
  @Input() d = "";
  @Input() items:MenuItem[] = [];
  @Input() iconClicked = false;

}
