import { Component } from '@angular/core';
import { User } from '../../models/user.model';

import { OrderService } from '../../service/order.service';
import { ShoppingCartService } from '../../service/shopping-cart.service';
import { Order } from '../../models/order.model';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrl: './order-list.component.css'
})
export class OrderListComponent {
  currentUser!: User;
  orderList: Order[] = [];

  constructor(private shoppingCartService: ShoppingCartService, private orderService: OrderService) {
    this.loadProductsInArray();
    this.loadUser();
  }


  loadProductsInArray() {
    this.orderService.getAllOrders().subscribe((response: Array<Order>) => {
      this.orderList = response;
    })
  }

  loadUser() {
    this.shoppingCartService.retrieveUserWithShoppingCart().subscribe((response: User) => {
      this.currentUser = response;
    }
    )
  }
}
