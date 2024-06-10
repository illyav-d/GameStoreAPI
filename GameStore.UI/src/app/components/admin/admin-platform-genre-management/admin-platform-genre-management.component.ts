import { Component } from '@angular/core';
import { Genre } from '../../../models/genre.model';
import { Platform } from '../../../models/platform.model';
import { GenreService } from '../../../service/genre.service';
import { PlatformService } from '../../../service/platform.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin-platform-genre-management',
  templateUrl: './admin-platform-genre-management.component.html',
  styleUrl: './admin-platform-genre-management.component.css'
})
export class AdminPlatformGenreManagementComponent {
  genreList: Genre[] = []
  platformList: Platform[] = []
  formGenre: FormGroup;
  formPlatform: FormGroup;





  constructor(private genreService: GenreService, private platformService: PlatformService, private formBuilder: FormBuilder) {
    this.loadGenresInArray();
    this.loadPlatformsInArray();
    this.formGenre = this.formBuilder.group({
      name: ['']
    });
    this.formPlatform = this.formBuilder.group({
      name: ['']
    });
  }


  loadPlatformsInArray() {
    this.platformService.retrieveAllPlatforms().subscribe((response: Array<Platform>) => {
      console.log(response);
      this.platformList = response;
    });
  }

  loadGenresInArray() {
    this.genreService.retrieveAllGenres().subscribe((response: Array<Genre>) => {
      console.log(response);
      this.genreList = response;
    });
  }

  onRemoveGenre(genreID: number): void {
    this.genreService.removeGenreById(genreID).subscribe(() => {
      this.loadGenresInArray();
    });
  }
  onRemovePlatform(platformID: number): void {
    this.platformService.removePlatformById(platformID).subscribe(() => {
      this.loadPlatformsInArray();
    });
  }
  onSubmitGenre() {
    if (this.formGenre.valid) {
      const body = this.formGenre.value;
      this.genreService.addNewGameGenre(body)
        .subscribe(response => {
          console.log('API response', response);
          this.loadGenresInArray();
        });
    }
  }

  onSubmitPlatform() {
    if (this.formPlatform.valid) {
      const body = this.formPlatform.value;
      this.platformService.addNewGamePlatform(body)
        .subscribe(response => {
          console.log('API response', response);
          this.loadPlatformsInArray();
        });
    }
  }

}
