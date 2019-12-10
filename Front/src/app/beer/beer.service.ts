import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BeerDto } from './Models/beerDto';
import { catchError, tap, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BeerService {
  readonly beerControllerApi: string = 'http://localhost:50001/api/beer';
  readonly httpOptions = {
    headers: new HttpHeaders({
      // 'Content-Type': 'multipart/form-data'
    })
  };

  constructor(private http: HttpClient) { }

  getBeers(): Observable<BeerDto[]> {
    return this.http.get<BeerDto[]>(this.beerControllerApi);
  }

  getBeer(id: string): Observable<BeerDto> {
    return this.http.get<BeerDto>(this.beerControllerApi + '/' + id);
  }

  postBeer(beer: FormData) {
    return this.http.post<FormData>(this.beerControllerApi, beer, this.httpOptions);
  }
}
