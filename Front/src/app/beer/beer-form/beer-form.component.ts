import { Component, OnInit } from '@angular/core';
import { BeerCreateDto } from '../Models/beerCreateDto';
import { BeerService } from '../beer.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-beer-form',
  templateUrl: './beer-form.component.html',
  styleUrls: ['./beer-form.component.scss']
})
export class BeerFormComponent implements OnInit {

  uploadForm: FormGroup;

  constructor(private beerService: BeerService, private formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.uploadForm = this.formBuilder.group({
      beerName: [''],
      beerDesc: [''],
      beerFile: ['']
    });
  }

  onFileChange(event) {
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      const file = event.target.files[0];
      console.log(file);
      this.uploadForm.get('beerFile').setValue(file);
      }
  }

  onSubmit() {
    const formData = new FormData();
    formData.append('beerImgFile', this.uploadForm.get('beerFile').value);
    formData.append('beerName', this.uploadForm.get('beerName').value);
    formData.append('beerDescription', this.uploadForm.get('beerDesc').value);
    console.log(formData.get('beerImgFile ' + 'beerName ' + 'beerDescription'));
    this.beerService.postBeer(formData).subscribe(
      (res) => console.log(res),
      (err) => console.log(err)
    );
  }
}
