import { Component, OnInit } from '@angular/core';
import { BeerCreateDto } from '../Models/beerCreateDto';
import { BeerService } from '../beer.service';

@Component({
  selector: 'app-beer-form',
  templateUrl: './beer-form.component.html',
  styleUrls: ['./beer-form.component.scss']
})
export class BeerFormComponent implements OnInit {

  beerToSend: BeerCreateDto;

  constructor(private beerService: BeerService) { 
    this.beerToSend = new BeerCreateDto();
  }

  ngOnInit() {
  }

  onFileChange(event) {
    console.log(this.beerToSend);
    this.beerToSend.beerImgFile = event.target.files[0];
  }

  onClick() {
    this.beerService.postBeer(this.beerToSend);
  }
}
