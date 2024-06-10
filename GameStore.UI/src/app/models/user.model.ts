import { ShoppingCartItem } from "./shopping-cart-item";

export interface User {
    id: number,
    name: string,
    active: boolean,
    totalPriceOfCart: number,
    shoppingCartProducts: ShoppingCartItem[]
}
