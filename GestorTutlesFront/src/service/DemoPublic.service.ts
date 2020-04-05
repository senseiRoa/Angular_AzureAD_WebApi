import { Injectable } from '@angular/core';
import { HttpClient, HttpBackend } from '@angular/common/http';
import { RootObject } from './RootObject';
import { Observable } from 'rxjs';
import { RegistroExpediente } from 'src/app/modelos/registro-expediente';

@Injectable({
  providedIn: 'root'
})
export class DemoPublicService {
  private resourceUrl = 'https://localhost:5001/Public/';


  constructor(private http: HttpClient) {

    // this.http = new HttpClient(handler);
  }


  getPublic(): Observable<RootObject[]> {
    return this.http.get<RootObject[]>(`https://localhost:5001/Public/`);
  }
  uploadFormDataAsync(uploadFile: File, entity: RegistroExpediente) {
    const formData = new FormData();
    formData.append('Nombre', entity.nombres);
    formData.append('capchaResponse', entity.capchaResponse);
    formData.append('File_', uploadFile, uploadFile.name);

    return this.http
      .post<any>(`${this.resourceUrl}`, formData, {
        reportProgress: true
      })
      .toPromise();

  }
}




