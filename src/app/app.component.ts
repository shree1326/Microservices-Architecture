import { Component } from '@angular/core';
import { AuthService } from './auth/auth.service';
import * as firebase from 'firebase';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(public authService: AuthService){}
  ngOnInit() {
    firebase.initializeApp({
      apiKey: "YOUR-FIREBASE-API-KEY",
      authDomain: "YOUR-FIREBASE-DOMAIN-NAME"
    });
  }
  onLogout() {
    this.authService.logout();
  }

  isAuthenticated() {
    return this.authService.isAuthenticated();
  }

  title = 'ProductWebAPP';
}