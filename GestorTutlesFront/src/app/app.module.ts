import { DepartamentoService } from './servicios/departamento.service';
import { AppMenuComponent } from './component/app.menu/app.menu.component';
import { AppTopBarComponent } from './component/app.top-bar/app.top-bar.component';
import { AppFooterComponent } from './component/app.footer/app.footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MsalModule, MsalInterceptor, MsalService, MSAL_CONFIG, MSAL_CONFIG_ANGULAR, MsalAngularConfiguration } from '@azure/msal-angular';

import { HomeComponent } from './component/Home/Home.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { DemoService } from 'src/service/Demo.service';
import { LoginComponent } from './component/Login/Login.component';
import { environment } from 'src/environments/environment';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormularioPublicoComponent } from './component/formulario-publico/formulario-publico.component';
import { WizardModule } from './modulos/wizard-module/wizard.module';
import { ManagerFileModule } from './modulos/manager-file/manager-file.module';

// primeNg


import { PanelModule } from 'primeng/panel';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { StepsModule } from 'primeng/steps';
import { ButtonModule } from 'primeng/components/button/button';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { CaptchaModule } from 'primeng/captcha';
import { FileUploadModule } from 'primeng/fileupload';
import { DemoPublicService } from 'src/service/DemoPublic.service';



function MSALAngularConfigFactory(): MsalAngularConfiguration {
  return {
    consentScopes: [environment.aadUserReadScope, environment.clientIdAPI],
    protectedResourceMap: [[environment.apiBaseUrl, [environment.clientIdAPI]]]
  }
}



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    AppFooterComponent,
    AppTopBarComponent,
    AppMenuComponent,
    FormularioPublicoComponent,


  ],
  imports: [
    MsalModule.forRoot({
      auth: {
        clientId: environment.clientId,
        redirectUri: environment.redirectUrl,
        authority: environment.authority,

      }
    }),
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    PanelModule,
    ScrollPanelModule,
    MessagesModule,
    MessageModule,
    WizardModule,
    ManagerFileModule,
    ToastModule,
    StepsModule,
    ButtonModule,
    DropdownModule,
    InputTextareaModule,
    FileUploadModule,
    CaptchaModule

  ],

  providers: [
    DemoService,
    DemoPublicService,
    {
      provide: MSAL_CONFIG_ANGULAR,
      useFactory: MSALAngularConfigFactory
    },
    { provide: HTTP_INTERCEPTORS, useClass: MsalInterceptor, multi: true },
    MsalService,
    MessageService

  ],


  bootstrap: [AppComponent]
})
export class AppModule {
  /**
   *
   */
  constructor(msalService: MsalService) {
    msalService.handleRedirectCallback(_ => { });

  }
}
