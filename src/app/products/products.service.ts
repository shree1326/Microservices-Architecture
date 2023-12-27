import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../Model/Product';
import configurl from '../../assets/config/config.json'
@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  url = configurl.apiServer.url + '/products?PageNumber=1&PageSize=5&order=ProductName_ASC';
  constructor(private http: HttpClient) { }
 
  public getProductList(PageNumber : number, PageSize : number, order: string): Observable<Product[]> {
    return this.http.get<Product[]>(this.url);
  }
  public postProductData(productData: Product): Observable<Product> {
    const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
    return this.http.post<Product>(this.url, productData, httpHeaders);
  }
  public updateProduct(product: Product): Observable<Product> {
    const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
    return this.http.put<Product>(this.url, product, httpHeaders);
  }
  public deleteProductById(id: number): Observable<number> {
    return this.http.delete<number>(this.url + '/' + id);
  }
  public getProductDetailsById(id: string): Observable<Product> {
    return this.http.get<Product>(this.url + '/' + id);
  }
  
}