import { Component, Input } from '@angular/core';
//import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'independent-quiz',
  templateUrl: './independent-quiz.component.html',
  styleUrls: ['./independent-quiz.component.css']
})

export class IndependentQuizComponent {
  @Input("quiz") quiz: Quiz;
}
