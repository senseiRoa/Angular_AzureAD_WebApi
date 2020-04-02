import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioPublicoComponent } from './formulario-publico.component';

describe('FormularioPublicoComponent', () => {
  let component: FormularioPublicoComponent;
  let fixture: ComponentFixture<FormularioPublicoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormularioPublicoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormularioPublicoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
