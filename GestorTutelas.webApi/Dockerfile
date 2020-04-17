# dotnet publish GestorTutelas.webApi.csproj -c Release -r linux-x64 -p:PublishSingleFile=True --self-contained True
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "GestorTutelas.webApi.dll"]