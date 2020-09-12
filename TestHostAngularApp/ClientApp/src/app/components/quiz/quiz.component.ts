import { Component, Input } from '@angular/core';
//import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})

export class QuizComponent {
  @Input("quiz") quiz: Quiz;
}
