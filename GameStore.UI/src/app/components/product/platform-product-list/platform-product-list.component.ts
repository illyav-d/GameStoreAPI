import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../../../service/product.service';
import { Product } from '../../../models/product.model';
import { HeaderVisibilityService } from '../../../service/headerdisplay.service';

@Component({
  selector: 'app-platform-product-list',
  templateUrl: './platform-product-list.component.html',
  styleUrl: './platform-product-list.component.css'
})
export class PlatformProductListComponent {
  productList: Product[] = []
  currentPage: number = 1;
  itemsPerPage: number = 9;
  hasMorePages: boolean = true;

  constructor(private productService: ProductService, private route: ActivatedRoute, private headerVisibilityService: HeaderVisibilityService) {
    this.loadProductsInArray(this.currentPage);
  }

  loadProductsInArray(currentPage: number) {
    this.route.params.subscribe(parameters => {
      const platformID = parameters['platformid']
      this.productList = [];
      this.productService.retrieveAllActiveProductsByPlatform(platformID, currentPage).subscribe(listProductsByPlatform => {
        this.productList = listProductsByPlatform
        console.log(listProductsByPlatform)
      })
      this.checkHasMorePages(platformID);
    });

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
  checkHasMorePages(platformID: number): void {
    this.productService.retrieveAllActiveProductsByPlatform(platformID, this.currentPage + 1).subscribe(response => {
      this.hasMorePages = response.length > 0;
    }, error => {
      this.hasMorePages = false;
    });
  }

}

