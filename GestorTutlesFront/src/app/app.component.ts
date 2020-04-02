import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Expendiente Digital';
  value: Date;
  sidebarActive: boolean;

  onMenuButtonClick(event: Event) {
      this.sidebarActive = !this.sidebarActive;

      event.preventDefault();
  }
}
