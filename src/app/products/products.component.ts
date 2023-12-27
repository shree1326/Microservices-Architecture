import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductsService } from '../products/products.service';
import { Product } from '../Model/Product';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import {MatPaginatorModule, MatPaginatorIntl} from '@angular/material/paginator';
import {Subject} from 'rxjs';
@Component({
    selector: 'app-products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit, MatPaginatorIntl {
    changes = new Subject<void>();
    ProductList ? : Observable < Product[] > ;
    ProductList1 ? : Observable < Product[] > ;
    productForm: any;
    productId = 0;
    PageNo = 1;
    PageSize = 2;
    SortOrder='ProductId_ASC';
    constructor(private formbulider: FormBuilder, private productService: ProductsService, private router: Router, private toastr: ToastrService) {}
    ngOnInit() {
        this.productForm = this.formbulider.group({
            productName: ['', [Validators.required]],
            productPrice: ['', [Validators.required]],
            productDescription: ['', [Validators.required]],
            productStock: ['', [Validators.required]]
        });
        this.getProductList(this.PageNo, this.PageSize, this.SortOrder);
    }
    
    getProductList(PageNo : number, PageSize  : number, SortOrder: string) {
        this.ProductList1 = this.productService.getProductList(PageNo, PageSize, SortOrder) ;
        this.ProductList = this.ProductList1;
    }
    PostProduct(product: Product) {
        const product_Master = this.productForm.value;
        this.productService.postProductData(product_Master).subscribe(
            () => {
                this.getProductList(this.PageNo, this.PageSize, this.SortOrder);
                this.productForm.reset();
                this.toastr.success('Data Saved Successfully');
            });
    }
    ProductDetailsToEdit(id: string) {
        this.productService.getProductDetailsById(id).subscribe(productResult => {
            this.productId = productResult.productId;
            this.productForm.controls['productName'].setValue(productResult.productName);
            this.productForm.controls['productPrice'].setValue(productResult.productPrice);
            this.productForm.controls['productDescription'].setValue(productResult.productDescription);
            this.productForm.controls['productStock'].setValue(productResult.productStock);
        });
    }
    UpdateProduct(product: Product) {
        product.productId = this.productId;
        const product_Master = this.productForm.value;
        this.productService.updateProduct(product_Master).subscribe(() => {
            this.toastr.success('Data Updated Successfully');
            this.productForm.reset();
            this.getProductList(this.PageNo, this.PageSize, this.SortOrder);
        });
    }
    DeleteProduct(id: number) {
        if (confirm('Do you want to delete this product?')) {
            this.productService.deleteProductById(id).subscribe(() => {
                this.toastr.success('Data Deleted Successfully');
                this.getProductList(this.PageNo, this.PageSize, this.SortOrder);
            });
        }
    }
    Clear(product: Product) {
        this.productForm.reset();
    }

    firstPageLabel = $localize`First page`;
  itemsPerPageLabel = $localize`Items per page:`;
  lastPageLabel = $localize`Last page`;

  // You can set labels to an arbitrary string too, or dynamically compute
  // it through other third-party internationalization libraries.
  nextPageLabel = 'Next page';
  previousPageLabel = 'Previous page';

  getRangeLabel(page: number, pageSize: number, length: number): string {
    if (length === 0) {
      return $localize`Page 1 of 1`;
    }
    const amountPages = Math.ceil(length / pageSize);
    return $localize`Page ${page + 1} of ${amountPages}`;
  }
}