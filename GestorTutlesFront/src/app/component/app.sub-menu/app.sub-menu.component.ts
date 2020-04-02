import { Component, OnInit, Input } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { MenuItem } from 'primeng/api';
import { AppComponent } from 'src/app/app.component';
import { AppMenuComponent } from '../app.menu/app.menu.component';

@Component({
  selector: '[app-submenu]',
  templateUrl: './app.sub-menu.component.html',
  styleUrls: ['./app.sub-menu.component.scss'],
  animations: [
    trigger('children', [
      state('visible', style({
        height: '*'
      })),
      state('hidden', style({
        height: '0px'
      })),
      transition('visible => hidden', animate('600ms cubic-bezier(0.86, 0, 0.07, 1)')),
      transition('hidden => visible', animate('600ms cubic-bezier(0.86, 0, 0.07, 1)'))
    ])
  ]
})
export class AppSubMenuComponent {
  @Input() item: MenuItem;
  @Input() root: boolean;

  activeIndex: number;

  hover: boolean;

  constructor(public app: AppComponent, public appMenu: AppMenuComponent) {
  }

  itemClick(event: Event, item: MenuItem, index: number) {
    // avoid processing disabled items
    if (item.disabled) {
      event.preventDefault();
      return true;
    }

    // activate current item and deactivate active sibling if any
    if (item.routerLink || item.items || item.command || item.url) {
      this.activeIndex = (this.activeIndex as number === index) ? -1 : index;
    }

    // execute command
    if (item.command) {
      item.command({ originalEvent: event, item: item });
    }

    // prevent hash change
    if (item.items || (!item.url && !item.routerLink)) {
      setTimeout(() => {
        this.appMenu.layoutMenuScrollerViewChild.moveBar();
      }, 450);
      event.preventDefault();
    }

    // hide menu
    if (!item.items) {
      this.app.sidebarActive = false;
    }
  }

  isActive(index: number): boolean {
    return this.activeIndex === index;
  }

}
