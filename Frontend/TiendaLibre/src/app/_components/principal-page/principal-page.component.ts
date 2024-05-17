import { Component } from '@angular/core';
import { mock_products } from 'src/app/Mock_Data';
import { ProductInfo } from 'src/app/_interfaces/product/product';
import { ArticleService } from 'src/app/_services/article.service';
import { UserAccountService } from 'src/app/_services/user-account.service';

@Component({
  selector: 'app-principal-page',
  templateUrl: './principal-page.component.html',
  styleUrls: ['./principal-page.component.css']
})
export class PrincipalPageComponent {

  userEmail = "";
  productsInfo: ProductInfo[] = []; 

  constructor(
    private userAccountService:UserAccountService,
    private articleService:ArticleService
  ){}

  ngOnInit(){
    this.refresh();
  }

  refresh(){
    this.getLoggedUserEmal();
    this.getProducts();
  }

  getLoggedUserEmal(){
    this.userAccountService.setUserEmailSubject$(localStorage.getItem("userEmail") as string);
    this.userAccountService.userEmailSubject$.subscribe({
      next: data =>{
        this.userEmail = data;
      },
      error: error => console.log(error)
    });
  }


  getProducts(){
    this.articleService.getProducts().subscribe(
      {
        next: products => {
          this.productsInfo = products;
          console.log(products);
        },
        error: error => console.log(error),
        complete: () => console.log("GETTER products complete!")
      }
    )
  }

}
