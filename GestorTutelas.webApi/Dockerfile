# dotnet publish GestorTutelas.webApi.csproj -c Release -r linux-x64 -p:PublishSingleFile=True --self-contained True
#https://softchris.github.io/pages/dotnet-dockerize.html#resources
#https://medium.com/swlh/containerize-asp-net-core-3-1-with-docker-c5e1acabba21


FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app


COPY *.csproj ./
RUN dotnet restore


COPY . ./
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "GestorTutelas.webApi.dll"]