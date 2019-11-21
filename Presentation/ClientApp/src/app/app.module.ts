import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { LogInComponent } from './log-in/log-in.component';
import { GlobalsService } from './Shared/globals.service';
import { ProductListComponent } from './products/product-list/product-list.component';
import {CommonModule  } from '@angular/common';
import { StorageServiceModule} from 'angular-webstorage-service';
import { OrderModule } from 'ngx-order-pipe';
import { ProductModule } from './products/product.module';
import { MenuModule } from './nav-menu/menu.module';

@NgModule({
    declarations: [
        AppComponent,
        LogInComponent,
        ProductListComponent
    ],
    imports: [
        MenuModule,
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        StorageServiceModule,
        OrderModule,
        RouterModule.forRoot([
            { path: '', component: LogInComponent, pathMatch: 'full' },
            { path: 'products', component: ProductListComponent },
        ]),
        ProductModule
    ],
    
    providers: [GlobalsService],
    bootstrap: [AppComponent]
})
export class AppModule { }
