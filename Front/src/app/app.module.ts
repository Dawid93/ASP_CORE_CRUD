import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BeerCollectionComponent } from './beer/beer-collection/beer-collection.component';
import { BeerFormComponent } from './beer/beer-form/beer-form.component';
import { BeerDetailComponent } from './beer/beer-detail/beer-detail.component';
import { from } from 'rxjs';

@NgModule({
  declarations: [
    AppComponent,
    BeerCollectionComponent,
    BeerFormComponent,
    BeerDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
