# to publish
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish "Api/Nouran.Api.csproj" -c release -o /app/publish

# to run
FROM mcr.microsoft.com/dotnet/aspnet:5.0 As host
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "/app/Nouran.Api.dll"]
