import { Component } from '@angular/core';
import { ProductService } from '../../../service/product.service';
import { ActivatedRoute } from '@angular/router';
import { HeaderVisibilityService } from '../../../service/headerdisplay.service';
import { Product } from '../../../models/product.model';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-product-list-by-user-input',
  templateUrl: './product-list-by-user-input.component.html',
  styleUrl: './product-list-by-user-input.component.css'
})
export class ProductListByUserInputComponent {

  productList: Product[] = []
  query: string = '';
  currentPage: number = 1;
  itemsPerPage: number = 9;
  hasMorePages: boolean = true;


  constructor(private productService: ProductService, private route: ActivatedRoute, private headerVisibilityService: HeaderVisibilityService,private formBuilder:FormBuilder) {
    this.loadProductsInArray(this.currentPage);    
  }

  addProductToCart(productId: number) {
    this.productService.addProductToShoppingCart(productId).subscribe(response => console.log(response));
  }

  ngOnInit() {
    this.headerVisibilityService.showHeader();
  }


  loadProductsInArray(currentPage: number) {
    this.route.queryParams.subscribe(params => {
      this.query = params['query'] || '';
      this.productList = [];
      this.productService.retrieveAllActiveProductsByUserInput(this.query, currentPage).subscribe(listProductsByPlatform => {
        this.productList = listProductsByPlatform
        console.log(listProductsByPlatform)
      });
    });
    this.checkHasMorePages()
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
    this.productService.retrieveAllActiveProductsByUserInput(this.query, this.currentPage + 1).subscribe(response => {
      this.hasMorePages = response.length > 0;
    }, error => {
      this.hasMorePages = false;
    });
  }

 

}
