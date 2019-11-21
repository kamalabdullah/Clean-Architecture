import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { MenuModule } from '../nav-menu/menu.module';
import { CartComponent } from './cart/cart.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { FilterComponent } from './filter/filter.component';
import { NgxBootstrapSliderModule } from 'ngx-bootstrap-slider';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  imports: [
    MenuModule,
    CommonModule,
    BrowserAnimationsModule, 
    NgxBootstrapSliderModule,
    NgbModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
    }),
    RouterModule.forChild([
      { path: 'products', component: ProductListComponent },
      {
        path: 'products/:id',
        component: ProductDetailsComponent
      },
      {path:'cart',component:CartComponent},
      {path:'filter',component:FilterComponent}
    ])
  ],
  declarations: [ProductDetailsComponent, CartComponent, FilterComponent]
  
})
export class ProductModule { }
