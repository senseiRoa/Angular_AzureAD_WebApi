import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';
import { GenericService } from './generic.service';
import { HttpClient, HttpBackend } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class DerechoFundamentalService extends GenericService {


  constructor(private http: HttpClient, handler: HttpBackend) {
    super(http);
    //this.apiURL = environment.apiUrl + 'Municipio/';
    this.apiURL = 'assets/fakeData/derechoFundamental.json';
    this.httpClient = new HttpClient(handler);
  }

}
