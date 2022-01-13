# Ebola's PostgreSql Database Provider

This project contains Ebola's PostgreSql database provider.

## Migrations

Add a migration with:

dotnet ef migrations add MigrationName --context PostgreSqlContext --output-dir Migrations --startup-project ..\EbolaAPI\EbolaAPI.csproj

dotnet ef database update --context PostgreSqlContext