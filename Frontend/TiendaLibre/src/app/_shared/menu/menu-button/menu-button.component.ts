import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-menu-button',
  templateUrl: './menu-button.component.html',
  styleUrls: ['./menu-button.component.css']
})
export class MenuButtonComponent {
  @Input() name = "Button";
  @Input() options:string[] = []
}
