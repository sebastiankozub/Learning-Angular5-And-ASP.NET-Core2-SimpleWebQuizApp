import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-component2',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount = this.currentCount + 2;
  }
}
