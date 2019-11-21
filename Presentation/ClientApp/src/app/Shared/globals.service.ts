import { Injectable, Inject } from '@angular/core';
import { IUser } from '../Models/IUser';
import {SESSION_STORAGE, WebStorageService} from 'angular-webstorage-service';
import { IProduct } from '../Models/IProduct';
import { IFilter } from '../Models/IFilter';
import { Constants } from './Constants';

@Injectable({
  providedIn: 'root'
})
export class GlobalsService {
private LoggedInUser : IUser = null;
public orderedItemList: IProduct[];
 productFilter:IFilter;
  constructor(@Inject(SESSION_STORAGE) private storage: WebStorageService) { }

  setLoggedInUser(user:IUser){
      this.LoggedInUser = user;
      this.storage.set(Constants.currentUserSessionKey,  this.LoggedInUser);
  }
  getLoggedInUSer():IUser{
    this.LoggedInUser = this.storage.get(Constants.currentUserSessionKey);
    return this.LoggedInUser;
  }
  getOrderList():IProduct[]{
    this.orderedItemList = this.storage.get(Constants.orderListSessionKey);
    return this.orderedItemList;
  }
  pushToOrderList(product:IProduct){
    if(this.orderedItemList == null)
      {
        this.orderedItemList = [];
      }
    this.orderedItemList.push(product);
    this.storage.set(Constants.orderListSessionKey,  this.orderedItemList);
}
concatToOrderList(productList:IProduct[]){
  if(this.orderedItemList == null)
    {
      this.orderedItemList = [];
    }
  Array.prototype.push.apply(this.orderedItemList,productList)
  this.storage.set(Constants.orderListSessionKey,  this.orderedItemList);
}
clearOrderList(){
  this.storage.set(Constants.orderListSessionKey,  null);
  this.orderedItemList = null;
}
 setProductFilter(minPrice:number,maxPrice:number)
{
    this.productFilter = {maxPrice:maxPrice,minPrice:minPrice}
    this.storage.set(Constants.productFilterSessionKey,   this.productFilter);
}
getProductFilter():IFilter{
  this.productFilter = this.storage.get(Constants.productFilterSessionKey);
  if(this.productFilter == null || this.productFilter == undefined)
    this.productFilter = {minPrice:0,maxPrice:0};
  return this.productFilter;
}
clearProductFilter(){
  this.storage.set(Constants.productFilterSessionKey,  null);
  this.productFilter = null;
}
}
