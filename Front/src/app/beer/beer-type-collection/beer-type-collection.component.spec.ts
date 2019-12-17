import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BeerTypeCollectionComponent } from './beer-type-collection.component';

describe('BeerTypeCollectionComponent', () => {
  let component: BeerTypeCollectionComponent;
  let fixture: ComponentFixture<BeerTypeCollectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BeerTypeCollectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BeerTypeCollectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
