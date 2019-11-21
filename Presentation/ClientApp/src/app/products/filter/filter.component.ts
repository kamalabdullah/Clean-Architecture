import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { GlobalsService } from '../../Shared/globals.service';
import { Router } from '@angular/router';
import { IFilter } from '../../Models/IFilter';
import { min } from 'rxjs/operators';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {
 productFilter : IFilter = {maxPrice :100,minPrice:100};
  constructor(private toastr: ToastrService,private global:GlobalsService,private router: Router) { }

  ngOnInit() {
   var currentFilter = this.global.getProductFilter();
   if(currentFilter.minPrice > 0 && currentFilter.maxPrice > 0)
   {
    this.productFilter ={maxPrice:currentFilter.maxPrice,minPrice:currentFilter.minPrice};
   }
  }
  changeMin(){
     return +this.productFilter.minPrice;
  }
  changeMax(){
    return + this.productFilter.maxPrice;
  }
  applyFilter(){
    if(this.productFilter.minPrice > this.productFilter.maxPrice)
    {
      this.toastr.warning('Can not make min price greater than max','');
    }
    else{
        this.global.setProductFilter(this.productFilter.minPrice,this.productFilter.maxPrice);
        this.router.navigate(['/products']);
    }
  }
  clearFilter()
  {
    this.global.clearProductFilter();
    this.router.navigate(['/products']);
  }
}
