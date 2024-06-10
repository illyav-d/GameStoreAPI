import { Component } from '@angular/core';
import { Product } from '../../../models/product.model';
import { ProductService } from '../../../service/product.service';
import { ActivatedRoute } from '@angular/router';
import { HeaderVisibilityService } from '../../../service/headerdisplay.service';

@Component({
  selector: 'app-genre-product-list',
  templateUrl: './genre-product-list.component.html',
  styleUrl: './genre-product-list.component.css'
})
export class GenreProductListComponent {
  productList: Product[] = []
  currentPage: number = 1;
  itemsPerPage: number = 9;
  hasMorePages: boolean = true;

  constructor(private productService: ProductService, private route: ActivatedRoute, private headerVisibilityService: HeaderVisibilityService) {
    this.loadProductsInArray(this.currentPage);
  }
  loadProductsInArray(currentPage: number) {
    this.route.params.subscribe(parameters => {
      const genreID = parameters['genreid']
      this.productList = [];
      this.productService.retrieveAllActiveProductsByGenre(genreID, currentPage).subscribe(listProductsByGenre => {
        this.productList = listProductsByGenre
        console.log(listProductsByGenre)
      })
      this.checkHasMorePages(genreID);
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
  checkHasMorePages(genreID: number): void {
    this.productService.retrieveAllActiveProductsByGenre(genreID, this.currentPage + 1).subscribe(response => {
      this.hasMorePages = response.length > 0;
    }, error => {
      this.hasMorePages = false;
    });
  }
}
