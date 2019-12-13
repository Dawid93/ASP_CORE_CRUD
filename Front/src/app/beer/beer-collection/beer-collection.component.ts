import { Component, OnInit } from '@angular/core';
import { BeerService } from '../beer.service';
import { BeerDto } from '../Models/beerDto';

@Component({
  selector: 'app-beer-collection',
  templateUrl: './beer-collection.component.html',
  styleUrls: ['./beer-collection.component.scss']
})
export class BeerCollectionComponent implements OnInit {

  beers: BeerDto[];

  constructor(private beerService: BeerService) { }

  ngOnInit() {
    this.beerService.getBeers().subscribe({
      next: beers => this.beers = beers
    });
  }

  createLabelSrc(fileSrc: string) {
    return this.beerService.getBeerLabelSrc(fileSrc);
  }

}
