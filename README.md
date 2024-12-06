# Dial CMS

**Dial CMS** is a headless CMS built with **C#** and based on **DDD** (Domain-Driven Design) principles. The goal is to provide a flexible and extensible content management solution for modern applications.

## Features

- **Headless Architecture**: Decouple content management from presentation.
- **Domain-Driven Design**: Emphasizes clear business logic with rich domain models.
- **Value Objects**: Ensures data consistency and extensibility.
- **Clean Architecture**: Layered architecture with separation of concerns.
- **Error Handling**: Follows [RFC 7807](https://tools.ietf.org/html/rfc7807) for standardized error responses.
- **Flexible Data Modeling**: Use `FieldDto` extensions for seamless conversion to domain models.
- **Functional Programming Support**: Incorporates the `ErrorOr` package for predictable error handling.

## Architecture

The project follows a clean architecture approach with clearly defined layers:

1. **Domain**: Business logic and domain models.
2. **Application**: Commands, queries, and use cases.
3. **Infrastructure**: Database access and third-party integrations.
4. **API**: Exposes REST endpoints using ASP.NET Core.
