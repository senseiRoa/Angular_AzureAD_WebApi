import { Component, OnInit } from '@angular/core';
import { DemoService } from 'src/service/Demo.service';
import { RootObject } from 'src/service/RootObject';

@Component({
  selector: 'app-Login',
  templateUrl: './Login.component.html',
  styleUrls: ['./Login.component.css']
})
export class LoginComponent implements OnInit {
  data: RootObject[];
  constructor(private demoService: DemoService) { }

  ngOnInit() {
    this.demoService.getPrivate().subscribe(r => {
      this.data = r;
    });
  }
}
