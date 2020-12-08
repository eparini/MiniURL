import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  constructor(private route: Router, private http: HttpClient) { }

  ngOnInit() {
    let completeUrl: string = window.location.href;
    let shortUrl: string = completeUrl.replace(window.location.origin + "/", "");
    if (shortUrl) {
      return this.http.post<string>(environment.url + 'getlongurl', { url: shortUrl }).toPromise()
        .then((res: any) => {
          if (res) {
            document.location.href = res.longURL;
          }
        });
    }
  }
}
