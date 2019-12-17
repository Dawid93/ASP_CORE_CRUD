import { Component, OnInit } from '@angular/core';
import { BeerTypeService } from '../beer-type.service';
import { BeerTypeDto } from '../Models/beerTypeDto';

@Component({
  selector: 'app-beer-type-collection',
  templateUrl: './beer-type-collection.component.html',
  styleUrls: ['./beer-type-collection.component.scss']
})
export class BeerTypeCollectionComponent implements OnInit {

  beerTypes: BeerTypeDto[];

  constructor(private beerTypeService: BeerTypeService) { }

  ngOnInit() {
    this.beerTypeService.getBeerTypes().subscribe({
      next: types => this.beerTypes = types
    });
  }

}
