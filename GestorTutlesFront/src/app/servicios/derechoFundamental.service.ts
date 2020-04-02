import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';
import { GenericService } from './generic.service';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class DerechoFundamentalService extends GenericService {


  constructor(private http: HttpClient) {
    super(http);
    //this.apiURL = environment.apiUrl + 'Municipio/';
    this.apiURL = '/assets/fakeData/derechofundamental.json';
  }

}
