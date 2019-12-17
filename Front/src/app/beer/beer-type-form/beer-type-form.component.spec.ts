import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BeerTypeFormComponent } from './beer-type-form.component';

describe('BeerTypeFormComponent', () => {
  let component: BeerTypeFormComponent;
  let fixture: ComponentFixture<BeerTypeFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BeerTypeFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BeerTypeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
