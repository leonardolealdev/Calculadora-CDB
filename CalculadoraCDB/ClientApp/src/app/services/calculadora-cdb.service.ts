import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CalculadoraCdbService {
  public _baseURL = "";
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this._baseURL = baseUrl;     
  }


  calcular(valor: any, prazo: any) {
    return this.http.post(this._baseURL + `calculadora`, { valor: valor, prazo: prazo });
  }
}
