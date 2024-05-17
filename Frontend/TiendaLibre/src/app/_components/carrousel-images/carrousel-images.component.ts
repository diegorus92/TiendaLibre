import { Component, Input } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ProductImage } from 'src/app/_interfaces/product/product';

@Component({
  selector: 'app-carrousel-images',
  templateUrl: './carrousel-images.component.html',
  styleUrls: ['./carrousel-images.component.css']
})
export class CarrouselImagesComponent {

  @Input() productImages: ProductImage[] = [{productImageId:0, productImageName:"null", dataImage: "../assets/img/test.jpg"}];
  @Input() isImageAvailable = true;
  @Input() heightComponentSelection = 0; //For select css class
  currentItemPosition = 0;
  heightsComponentOptions = ["", "-height-1"]; //select css class with more height values

  constructor(private sanitizer:DomSanitizer){
  }


  previousItem(){
    if(this.currentItemPosition > 0){
      this.currentItemPosition--;
    }
    else{
      this.currentItemPosition = (this.productImages.length - 1);
    }
  }

  nextItem(){
    if(this.currentItemPosition < (this.productImages.length - 1)){
      this.currentItemPosition++;
    }
    else{
      this.currentItemPosition = 0;
    }
  }
}
