import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void{
    this.http.get('https://localhost:44393/api/eventos')
      .subscribe(response => this.eventos = response,
        error => console.log(error)
    );



    this.eventos =[
      {
        Tema: 'Angular 11',
        Local: 'Praia Grande'
      },
      {
        Tema: '.Net 5',
        Local: 'São Paulo'
      },
      {
        Tema: 'Angular e suas Novidades',
        Local: 'Rio de Janeiro'
      }
    ];
  }

}
