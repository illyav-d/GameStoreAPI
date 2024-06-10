import { Component } from '@angular/core';
import { ShoppingCartItem } from '../../models/shopping-cart-item';
import { ShoppingCartService } from '../../service/shopping-cart.service';
import { User } from '../../models/user.model';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CheckoutService } from '../../service/checkout.service';

@Component({
  selector: 'app-shoppingcart',
  templateUrl: './shoppingcart.component.html',
  styleUrl: './shoppingcart.component.css'
})
export class ShoppingcartComponent {
  shoppingCartList: ShoppingCartItem[] = [];
  currentUser!: User;
  productForms: { [key: number]: FormGroup } = {};

  constructor(private shoppingCartService: ShoppingCartService, private checkoutService: CheckoutService, private formBuilder: FormBuilder) {
    this.loadShoppingCart();
  }
  loadShoppingCart() {
    this.shoppingCartService.retrieveUserWithShoppingCart().subscribe((response: User) => {
      this.shoppingCartList = response.shoppingCartProducts;
      this.currentUser = response;
      this.shoppingCartList.forEach(sCartProduct => {
        this.productForms[sCartProduct.id] = this.formBuilder.group({
          cartItemAmount: [sCartProduct.amount]
        });
      });
    })
  }
  onEditCartItemAmount(sCartProductId: number): void {
    const newCartAmount = this.productForms[sCartProductId].get('cartItemAmount')?.value;
    this.shoppingCartService.updateCartAmountID(sCartProductId, newCartAmount).subscribe(() => {
      this.loadShoppingCart();
      console.log(newCartAmount);
    });
  }
  onRemoveProduct(productId: number): void {
    this.shoppingCartService.removeProductById(productId).subscribe(() => {
      this.loadShoppingCart();
    });
  }

  onCheckOut(userID: number) {
    this.checkoutService.CheckoutUser(userID).subscribe(() => {
      this.loadShoppingCart();
    });
  }


}



