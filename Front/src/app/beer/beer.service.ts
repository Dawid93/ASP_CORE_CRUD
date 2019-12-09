import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BeerDto } from './Models/beerDto';
import { BeerCreateDto } from './Models/beerCreateDto';

@Injectable({
  providedIn: 'root'
})
export class BeerService {
  readonly beerControllerApi: string = 'http://localhost:50001/api/beer';
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };

  constructor(private http: HttpClient) { }

  getBeers(): Observable<BeerDto[]> {
    return this.http.get<BeerDto[]>(this.beerControllerApi);
  }

  getBeer(id: string): Observable<BeerDto> {
    return this.http.get<BeerDto>(this.beerControllerApi + '/' + id);
  }

  postBeer(beer: BeerCreateDto) {
    return this.http.post<BeerCreateDto>(this.beerControllerApi, this.httpOptions);
  }
}
