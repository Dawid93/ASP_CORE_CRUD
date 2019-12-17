import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BeerCollectionComponent } from './beer/beer-collection/beer-collection.component';
import { BeerFormComponent } from './beer/beer-form/beer-form.component';
import { BeerDetailComponent } from './beer/beer-detail/beer-detail.component';
import { BeerTypeCollectionComponent } from './beer/beer-type-collection/beer-type-collection.component';


const routes: Routes = [
  { path: 'beers', component: BeerCollectionComponent },
  { path: 'beers/:beerId', component: BeerDetailComponent },
  { path: 'beers/:beerId/edit', component: BeerFormComponent },
  { path: 'beerType', component: BeerTypeCollectionComponent },
  { path: '', redirectTo: 'beers', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
