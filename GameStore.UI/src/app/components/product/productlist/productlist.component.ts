import { Component } from '@angular/core';
import { Product } from '../../../models/product.model';
import { ProductService } from '../../../service/product.service';
import { HeaderVisibilityService } from '../../../service/headerdisplay.service';

@Component({
  selector: 'app-productlist',
  templateUrl: './productlist.component.html',
  styleUrl: './productlist.component.css'
})
export class ProductlistComponent {


  productList: Product[] = []
  currentPage: number = 1;
  itemsPerPage: number = 9;
  hasMorePages: boolean = true;



  constructor(private productService: ProductService, private headerVisibilityService: HeaderVisibilityService) {
    this.loadProductsInArray(this.currentPage);
  }

  loadProductsInArray(currentPage: number) {
    this.productService.retrieveAllActiveProducts(currentPage).subscribe((response: Array<Product>) => {
      this.productList = response;
      this.checkHasMorePages()
    })
  }

  addProductToCart(productId: number) {
    this.productService.addProductToShoppingCart(productId).subscribe(response => console.log(response));
  }
  ngOnInit() {
    this.headerVisibilityService.showHeader();
  }

  ngOnDestroy() {
    this.headerVisibilityService.hideHeader();
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
