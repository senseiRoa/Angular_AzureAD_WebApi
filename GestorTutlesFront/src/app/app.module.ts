
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

function MSALAngularConfigFactory(): MsalAngularConfiguration {
  return {
    consentScopes: [environment.aadUserReadScope, environment.clientIdAPI],
    protectedResourceMap: [[environment.apiBaseUrl, [environment.clientIdAPI]]]
  }
}


// export const protectedResourceMap: [string, string[]][] = [
//   ['https://localhost:5001/WeatherForecast', ['api://f7d3f188-c7a0-4f57-b9f8-58236581691d/api-access']]]
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent
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
    AppRoutingModule
  ],

  providers: [
    DemoService,
    {
      provide: MSAL_CONFIG_ANGULAR,
      useFactory: MSALAngularConfigFactory
    },
    { provide: HTTP_INTERCEPTORS, useClass: MsalInterceptor, multi: true },
    MsalService
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
