# EbolaAPI's SQLite Database Provider

This project contains EbolaAPI's SQLite database provider.

## Migrations

Add a migration with:

```
dotnet ef migrations add MigrationName --context SqliteContext --output-dir Migrations --startup-project EbolaAPI --project EbolaApi.SqLite

dotnet ef database update --context SqliteContext
```
