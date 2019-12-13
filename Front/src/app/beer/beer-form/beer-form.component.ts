import { Component, OnInit } from '@angular/core';
import { BeerService } from '../beer.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BeerDto } from '../Models/beerDto';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-beer-form',
  templateUrl: './beer-form.component.html',
  styleUrls: ['./beer-form.component.scss']
})
export class BeerFormComponent implements OnInit {

  private uploadForm: FormGroup;
  private id: string;

  constructor(private beerService: BeerService, private formBuilder: FormBuilder, private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit() {
    this.uploadForm = this.formBuilder.group({
      beerName: [''],
      beerDescription: [''],
      beerImgFile: ['']
    });

    this.id = this.route.snapshot.paramMap.get('beerId');
    if (this.id !== '0') {
      this.beerService.getBeer(this.id).subscribe({
        next: beer => this.displayBeerData(beer)
      });
    }
  }

  displayBeerData(beer: BeerDto) {
    this.uploadForm.patchValue({
      beerName: beer.beerName,
      beerDescription: beer.beerDescription
    });
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

  onSubmit() {
    const formData = new FormData();
    formData.append('beerImgFile', this.uploadForm.get('beerImgFile').value);
    formData.append('beerName', this.uploadForm.get('beerName').value);
    formData.append('beerDescription', this.uploadForm.get('beerDescription').value);
    if (this.id === '0') {
      this.beerService.postBeer(formData).subscribe(
        (res) => this.router.navigate(['/beers', res.beerId]),
        (err) => console.log(err)
      );
    } else {
      this.beerService.putBeer(formData, this.id).subscribe(
        (res) => this.router.navigate(['/beers', this.id]),
        (err) => console.log(err)
      );
    }
  }
}
