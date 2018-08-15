FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ContosoUniversity.API/ContosoUniversity.API.csproj ContosoUniversity.API/
RUN dotnet restore ContosoUniversity.API/ContosoUniversity.API.csproj
COPY . .
WORKDIR /src/ContosoUniversity.API
RUN dotnet build ContosoUniversity.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ContosoUniversity.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ContosoUniversity.API.dll"]
