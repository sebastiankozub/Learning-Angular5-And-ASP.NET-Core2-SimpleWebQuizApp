import { Component, Inject, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'independent-quiz-list',
  templateUrl: './independent-quiz-list.component.html',
  styleUrls: ['./independent-quiz-list.component.css']
})

export class IndependentQuizListComponent implements OnInit {
  @Input() class: string;
  title: string;
  selectedQuiz: Quiz;
  quizzes: Quiz[];
  http: HttpClient;
  baseUrl: string;
  
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  ngOnInit() {
    console.log("Utworzono QuizListComponent class: " + this.class);

    var url = this.baseUrl + "api/quiz/"

    switch (this.class) {
      case "latest":
      default:
        this.title = "Najnowsze quizy";
        url += "Latest/";
        break;
      case "byTitle":
        this.title = "Quizy alfabetycznie";
        url += "ByTitle/";
        break;
      case "random":
        this.title = "Quizy losowo";
        url += "Random/";
        break;
    }

    this.http.get<Quiz[]>(url).subscribe(result => {
      this.quizzes = result;
    }, error => console.error(error));
  }

  onSelect(quiz: Quiz) {
    this.selectedQuiz = quiz;
    console.log("Wybrany quiz " + this.selectedQuiz.Id);
  }
}
