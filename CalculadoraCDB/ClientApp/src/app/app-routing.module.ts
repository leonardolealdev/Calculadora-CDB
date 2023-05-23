import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CalculadoraCdbComponent } from './calculadora-cdb/calculadora-cdb.component';

const routes: Routes = [
  { path: '', redirectTo: 'calculadora-cdb', pathMatch: 'full' },
  { path: 'calculadora-cdb', component: CalculadoraCdbComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
