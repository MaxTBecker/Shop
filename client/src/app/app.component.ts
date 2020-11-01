import { HttpClient } from '@angular/common/http';
import { IProduct } from 'F:/angular/OnlineShop/client/src/models/product';
import { IPagination } from 'F:/angular/OnlineShop/client/src/models/pagination';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'Online Shop';
  products: IProduct[];
  constructor(private http: HttpClient)
  {

  }
  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/product').subscribe(
      (response: any) =>
    {
      this.products = response;
    }, error =>
    {
      console.log(error);
    });
  }
}
