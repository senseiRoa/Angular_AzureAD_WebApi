import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-manager-file',
  templateUrl: './manager-file.component.html',
  styleUrls: ['./manager-file.component.scss']
})
export class ManagerFileComponent implements OnInit {
  uploadFile: File;
  statusFile: StatusFile;
  statusType = StatusFile;
  @Input() fileBase: any//;IDocumentoTE;
  @Input() idTramite: number;
  constructor(private messageService: MessageService,
    // private documentoService: DocumentoService
  ) { }

  ngOnInit() {
  }


  myUploader(event) {
    // event.files == files to upload
    try {
      // this.isbussy = true;

      const files = event.files;
      if (files[0].size > 2000000 || files[0].type != 'application/pdf') {
        return;
      }
      this.uploadFile = files[0];

    } catch (error) {
      console.log(error.message);
    } finally {
      // this.isbussy = false;
    }
  }
  async uploadFileEvent() {

    try {

      if (this.uploadFile != null) {
        const updateId = this.fileBase.idArchivo == null ? 'null' : this.fileBase.idArchivo + '';
        //const result = await this.documentoService.upload(this.uploadFile, this.idTramite, updateId);
        ///debugger;
        this.messageService.add({ severity: 'info', summary: 'File Uploaded', detail: '' });
        this.statusFile = StatusFile.loaded;
        //this.fileBase.fechaCarga = this.documentoService.getDateFormat(new Date(), true, true);
        this.fileBase.estadoCarga = true;
        this.uploadFile = null;
        this.messageService.add({ severity: 'info', summary: 'File Uploaded', detail: '' });
        this.uploadFile = null;
      }

    } catch (error) {
      console.log(error.message);
    } finally {
      // this.isbussy = false;
    }
  }

  onClear(event) {
    if (this.statusFile === StatusFile.modifying) {
      this.statusFile = StatusFile.loaded;
    }
    this.uploadFile = null;
    console.log(event);
  }

  editFile() {
    this.statusFile = StatusFile.modifying;
    this.uploadFile = null;
  }
  viewFile() {

  }
}
export enum StatusFile {
  loaded = 1,
  unloaded,
  modifying
}
