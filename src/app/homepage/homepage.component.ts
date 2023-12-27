import { Component } from '@angular/core';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent {
isAuthenticated(): any {
throw new Error('Method not implemented.');
}

  title: string ="Microservices Demo";

}