// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  redirectUrl: 'http://localhost:4200/Recursos',
  clientId: 'fd151c8f-ed96-4326-83d4-e1a695b65c7b',
  clientIdAPI: 'api://f7d3f188-c7a0-4f57-b9f8-58236581691d/api-access',
  authority: 'https://login.microsoftonline.com/c726ab66-2de1-49a1-8989-c31b7faf90a3',

  aadUserReadScope: 'user.read',
  apiBaseUrl: 'https://localhost:5001/WeatherForecast',
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
