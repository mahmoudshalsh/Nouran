# to publish
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish "Api/Nouran.Api.csproj" -c release -o /app/publish
#RUN dotnet tool install --global dotnet-ef
#RUN dotnet ef database update --connection "Server=localhost;Database=NouranDB;User Id=SA;Password=P@ssw0rd;"

# to run
FROM mcr.microsoft.com/dotnet/aspnet:5.0 As host
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
#RUN dotnet tool install --global dotnet-ef
#RUN dotnet ef database update --connection "Server=localhost;Database=NouranDB;User Id=SA;Password=P@ssw0rd;"
ENTRYPOINT ["dotnet", "/app/Nouran.Api.dll"]
