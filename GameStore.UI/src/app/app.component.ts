import { Component } from '@angular/core';
import { HeaderVisibilityService } from './service/headerdisplay.service';
import { Observable, map } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'GameStore.UI';
  headerVisible!: Observable<boolean>;
  constructor(private headerVisibilityService: HeaderVisibilityService) { }

  ngOnInit() {
    this.headerVisible = new Observable((observer) => {
      observer.next(this.headerVisibilityService.isHeaderVisible());
      setInterval(() => observer.next(this.headerVisibilityService.isHeaderVisible()), 100);
    }).pipe(map(val => val as boolean));
  }
}

