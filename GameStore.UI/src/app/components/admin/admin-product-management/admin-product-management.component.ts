import { Component } from '@angular/core';
import { Product } from '../../../models/product.model';
import { ProductService } from '../../../service/product.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-admin-management',
  templateUrl: './admin-product-management.component.html',
  styleUrl: './admin-product-management.component.css'
})
export class AdminProductManagementComponent {
  productList: Product[] = []
  productForms: { [key: number]: FormGroup } = {};
  currentPage: number = 1;
  itemsPerPage: number = 9;
  hasMorePages: boolean = true;


  constructor(private productService: ProductService, private formBuilder: FormBuilder) {
    this.loadProductsInArray(this.currentPage);
  }

  loadProductsInArray(currentPage: number) {
    this.productService.retrieveAllProducts(currentPage).subscribe((response: Array<Product>) => {
      this.productList = response;
      this.productList.forEach(product => {
        this.productForms[product.id] = this.formBuilder.group({
          stockAmount: [product.stock],
          active: [product.active]
        });
      });
    });
    this.checkHasMorePages();
  }

  onEditStock(productId: number): void {
    const newStockAmount = this.productForms[productId].get('stockAmount')?.value;
    this.productService.updateProductStockByID(productId, newStockAmount).subscribe(() => {
      this.loadProductsInArray(this.currentPage);
      console.log(newStockAmount);
    });
  }


  onToggleActive(productId: number): void {
    const isActive = this.productForms[productId].get('active')?.value;
    this.productService.updateProductActiveStatus(productId, isActive).subscribe(() => {
      this.loadProductsInArray(this.currentPage);
    });
  }
  nextPage(): void {
    if (this.hasMorePages) {
      this.currentPage++;
      this.loadProductsInArray(this.currentPage);
    }

  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadProductsInArray(this.currentPage);
    }
  }
  checkHasMorePages(): void {
    this.productService.retrieveAllActiveProducts(this.currentPage + 1).subscribe(response => {
      this.hasMorePages = response.length > 0;
    }, error => {
      this.hasMorePages = false;
    });
  }

}
