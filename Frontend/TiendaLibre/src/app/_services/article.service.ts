import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map, pipe } from 'rxjs';
import { Environment } from 'src/assets/environment';
import { ProductInfo } from '../_interfaces/product/product';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  private url = `${Environment.baseUrl}/Products`;
  private articleSelectedSubject = new BehaviorSubject<ProductInfo>({
    productId: 0,
    productName: "",
    productCategory: "",
    productBrand: "",
    productModel: "",
    price: 0,
    stockQty: 0,
    userSellerId: 0,
    productImages:[]
  });

  constructor(private http:HttpClient) { }


  get articleSelectedSubject$(){
    return this.articleSelectedSubject?.asObservable();
  }

  setArticleSelectedSubject$(productSelected:ProductInfo){
    this.articleSelectedSubject?.next(productSelected);
  }

  getProducts():Observable<any>{
    return this.http.get<ProductInfo[]>(this.url).pipe(
      map(
        (response:ProductInfo[]) => {
          response.map(item => item.productImages = []) //adding productImages[] property into object
          return response;
        }
      )
    )
  }
}
