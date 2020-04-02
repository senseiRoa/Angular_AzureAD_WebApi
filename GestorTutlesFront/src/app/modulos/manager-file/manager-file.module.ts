import { ManagerFileComponent } from './manager-file/manager-file.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadModule } from 'primeng/fileupload';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';


@NgModule({
  imports: [
    CommonModule,
    FileUploadModule,
    ToastModule,
    MessagesModule,
    MessageModule,
  ],
  exports: [ManagerFileComponent],
  declarations: [ManagerFileComponent],
  providers: [
    MessageService
  ]
})
export class ManagerFileModule { }
