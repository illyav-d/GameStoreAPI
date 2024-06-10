import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HeaderVisibilityService {
  private headerVisible: boolean = false;

  showHeader() {
    this.headerVisible = true;
  }

  hideHeader() {
    this.headerVisible = false;
  }

  isHeaderVisible(): boolean {
    return this.headerVisible;
  }
}
