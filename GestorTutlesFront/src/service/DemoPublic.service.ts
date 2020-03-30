import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RootObject } from './RootObject';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DemoPublicService {

  constructor(private http: HttpClient) { }


  getPublic(): Observable<RootObject[]> {
    return this.http.get<RootObject[]>(`https://localhost:5001/Public/`);
  }
}




