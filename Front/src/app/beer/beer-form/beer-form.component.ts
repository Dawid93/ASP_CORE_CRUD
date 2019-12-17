import { Component, OnInit } from '@angular/core';
import { BeerService } from '../beer.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BeerDto } from '../Models/beerDto';
import { ActivatedRoute, Router } from '@angular/router';
import { BeerTypeService } from '../beer-type.service';
import { BeerTypeDto } from '../Models/beerTypeDto';

@Component({
  selector: 'app-beer-form',
  templateUrl: './beer-form.component.html',
  styleUrls: ['./beer-form.component.scss']
})
export class BeerFormComponent implements OnInit {

  private uploadForm: FormGroup;
  private id: string;
  private selectedType: BeerTypeDto;

  beerTypes: BeerTypeDto[];

  constructor(private beerService: BeerService, private beerTypeService: BeerTypeService,
              private formBuilder: FormBuilder, private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit() {
    this.uploadForm = this.formBuilder.group({
      beerName: [''],
      beerDescription: [''],
      beerImgFile: [''],
      beerTypeFK: ''
    });

    this.id = this.route.snapshot.paramMap.get('beerId');

    this.selectedType = new BeerTypeDto();

    if (this.id !== '0') {
      this.beerService.getBeer(this.id).subscribe({
        next: beer => {
          this.displayBeerData(beer);
          if (beer.beerTypeFK !== '') {
            this.getBeerType(beer);
          }
         }
      });
    }

    this.beerTypeService.getBeerTypes().subscribe({
      next: types => this.beerTypes = types
    });
  }

  displayBeerData(beer: BeerDto) {
    this.uploadForm.patchValue({
      beerName: beer.beerName,
      beerDescription: beer.beerDescription
    });
  }

  changeAddTypeValue(event: any) {
    console.log(event);
  }

  routeToDetails(id: string) {
    this.router.navigate(['/beers', id]);
  }

  onFileChange(event) {
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      const file = event.target.files[0];
      console.log(file);
      this.uploadForm.get('beerImgFile').setValue(file);
      }
  }

  setBeerType(beerType: BeerTypeDto) {
    this.selectedType = beerType;
    this.uploadForm.get('beerTypeFK').setValue(this.selectedType.beerTypeId);
  }

  getBeerType(beer: BeerDto) {
    this.beerTypeService.getBeerType(beer.beerTypeFK).subscribe({
      next: type => this.setBeerType(type)
    });
  }

  onSubmit() {
    const formData = new FormData();
    formData.append('beerImgFile', this.uploadForm.get('beerImgFile').value);
    formData.append('beerName', this.uploadForm.get('beerName').value);
    formData.append('beerDescription', this.uploadForm.get('beerDescription').value);
    formData.append('beerTypeFK', this.uploadForm.get('beerTypeFK').value);

    if (this.id === '0') {
      this.beerService.postBeer(formData).subscribe(
        (res) => this.router.navigate(['/beers', res.beerId]),
        (err) => console.log(err)
      );
    } else {
      this.beerService.putBeer(formData, this.id).subscribe({
        next: _ => this.router.navigate(['/beers', this.id])
      });
    }
  }
}
