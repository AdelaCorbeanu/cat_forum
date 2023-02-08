import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from 'oidc-client';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  apiUrl = 'https://localhost:44423/signup';

  constructor(private http: HttpClient) { }

  register(user: User) {
    return this.http.post<User>(this.apiUrl, user);
  }
}
