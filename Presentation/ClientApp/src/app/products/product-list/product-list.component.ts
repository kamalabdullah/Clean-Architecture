import { Component, OnInit, OnDestroy } from '@angular/core';
import { IProduct } from '../../Models/IProduct';
import { ProductService } from '../../Services/product.service';
import { GlobalsService } from '../../Shared/globals.service';
import { IUser } from '../../Models/IUser';
import { Router } from '@angular/router';
import { NavMenuComponent } from '../../nav-menu/nav-menu.component';
import { IFilter } from '../../Models/IFilter';
import { Subscription, SubscriptionLike } from "rxjs";

@Component({
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit,OnDestroy {
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
  private subscription: SubscriptionLike;
  products: IProduct[] = [];
  errorMessage = '';
  user:IUser;
  orderProduct:IProduct[];
  orderlist :IProduct[];
  productFilter:IFilter;
  constructor(private productService: ProductService,private global:GlobalsService,private router: Router) { }

  ngOnInit() : void {
    this.user = this.global.getLoggedInUSer();
    this.productFilter = this.global.getProductFilter();
    if(this.user == null)
    {
      this.router.navigate(['']);
    }
   this.subscription =  this.productService.getProducts(this.productFilter).subscribe({
      next: products => {
        this.products = products;
      },
      error: err => this.errorMessage = err
    });
    this.orderProduct = this.global.getOrderList();
  }
}
