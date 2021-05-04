build
`docker build -t nouran:latest .`
run
`docker run --rm -d -it -p 80:80 nouran:latest --name nouran-api`

pull sql server 2019
`docker pull mcr.microsoft.com/mssql/server:2019-latest`

run sql server
`docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=P@ssw0rd" -p 1433:1433 --name sql -h sql -d mcr.microsoft.com/mssql/server:2019-latest`
`docker exec -it sql bash`
`/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "P@ssw0rd"`
`CREATE DATABASE NouranDB`
`SELECT Name from sys.Databases`

add dotnet ef tool
`dotnet tool install --global dotnet-ef`
`dotnet ef migrations add Initial  -o Infrastructure/Persistence/Migrations`
`dotnet ef database update --connection "Server=localhost;Database=NouranDB;User Id=SA;Password=P@ssw0rd;"`
`dotnet ef database drop`

run docker compose
`docker-compose build`
`docker-compose up -d`
`docker-compose down`