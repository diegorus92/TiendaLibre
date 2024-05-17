import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductImage, ProductInfo } from 'src/app/_interfaces/product/product';
import { ArticleImageService } from 'src/app/_services/article-image.service';
import { ArticleService } from 'src/app/_services/article.service';

@Component({
  selector: 'app-article-card',
  templateUrl: './article-card.component.html',
  styleUrls: ['./article-card.component.css']
})
export class ArticleCardComponent implements OnInit {

  @Input() product: ProductInfo = { //Product info will comming from the father component
    productId: 0,
    productName: "Some Article Deluxe",
    productCategory: "Things",
    productBrand: "MyBrand",
    productModel: "MB-1111",
    price: 10000.50,
    stockQty: 500,
    userSellerId: 1000,
    productImages:[{productImageId: 0, productImageName: "", dataImage:""},  
                  {productImageId: 0, productImageName: "", dataImage:""},
                  {productImageId: 0, productImageName: "", dataImage:""}]
  }

  noProductImages:ProductImage[] = [{productImageId:0, productImageName:"null", dataImage: "../assets/img/no-image-icon.png"}]

  constructor(
    private articleImageService:ArticleImageService,
    private router:Router,
    private articleService:ArticleService
  ){

  }

  ngOnInit(): void {
    this.getProductImages();
  }

  getProductImages(){
    this.articleImageService.getPoductImages(this.product.productId).subscribe({
      next: data =>{
        this.product.productImages = data;
        console.log(this.product);
      },
      error: error => console.log(error),
      complete:() => console.log("GETTER product images complete")
    })
  }

  viewArticle(){
    this.articleService.setArticleSelectedSubject$(this.product);
    this.router.navigate(['menu-bar/article-viewer']);
  }
}

