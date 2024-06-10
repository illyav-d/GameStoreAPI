import { Component } from '@angular/core';
import { Product } from '../../../models/product.model';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../../../service/product.service';


@Component({
  selector: 'app-detailedproduct',
  templateUrl: './detailedproduct.component.html',
  styleUrl: './detailedproduct.component.css'
})
export class DetailedproductComponent {
  product!: Product

  constructor(private productService: ProductService, private route: ActivatedRoute) {
    this.loadProductToArray();
  }

  loadProductToArray() {
    this.route.params.subscribe(parameters => {
      const productId = parameters['productid']
      this.productService.getProductById(productId).subscribe(detailedProduct => {
        this.product = detailedProduct
        console.log(detailedProduct)
      })
    })
  }

  addProductToCart(productId: number) {
    this.productService.addProductToShoppingCart(productId).subscribe(response => this.loadProductToArray());

  }
}
