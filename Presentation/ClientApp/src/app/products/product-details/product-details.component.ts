import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { IProduct } from 'src/app/Models/IProduct';
import { ActivatedRoute, Router } from '@angular/router';
import { GlobalsService } from 'src/app/Shared/globals.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  productDetails :IProduct;
  errorMessage: string;
  itemCount:number = 1;
  disableMinusButton: boolean = true;
  orderProduct: IProduct[];
  oredersDetailsList:IProduct[] = [];
  constructor(private productService: ProductService,private route: ActivatedRoute,private global:GlobalsService,private router: Router) { }

  ngOnInit() {
    const param = this.route.snapshot.paramMap.get('id');
    if (param) {
      const id = +param;
      this.getProduct(id);
      this.orderProduct = this.global.getOrderList();
  }
}
  getProduct(id: number) {
    this.productService.getProductById(id).subscribe({
      next: producInfo=> {
        this.productDetails = producInfo; 
        this.oredersDetailsList.push(this.productDetails);
      },
      error: err => this.errorMessage = err
    });
  }
  incrementCounter(){
    this.itemCount++;
    this.disableMinusButton = false;
    this.oredersDetailsList.push(this.productDetails);
  }
  decrementCounter(){
    if(this.itemCount >1)
    {
        this.itemCount--;
        this.oredersDetailsList.pop();
    }
    if(this.itemCount <= 1 )
        this.disableMinusButton =true;
  }
  addToCart()
  {
    this.global.concatToOrderList(this.oredersDetailsList);
    this.orderProduct =  this.global.getOrderList();
    this.router.navigate(['/products']);
  }
}
