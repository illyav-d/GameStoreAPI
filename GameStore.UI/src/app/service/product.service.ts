import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Product } from '../models/product.model';



@Injectable({
  providedIn: 'root'
})
export class ProductService {
  productList: Product[] = []
  baseAPIURL: string = "http://localhost:5198/api"
  //user
  private key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Ikpvc0BtYWdhemlqbi5jb20iLCJuYW1lIjoiSm9zIERlIE1hZ2F6aWpuaWVyIiwicm9sZSI6IlVzZXIiLCJuYmYiOjE3MTgwMjY4ODUsImV4cCI6MjAzMzU1OTY4NSwiaWF0IjoxNzE4MDI2ODg1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUxOTgvIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MTk4LyJ9.erIPKCnk8U2GQlhc9-YnEZ8WgBkWH1QglKqIajIaN5M"
  //admin
  //private key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Ikpvc0BtYWdhemlqbi5jb20iLCJuYW1lIjoiSm9zIERlIE1hZ2F6aWpuaWVyIiwicm9sZSI6IkFkbWluIiwibmJmIjoxNzE4MDI2NzcyLCJleHAiOjIwMzM1NTk1NzIsImlhdCI6MTcxODAyNjc3MiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MTk4LyIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTE5OC8ifQ.sq-D8K6lSR21BLxYtMjdpDnwog_Mg3itVtzZ0X8IXYQ"
  
  constructor(private httpClient: HttpClient) { }



  retrieveAllProducts(page: number = 1): Observable<Array<Product>> {
    const headers = new HttpHeaders({
      Authorization: `bearer ${this.key}`,
    });
    return this.httpClient.get<Array<Product>>(`${this.baseAPIURL}/GameProduct/GetAllGameProducts?page=${page}&items=9`, { headers })
  };

  retrieveAllActiveProducts(page: number = 1): Observable<Array<Product>> {
    return this.httpClient.get<Array<Product>>(`${this.baseAPIURL}/GameProduct/GetAllActiveGameProducts?page=${page}&items=9`);
  };

  retrieveAllActiveProductsByGenre(genre: number, page: number = 1): Observable<Array<Product>> {
    this.productList = [];
    return this.httpClient.get<Array<Product>>(`${this.baseAPIURL}/GameProduct/GetGameProductByGenreID?genreID=${genre}&page=${page}&items=9
    `)
  };

  retrieveAllActiveProductsByPlatform(platform: number, page: number = 1): Observable<Array<Product>> {
    this.productList = [];
    return this.httpClient.get<Array<Product>>(`${this.baseAPIURL}/GameProduct/GetGameProductByPlatformID?platformID=${platform}&page=${page}&items=9
    `)
  };

  retrieveAllActiveProductsByUserInput(input: string, page: number = 1): Observable<Array<Product>> {
    this.productList = [];
    return this.httpClient.get<Array<Product>>(`${this.baseAPIURL}/GameProduct/GetGamesByUserInput?userInput=${input}&page=${page}&items=9
    `)
  };

  loadProductsInArray() {
    this.retrieveAllActiveProducts().subscribe((response: Array<Product>) => {
      console.log(response);
      this.productList = response;
    })
  }

  getProductById(id: number): Observable<Product> {
    return this.httpClient.get<Product>(`${this.baseAPIURL}/GameProduct/GetGameProductByID?id=${id}`)
  }


  updateProductStockByID(productId: number, stockAmount: number): Observable<void> {
    const headers = new HttpHeaders({
      Authorization: `bearer ${this.key}`,
    });

    const url = `${this.baseAPIURL}/GameProduct/UpdateGameProductStock?id=${productId}`;
    const body = { stock: stockAmount };
    console.log(url);
    console.log(body);
    return this.httpClient.put<void>(url, body, { headers });
  }

  updateProductActiveStatus(productId: number, status: any) {
    const headers = new HttpHeaders({
      Authorization: `bearer ${this.key}`,
    });
    const url = `${this.baseAPIURL}/GameProduct/UpdateGameProductActiveState?id=${productId}`;
    const body = { active: status };
    return this.httpClient.put<void>(url, body, { headers });
  }

  //default values because we will always work with user 1 due not knowing microsoft.identity
  addProductToShoppingCart(productId: number, amount: number = 1, userId: number = 1) {
    const headers = new HttpHeaders({
      Authorization: `bearer ${this.key}`,
    });
    const url = `${this.baseAPIURL}/ShoppingCartProduct/AddShoppingCartProduct`;
    const body = {
      userID: userId,
      gameProductID: productId,
      amount: amount
    };
    return this.httpClient.post(url, body, { headers });
  }


}




