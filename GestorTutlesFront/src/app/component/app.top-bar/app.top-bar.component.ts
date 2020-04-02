import { Component, OnInit, Input } from '@angular/core';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-topbar',
  templateUrl: './app.top-bar.component.html',
  styleUrls: ['./app.top-bar.component.scss']
})
export class AppTopBarComponent implements OnInit {


  @Input() showMenu;
  constructor(public app: AppComponent) {

  }

  ngOnInit() {

  }


}
