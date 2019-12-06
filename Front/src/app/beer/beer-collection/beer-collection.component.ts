import { Component, OnInit } from '@angular/core';
import { BeerService } from '../beer.service';
import { Beer } from '../Models/beer';

@Component({
  selector: 'app-beer-collection',
  templateUrl: './beer-collection.component.html',
  styleUrls: ['./beer-collection.component.scss']
})
export class BeerCollectionComponent implements OnInit {

  beers: Beer[];
  
  constructor(private beerService: BeerService) { }

  ngOnInit() {
    this.beerService.getBeers().subscribe({
      next: beers => {
        this.beers = beers;
      }
    });
  }

}
