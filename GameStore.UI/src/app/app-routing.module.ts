import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './components/homepage/homepage.component';
import { ShoppingcartComponent } from './components/shoppingcart/shoppingcart.component';
import { DetailedproductComponent } from './components/product/detailedproduct/detailedproduct.component';
import { GenreProductListComponent } from './components/product/genre-product-list/genre-product-list.component';
import { AdminProductManagementComponent } from './components/admin/admin-product-management/admin-product-management.component';
import { OrderListComponent } from './components/order-list/order-list.component';
import { PlatformProductListComponent } from './components/product/platform-product-list/platform-product-list.component';
import { AdminUserManagementComponent } from './components/admin/admin-user-management/admin-user-management.component';
import { AdminPlatformGenreManagementComponent } from './components/admin/admin-platform-genre-management/admin-platform-genre-management.component';
import { ProductListByUserInputComponent } from './components/product/product-list-by-user-input/product-list-by-user-input.component';
import { ProductlistComponent } from './components/product/productlist/productlist.component';


const routes: Routes = [
  { path: '', component: HomepageComponent },
  { path: 'yourcart', component: ShoppingcartComponent },
  { path: 'admin/product', component: AdminProductManagementComponent },
  { path: 'admin/users', component: AdminUserManagementComponent },
  { path: 'admin/genreplatform', component: AdminPlatformGenreManagementComponent },
  { path: 'yourorders', component: OrderListComponent },
  { path: 'products', component: ProductlistComponent },
  { path: 'products/:productid', component: DetailedproductComponent },
  { path: 'products/genre/:genreid', component: GenreProductListComponent },
  { path: 'products/platform/:platformid', component: PlatformProductListComponent },
  { path: 'products/search/userinput', component: ProductListByUserInputComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
