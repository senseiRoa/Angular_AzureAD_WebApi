<h1 align="center">Bienvenido al proyecto Angular + AzureAD + WebApi 👋</h1>
<p>
  <img alt="Version" src="https://img.shields.io/badge/version-1.0.0-blue.svg?cacheSeconds=2592000" />
</p>

> El siguiente proyecto permite conectar una aplicacion Angular con el Active Directory de AzureAD mediante una pagina de login, obteniendo un JWT que posteriormente servira para acceder a los recursos protegidos por Active Directory en un WebApi Asp.Net Core

En este ejemplo encontrará:

* Una aplicación Angular creada desde cero con Angular Cli, con la dependencia a MSAL (Biblioteca para la autenticación con AzureAD)
* Una aplicación WebApi Asp.Net Core  creada desde cero con dotnetCore con dependencia a Microsoft.AspNetCore.Authentication.AzureAD.UI

Importante

Para que los proyectos funcionen debe realizar la configuracion de Azure Active Directory , registrando dos aplicaciones.
luego hay que realizar el ajuste de los aplicationIds de cada proyecto.

Puede encontrar una buena guia en este Ejemplo [Adding Azure Active Directory Authentication to connect an Angular app to Asp.Net Core Web API using MSAL](https://mobilefirstcloudfirst.net/2019/08/adding-azure-active-directory-authentication-connect-angular-app-asp-net-core-web-api-using-msal/)


## Author

👤 **Fabio Andres Roa**

* Github: [@senseiRoa](https://github.com/senseiRoa)

## Show your support

Give a ⭐️ if this project helped you!

***
_This README was generated with ❤️ by [readme-md-generator](https://github.com/kefranabg/readme-md-generator)_