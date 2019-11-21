import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { IProduct } from '../Models/IProduct';
import { HttpHeaders } from '@angular/common/http';
import { IFilter } from '../Models/IFilter';
import { Constants } from '../Shared/Constants';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };
  constructor(private location: Location,private http: HttpClient) { }

  // getProducts(): Observable<IProduct[]> {
  //   return this.http.get<IProduct[]>(this.getProductsUrl)
  //     .pipe(
  //       tap(data => JSON.stringify(data)),
  //       catchError(this.handleError)
  //     );
  // }
  getProducts(filter:IFilter): Observable<IProduct[]> {
    return this.http.post<IProduct[]>(Constants.getProductsUrl,filter,this.httpOptions)
      .pipe(
        tap(data => JSON.stringify(data)),
        catchError(this.handleError)
      );
  }
  getProductById(id:number): Observable<IProduct>{
    return this.http.get<IProduct>(Constants.getProductByIdUrl + id)
      .pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }
  submitUserProducts(userId:number,productIds:number[]){
    return this.http.post(location.origin + Constants.submitUserProductsUrl + userId, productIds , this.httpOptions)
      .pipe(catchError(this.handleError));
  }
  private handleError(err: HttpErrorResponse) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
