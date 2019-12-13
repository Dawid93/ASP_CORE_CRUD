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
  readonly hostPath: string = 'http://localhost:50001';

  readonly httpOptions = {
    headers: new HttpHeaders({
      // 'Content-Type': 'multipart/form-data'
    })
  };

  constructor(private http: HttpClient) { }

  getBeerLabelSrc(filePath: string): string {
    return this.hostPath + filePath;
  }

  getBeers(): Observable<BeerDto[]> {
    return this.http.get<BeerDto[]>(this.beerControllerApi);
  }

  getBeer(id: string): Observable<BeerDto> {
    return this.http.get<BeerDto>(this.beerControllerApi + '/' + id);
  }

  postBeer(beer: FormData): Observable<BeerDto> {
    return this.http.post<BeerDto>(this.beerControllerApi, beer, this.httpOptions).pipe(map(response => response));
  }

  patchBeer(beer: FormData, id: string): Observable<{}> {
    return this.http.patch<{}>(this.beerControllerApi + '/' + id, beer, this.httpOptions).pipe(map(response => response));
  }

  putBeer(beer: FormData, id: string): Observable<{}> {
    return this.http.put<{}>(this.beerControllerApi + '/' + id, beer, this.httpOptions).pipe(map(response => response));
  }

  deleteBeer(id: string): Observable<{}> {
    return this.http.delete(this.beerControllerApi + '/' + id);
  }
}
