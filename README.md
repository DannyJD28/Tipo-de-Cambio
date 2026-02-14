# CleanApi (.NET 8 + Clean Architecture)

## Estructura
- `src/Api`
- `src/Application`
- `src/Domain`
- `src/Infrastructure`
- `tests/UnitTests`
- `tests/IntegrationTests`

## Ejecutar local
```bash
dotnet restore
dotnet build
dotnet run --project src/Api
```

## Migraciones EF Core
```bash
dotnet ef database update --project src/Infrastructure --startup-project src/Api
dotnet ef migrations add NombreMigracion --project src/Infrastructure --startup-project src/Api
```

## Docker
```bash
docker compose up --build
```

## Endpoints principales
- `GET /api/v1/products`
- `GET /api/v1/products/{id}`
- `POST /api/v1/products`
- `PUT /api/v1/products/{id}`
- `DELETE /api/v1/products/{id}`
- `GET /api/v1/exchange-rate/usd-pen`
- `GET /health`
