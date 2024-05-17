import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Environment } from 'src/assets/environment';
import { ProductImage, ProductInfo } from '../_interfaces/product/product';

@Injectable({
  providedIn: 'root'
})
export class ArticleImageService {

  private url = `${Environment.baseUrl}/ProductImages`;
  
  constructor(private http:HttpClient) { }

  getPoductImages(productId:number):Observable<any>{
    return this.http.get<ProductImage[]>(this.url, {params:{productId}})
  }

}
