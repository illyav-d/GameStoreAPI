import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
   //user
   private key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Ikpvc0BtYWdhemlqbi5jb20iLCJuYW1lIjoiSm9zIERlIE1hZ2F6aWpuaWVyIiwicm9sZSI6IlVzZXIiLCJuYmYiOjE3MTgwMjY4ODUsImV4cCI6MjAzMzU1OTY4NSwiaWF0IjoxNzE4MDI2ODg1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUxOTgvIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MTk4LyJ9.erIPKCnk8U2GQlhc9-YnEZ8WgBkWH1QglKqIajIaN5M"
   //admin
   //private key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Ikpvc0BtYWdhemlqbi5jb20iLCJuYW1lIjoiSm9zIERlIE1hZ2F6aWpuaWVyIiwicm9sZSI6IkFkbWluIiwibmJmIjoxNzE4MDI2NzcyLCJleHAiOjIwMzM1NTk1NzIsImlhdCI6MTcxODAyNjc3MiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MTk4LyIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTE5OC8ifQ.sq-D8K6lSR21BLxYtMjdpDnwog_Mg3itVtzZ0X8IXYQ"
   

  baseAPIURL: string = "http://localhost:5198/api"

  constructor(private httpClient: HttpClient) { }

  retrieveUserWithShoppingCart(): Observable<User> {
    const headers = new HttpHeaders({
      Authorization: `bearer ${this.key}`,
    });
    return this.httpClient.get<User>(`${this.baseAPIURL}/User/GetUserByID?id=1`, { headers })
  };
  updateCartAmountID(productId: number, quant: number): Observable<void> {
    const headers = new HttpHeaders({
      Authorization: `bearer ${this.key}`,
    });
    const url = `${this.baseAPIURL}/ShoppingCartProduct/UpdateShoppingItemAmount?id=${productId}`;
    const body = { amount: quant };
    console.log(url);
    console.log(body);
    return this.httpClient.put<void>(url, body, { headers });
  }
  removeProductById(productId: number) {
    const headers = new HttpHeaders({
      Authorization: `bearer ${this.key}`,
    });
    return this.httpClient.delete<User>(`${this.baseAPIURL}/ShoppingCartProduct/DeleteShoppingCartProduct?id=${productId}`, { headers })
  }
  
}
