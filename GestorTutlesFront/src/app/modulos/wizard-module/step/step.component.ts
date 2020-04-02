import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-step',
  templateUrl: './step.component.html',
  styleUrls: ['./step.component.scss']
})
export class StepComponent implements OnInit {
  @Input() styleClass: string;
  @Input() label: string;
  active: boolean = false;
  constructor() { }

  ngOnInit() {
  }


}
