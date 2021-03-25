import { CurrencyPipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { HttpClient, HttpRequest, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'my-app',
  templateUrl: './app.component.html',
  styleUrls: [ './app.component.css' ]
})
export class AppComponent  {
  _initial: number;
  _monthly: number;
  _target: number;
  _years: number;
  _risk: string;
  request: HttpRequest<string>;
  
  public lineChartData: ChartDataSets[] = [
    { data: [100, 120, 140, 160, 180, 200, 220], label: 'Flat Investment With No Risk' },
    { data: [110.2, 128, 150, 168, 193, 230, 280], label: 'Best Case' },
    { data: [90, 80, 70, 60, 50, 40, 20], label: 'Worse Case ' },
  ];
  public lineChartLabels: Label[] = ['2020', '2021', '2022', '2023', '2024', '2025', '2026'];
  public lineChartOptions: (ChartOptions & { annotation?: any }) = {
    responsive: true,
  };
  public lineChartColors: Color[] = [
    {
      borderColor: 'black',
      backgroundColor: 'rgba(255,0,0,0.3)',
    },
  ];
  public lineChartLegend = true;
  public lineChartType = 'line';
  public lineChartPlugins = [];

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  processResults(initialInvestment, monthlyInvestment, targetValue, years, riskLevel) {
    this._initial = initialInvestment;
    this._monthly = monthlyInvestment;
    this._target = targetValue;
    this._years = years;
    this._risk = riskLevel;

   //not working, perhaps setup environment wrong
    this.http.get(`'https://localhost:44332/riskcalculator?initialInvestment=${initialInvestment}&monthlyInvestment=${monthlyInvestment}&targetValue=${targetValue}&years=${years}&riskLevel=${riskLevel}'`, this.httpOptions)
    .subscribe(result => {console.log(result);});

    console.log(initialInvestment)
    console.log(monthlyInvestment)
    console.log(targetValue)
    console.log(years)
    console.log(riskLevel)
  }

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }
}
