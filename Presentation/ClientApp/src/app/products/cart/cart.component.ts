import { Component, OnInit } from '@angular/core';
import { IUser } from 'src/app/Models/IUser';
import { IProduct } from 'src/app/Models/IProduct';
import { GlobalsService } from 'src/app/Shared/globals.service';
import { Router } from '@angular/router';
import * as _ from 'lodash';
import { ProductService } from 'src/app/Services/product.service';
import { ToastrService, GlobalConfig } from 'ngx-toastr';
import { cloneDeep } from 'lodash';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  user:IUser;
  orderProduct:IProduct[];
  uniqOrderList:IProduct[];
  totalAmount:number = 0;
  options: GlobalConfig;
  constructor(private global:GlobalsService,private router: Router,private productService: ProductService,private toastr: ToastrService) { }

  ngOnInit() {
    this.user = this.global.getLoggedInUSer();
    if(this.user == null)
    {
      this.router.navigate(['']);
    }
    this.orderProduct = this.global.getOrderList();
    if (this.orderProduct && this.orderProduct.length)
    {
      var groupedArray = _.groupBy(this.orderProduct, "id");
      this.orderProduct.forEach(element => {
      element.count = groupedArray[element.id].length;
      });
      this.uniqOrderList = this.orderProduct.filter(function(elem, index, self) {
        return index === self.findIndex((t) => (
          t.id === elem.id
        ));
    });
      this.uniqOrderList.forEach(element => {
        this.totalAmount += element.price * element.count;
      });
    }
      this.options = this.toastr.toastrConfig;
  }
  deleteItemFromCart(itemId:number){
    this.totalAmount =0;
    this.uniqOrderList =  _.remove( this.uniqOrderList, function (el) {
      return  el.id !== itemId;
    });
    this.global.clearOrderList();
    this.global.concatToOrderList(this.uniqOrderList);
    this.uniqOrderList.forEach(element => {
      this.totalAmount += element.price * element.count;
    });
  }
  submitUserProducts(){
    let productIds = this.uniqOrderList.map(({ id }) => id);
    this.productService.submitUserProducts(this.user.id,productIds).subscribe(() => {
      this.openToast();
      this.global.clearOrderList();
      this.router.navigate(['/products']);
    });
  }
  openToast() {
    this.options.positionClass = 'toast-top-right';
    const opt = cloneDeep(this.options);
     this.toastr.show(
      "Your order has been submitted successfully",
      "success",
      this.options,
      this.options.iconClasses["success"],
    );
  }
}
