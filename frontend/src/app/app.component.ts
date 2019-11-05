import { Component, OnInit } from '@angular/core';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor(private apollo: Apollo) {
  }
  post$: Observable<any>;

  ngOnInit() {
    this.post$ = this.apollo.watchQuery({
    query: gql`{
      posts{
        id,
        title,
        context,
        author{
          id,
          name
        }
      }
    }`}).valueChanges;
  }
}
