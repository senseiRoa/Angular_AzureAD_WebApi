import { Component, OnInit, ViewChild, AfterViewInit, Input } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { transition, animate, trigger, state, style } from '@angular/animations';
import { ScrollPanel } from 'primeng/scrollpanel';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-menu',
  templateUrl: './app.menu.component.html',
  styleUrls: ['./app.menu.component.scss']
})
export class AppMenuComponent implements OnInit, AfterViewInit {

  model: any[];

  @ViewChild('scrollPanel', null) layoutMenuScrollerViewChild: ScrollPanel;

  constructor(public app: AppComponent) { }

  ngAfterViewInit() {
    setTimeout(() => { this.layoutMenuScrollerViewChild.moveBar(); }, 100);
  }

  ngOnInit() {
    this.model = [
      { label: 'Mis Solicitudes', routerLink: ['/Home'] },
      { label: 'Registrar Solicitud', routerLink: ['/Habilitacion'] },
      { label: 'Salir', routerLink: ['/login'] }
    ];
  }
}
