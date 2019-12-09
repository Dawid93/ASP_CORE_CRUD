import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Beer } from './Models/beer';

@Injectable({
  providedIn: 'root'
})
export class BeerService {
  private beerControllerApi: string = 'http://localhost:50001/api/beer';

  constructor(private http: HttpClient) { }

  getBeers(): Observable<Beer[]> {
    return this.http.get<Beer[]>(this.beerControllerApi);
  }

  getBeer(id: string): Observable<Beer> {
    return this.http.get<Beer>(this.beerControllerApi + '/' + id);
  }
}
