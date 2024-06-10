import { Component } from '@angular/core';
import { ProductlistComponent } from '../product/productlist/productlist.component';
import { Developer } from '../../models/developer.model';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})

export class HomepageComponent {
  developersList: Developer[] = [
    {
      name: "Bart Nobels",
      imgUrl: "https://i.imgur.com/JUSa2EC.jpeg",
      linkedInUrl: "https://www.linkedin.com/in/b-nobels/",
      githubUrl: "https://github.com/Bart-Nobels",
      personalSiteUrl: "https://bart-nobels.github.io/"
    },
    {
      name: "Illya Verheyden",
      imgUrl: "https://i.imgur.com/9xT7t5b.png",
      linkedInUrl: "https://www.linkedin.com/in/illyav/",
      githubUrl: "https://github.com/illyav-d",
      personalSiteUrl: "https://illyav-d.github.io"
    },
    {
      name: "Gilles Fabry",
      imgUrl: "https://justgilloo.github.io/images/cv-foto.jpg",
      linkedInUrl: "https://www.linkedin.com/in/gilles-fabry/",
      githubUrl: "https://github.com/JustGilloo",
      personalSiteUrl: "https://justgilloo.github.io/"
    }
  ];
}
