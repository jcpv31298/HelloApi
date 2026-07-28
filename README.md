# HelloApi

![CI](https://github.com/jcpv31298/HELLOAPI/actions/workflows/ci.yml/badge.svg)

API básica en .NET 8 con Controllers + Unit Tests + Integration Tests.

## Características

- ✅ ASP.NET Core 8 con Controllers tradicionales
- ✅ Inyección de dependencias
- ✅ Unit Tests con xUnit
- ✅ Integration Tests con WebApplicationFactory
- ✅ CI/CD con GitHub Actions

## Endpoints

### GET `/api/hello`
Retorna un mensaje de bienvenida.

**Response:**
```json
{
  "message": "Hola desde .NET 8 API"
}