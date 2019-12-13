import { Component, OnInit } from '@angular/core';
import { BeerService } from '../beer.service';
import { ActivatedRoute } from '@angular/router';
import { BeerDto } from '../Models/beerDto';

@Component({
  selector: 'app-beer-detail',
  templateUrl: './beer-detail.component.html',
  styleUrls: ['./beer-detail.component.scss']
})
export class BeerDetailComponent implements OnInit {

  beer: BeerDto;

  constructor(private beerService: BeerService, private route: ActivatedRoute) { }

  ngOnInit() {
    let id = this.route.snapshot.paramMap.get('beerId');
    this.beerService.getBeer(id).subscribe({
      next: beer => { this.beer = beer; }
    });
  }

}