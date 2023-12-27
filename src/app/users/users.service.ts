import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../Model/User';
import configurl from '../../assets/config/config.json'
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  url = configurl.apiServer.url + '/users?PageNumber=1&PageSize=5&order=UserId_ASC';
  constructor(private http: HttpClient) { }
  getUserList(PageNumber : number, PageSize : number, order: string): Observable<User[]> {
    return this.http.get<User[]>(this.url)
  }
  postUserData(userData: User): Observable<User> {
    const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
    return this.http.post<User>(this.url, userData, httpHeaders);
  }
  updateUser(user: User): Observable<User> {
    const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
    return this.http.put<User>(this.url, user, httpHeaders);
  }
  deleteUserById(id: number): Observable<number> {
    return this.http.delete<number>(this.url + '/' + id);
  }
  getUserDetailsById(id: string): Observable<User> {
    return this.http.get<User>(this.url + '/' + id);
  }
}