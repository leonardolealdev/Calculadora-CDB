import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CalculadoraCdbService } from '../services/calculadora-cdb.service';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'app-calculadora-cdb',
  templateUrl: './calculadora-cdb.component.html',
  styleUrls: ['./calculadora-cdb.component.css']
})
export class CalculadoraCdbComponent {

  valor: number = 0;
  prazo: number = 0;
  resultadoBruto: number = 0;
  resultadoLiquido: number = 0;

  private toastr: ToastrService;
  private calculadoraCdbService: CalculadoraCdbService;

  constructor(toastr: ToastrService,
              calculadoraCdbService: CalculadoraCdbService) {
    this.calculadoraCdbService = calculadoraCdbService;
    this.toastr = toastr;
  }


  calcularCDB() {
    if (!this.camposValidos()) return;

    this.calculadoraCdbService.calcular(this.valor, this.prazo)
      .pipe(
        catchError((error) => {
          this.toastr.error('', 'Erro ao calcular');
          return of(null);
        })
      )
      .subscribe((data: any) => {
        console.log(data)
        this.resultadoBruto = data.data.valorBruto;
        this.resultadoLiquido = data.data.valorLiquido;
      });
  }

  camposValidos(): boolean {
    if (this.prazo < 1) {
      this.toastr.warning("Prazo deve ser maior que 1");
      return false;
    }

    if (this.valor < 0) {
      this.toastr.warning("Valor deve ser positivo");
      return false;
    }

    return true;
  }
}
