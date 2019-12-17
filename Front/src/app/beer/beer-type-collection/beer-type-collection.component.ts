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

  editElement() {

  }

  deleteElement(beerType: BeerTypeDto) {
    if (confirm(`Really delete this beer type: ${beerType.beerTypeName}?`)) {
      this.beerTypeService.deleteBeerType(beerType.beerTypeId).subscribe(
        (res) => console.log(res),
        (err) => console.log(err)
      );
    }
  }

}
