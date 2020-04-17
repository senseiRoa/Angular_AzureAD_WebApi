# dotnet publish GestorTutelas.webApi.csproj -c Release -r linux-x64 -p:PublishSingleFile=True --self-contained True
FROM microsoft/aspnetcore-build:2.0 as build-anv
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore-build:2.0 
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "GestorTutelas.webApi.dll"]