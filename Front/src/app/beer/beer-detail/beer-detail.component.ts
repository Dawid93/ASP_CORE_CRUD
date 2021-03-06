import { Component, OnInit, AfterViewInit } from '@angular/core';
import { BeerService } from '../beer.service';
import { ActivatedRoute, Router } from '@angular/router';
import { BeerDto } from '../Models/beerDto';

@Component({
  selector: 'app-beer-detail',
  templateUrl: './beer-detail.component.html',
  styleUrls: ['./beer-detail.component.scss']
})
export class BeerDetailComponent implements OnInit {

  beer: BeerDto;

  constructor(private beerService: BeerService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('beerId');
    this.beerService.getBeer(id).subscribe({
      next: beer => {
        this.beer = beer;
      }
    });
  }

  createLabelSrc(fileSrc: string) {
    return this.beerService.getBeerLabelSrc(fileSrc);
  }

  deleteBeer(id: string) {
    return this.beerService.deleteBeer(id).subscribe({
      next: () => this.router.navigate(['/beers'])
    });
  }

}
