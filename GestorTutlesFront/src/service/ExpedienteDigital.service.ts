import { environment } from '../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpBackend } from '@angular/common/http';
import { RootObject } from './RootObject';
import { Observable } from 'rxjs';
import { RegistroExpediente } from 'src/app/modelos/registro-expediente';

@Injectable({
  providedIn: 'root'
})
export class ExpedienteDigitalService {
  private resourceUrl = environment.publicApiUrl + "ExpedienteDigitalPublic/";


  constructor(private http: HttpClient) {

    // this.http = new HttpClient(handler);
  }



  uploadFormDataAsync(uploadFile: File, entity: RegistroExpediente) {
    const formData = new FormData();
    formData.append('Data', JSON.stringify(entity.Data));
    formData.append('capchaResponse', entity.capchaResponse);
    formData.append('File_', uploadFile, uploadFile.name);

    return this.http
      .post<any>(`${this.resourceUrl}`, formData, {
        reportProgress: true
      })
      .toPromise();

  }
}



