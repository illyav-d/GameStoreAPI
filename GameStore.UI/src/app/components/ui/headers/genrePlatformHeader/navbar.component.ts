import { Component } from '@angular/core';
import { Genre } from '../../../../models/genre.model';
import { GenreService } from '../../../../service/genre.service';
import { Platform } from '../../../../models/platform.model';
import { PlatformService } from '../../../../service/platform.service';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  genreList: Genre[] = []
  platformList: Platform[] = []
  query: string = '';

  constructor(private genreService: GenreService, private platformService: PlatformService, private router: Router) {
    this.loadGenresInArray();
    this.loadPlatformsInArray();
  }
  loadPlatformsInArray() {
    this.platformService.retrieveAllPlatforms().subscribe((response: Array<Platform>) => {
      console.log(response);
      this.platformList = response;
    })
  }

  loadGenresInArray() {
    this.genreService.retrieveAllGenres().subscribe((response: Array<Genre>) => {
      console.log(response);
      this.genreList = response;
    })
  }

  onSubmit() {
    if (this.query) {
      this.router.navigate(['products/search/userinput'], { queryParams: { query: this.query } });
    }
  }





}
