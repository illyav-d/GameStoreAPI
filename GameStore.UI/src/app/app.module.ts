import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { HeaderComponent } from './components/ui/headers/generalHeader/header.component';
import { AppComponent } from './app.component';
import { FooterComponent } from './components/ui/footer/footer.component';
import { HomepageComponent } from './components/homepage/homepage.component';
import { ProductlistComponent } from './components/product/productlist/productlist.component';
import { NavbarComponent } from './components/ui/headers/genrePlatformHeader/navbar.component';
import { GenreProductListComponent } from './components/product/genre-product-list/genre-product-list.component';
import { CommonModule } from '@angular/common';
import { DetailedproductComponent } from './components/product/detailedproduct/detailedproduct.component';
import { AdminProductManagementComponent } from './components/admin/admin-product-management/admin-product-management.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ShoppingcartComponent } from './components/shoppingcart/shoppingcart.component';
import { OrderListComponent } from './components/order-list/order-list.component';
import { PlatformProductListComponent } from './components/product/platform-product-list/platform-product-list.component';
import { AdminHeaderComponent } from './components/ui/headers/admin-header/admin-header.component';
import { AdminUserManagementComponent } from './components/admin/admin-user-management/admin-user-management.component';
import { AdminPlatformGenreManagementComponent } from './components/admin/admin-platform-genre-management/admin-platform-genre-management.component';
import { ProductListByUserInputComponent } from './components/product/product-list-by-user-input/product-list-by-user-input.component';
import { LoadingspinnerComponent } from './components/loadingspinner/loadingspinner.component';

@NgModule({
  declarations: [
    AppComponent, ShoppingcartComponent, HeaderComponent, FooterComponent, HeaderComponent, HomepageComponent, NavbarComponent, GenreProductListComponent, ProductlistComponent, DetailedproductComponent, AdminProductManagementComponent, OrderListComponent, PlatformProductListComponent, AdminHeaderComponent, AdminUserManagementComponent, AdminPlatformGenreManagementComponent, ProductListByUserInputComponent, LoadingspinnerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
