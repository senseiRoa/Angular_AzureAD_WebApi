import { ExpedienteDigitalService } from '../../../service/ExpedienteDigital.service';
import { DemoService } from './../../../service/Demo.service';
import { Component, OnInit } from '@angular/core';
import { RootObject } from 'src/service/RootObject';

@Component({
  selector: 'app-Home',
  templateUrl: './Home.component.html',
  styleUrls: ['./Home.component.css']
})
export class HomeComponent implements OnInit {
  data: RootObject[];

  constructor(private demoService: ExpedienteDigitalService) { }

  ngOnInit() {
    // this.demoService.getPublic().subscribe(r => {
    //   this.data = r;
    // });
  }

}
