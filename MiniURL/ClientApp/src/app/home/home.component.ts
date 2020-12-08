import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  shortURL: string = "";
  longURL: string = "";
  currentURL: string = window.location.toString();
  constructor(private http: HttpClient) { }

  onClickMe() {
    return this.http.post<string>(environment.url + 'generateshorturl', { url: this.longURL }).toPromise()
      .then((res: any) => {
        this.shortURL = res.shortURL;
      });
  }



}
