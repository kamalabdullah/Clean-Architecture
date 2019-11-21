import { Component, OnInit, OnChanges, Input } from '@angular/core';
import { GlobalsService } from '../Shared/globals.service';
import { IUser } from '../Models/IUser';
import { Router } from '@angular/router';
import { IProduct } from '../Models/IProduct';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit, OnChanges{
  currentUser :IUser;
   @Input() orderlist :IProduct[];
  ordersCount:number=0;
  constructor(private global:GlobalsService,private router: Router) { }
  logOut(){
    this.global.setLoggedInUser(null);
    this.global.clearOrderList();
    this.global.clearProductFilter();
    this.router.navigate(['']);
  }
  ngOnChanges(): void {
    if(this.orderlist!= null &&this.orderlist!= undefined)
    {
       this.ordersCount = this.orderlist.length;
    }
  }
  ngOnInit(): void {
    this.currentUser = this.global.getLoggedInUSer();
    this.orderlist = this.global.getOrderList();
  }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
