import { Component, OnInit } from '@angular/core';
import { ProductInfo } from 'src/app/_interfaces/product/product';
import { ArticleService } from 'src/app/_services/article.service';

@Component({
  selector: 'app-article-viewer',
  templateUrl: './article-viewer.component.html',
  styleUrls: ['./article-viewer.component.css']
})
export class ArticleViewerComponent implements OnInit {
  
  product: ProductInfo = { //Product info will comming from the father component
    productId: 0,
    productName: "Some Article Deluxe",
    productCategory: "Things",
    productBrand: "MyBrand",
    productModel: "MB-1111",
    price: 10000.50,
    stockQty: 500,
    userSellerId: 1000,
    productImages:[{productImageId: 0, productImageName: "test1.jpg", dataImage:"../assets/img/test1.png"},  
                  {productImageId: 0, productImageName: "test2.jpg", dataImage:"../assets/img/test2.jpg"},
                  {productImageId: 0, productImageName: "test3.jpg", dataImage:"../assets/img/test3.jpg"}]
  }
  
  constructor(private articleService:ArticleService){}

  ngOnInit(): void {
    //this.getProductFromService();
  }

  getProductFromService(){
    this.articleService.articleSelectedSubject$?.subscribe({
      next: data => {
        console.log("Article viewer: ",data);
        this.product = data as ProductInfo;
      }
    });
  }

}
