import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';
import { GenericService } from './generic.service';
import { HttpClient, HttpBackend } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class DepartamentoService extends GenericService {


  constructor(private http: HttpClient, handler: HttpBackend) {
    super(http);
    // this.apiURL = environment.apiUrl + 'Departamento';
    this.apiURL = 'assets/fakeData/departamentos.json';
    this.httpClient = new HttpClient(handler);
  }

}
