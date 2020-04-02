import { Component, OnInit, AfterContentInit, OnChanges, Input, Output, EventEmitter, ContentChildren, QueryList, SimpleChanges } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { StepComponent } from '../step/step.component';

@Component({
  selector: 'app-steps',
  templateUrl: './steps.component.html',
  styleUrls: ['./steps.component.scss']
})
export class StepsComponent implements OnInit, AfterContentInit, OnChanges {
  @Input() activeIndex: number = 0;
  @Input() styleClass: string;
  @Input() stepClass: string;
  @Output() activeIndexChange: EventEmitter<any> = new EventEmitter();
  @Output() change = new EventEmitter();

  items: MenuItem[] = [];

  @ContentChildren(StepComponent) steps: QueryList<StepComponent>;
  constructor() { }

  ngOnInit() {
  }

  ngAfterContentInit() {
    this.steps.toArray().forEach((step: StepComponent, index: number) => {
      if (!step.styleClass) {
        // set style class if it was not set on step component directly
        step.styleClass = this.stepClass;
      }

      if (index === this.activeIndex) {
        // show this step on init
        step.active = true;
      }

      this.items[index] = {
        label: step.label,
        command: (event: any) => {
          // hide all steps
          this.steps.toArray().forEach((s: StepComponent) => s.active = false);

          // show the step the user has clicked on.
          step.active = true;
          this.activeIndex = index;

          // emit currently selected index (two-way binding)
          this.activeIndexChange.emit(index);
          // emit currently selected label
          //this.change.next('dede ngAfterContentInit '+step.label);
        }
      };
    });
  }

  ngOnChanges(changes: SimpleChanges) {
    console.log('En ngONchange');
    if (!this.steps) {
      // we could also check changes['activeIndex'].isFirstChange()
      return;
    }

    for (let prop in changes) {
      if (prop === 'activeIndex') {
        let curIndex = changes[prop].currentValue;
        this.steps.toArray().forEach((step: StepComponent, index: number) => {
          // show / hide the step
          // console.log(step);
          let selected = index === curIndex;
          step.active = selected;

          if (selected) {
            // emit currently selected label
            this.change.emit(' ngOnChanges' + step.label);
          }
        });
      }
    }
  }

  private previous() {
    console.log('previous');
    this.activeIndex--;
    // emit currently selected index (two-way binding)
   // this.activeIndexChange.emit(this.activeIndex);
    // show / hide steps and emit selected label
    this.ngOnChanges({
      activeIndex: {
        currentValue: this.activeIndex,
        previousValue: this.activeIndex + 1,
        firstChange: false,
        isFirstChange: () => false
      }
    });
  }

  private next() {
    console.log('next');
    this.activeIndex++;
    // emit currently selected index (two-way binding)
    //this.activeIndexChange.emit(this.activeIndex);
    // show / hide steps and emit selected label
    this.ngOnChanges({
      activeIndex: {
        currentValue: this.activeIndex,
        previousValue: this.activeIndex - 1,
        firstChange: false,
        isFirstChange: () => false
      }
    });
  }
}
