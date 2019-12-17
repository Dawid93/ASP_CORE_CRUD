import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { BeerTypeDto } from './Models/beerTypeDto';

@Injectable({
  providedIn: 'root'
})
export class BeerTypeService {

  readonly beerTypeControllerApi: string = 'http://localhost:50001/api/beerType';

  constructor(private http: HttpClient) { }

  getBeerTypes(): Observable<BeerTypeDto[]> {
    return this.http.get<BeerTypeDto[]>(this.beerTypeControllerApi);
  }

  getBeerType(beerTypeId: string): Observable<BeerTypeDto> {
    return this.http.get<BeerTypeDto>(this.beerTypeControllerApi + '/' + beerTypeId);
  }

  postBeerType(beerType: FormData): Observable<BeerTypeDto> {
    return this.http.post<BeerTypeDto>(this.beerTypeControllerApi, beerType);
  }
}
