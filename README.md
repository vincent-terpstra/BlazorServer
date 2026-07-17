# BlazorServerDemo Solution

## Overview

This solution is a .NET 7 application built around a Blazor Server web application, with separate projects for domain logic, application orchestration, data access, and automated testing.

The solution uses a layered structure to keep the UI, business concepts, application behavior, and persistence concerns separated.

---

## Technologies Used
| Type | Technologies |
| --- | --- |
| Frameworks and Runtime | .NET 7, ASP.NET Core, Blazor Server, Razor |
| Language | C# |
| Application Architecture | MediatR |
| Data Access | Entity Framework Core, Entity Framework Core InMemory, Dapper, Dapper.Extensions.PostgreSQL |
| UI and Components | SmartComponents.AspNetCore |
| Testing | xUnit, Moq, bUnit, SpecFlow, Microsoft.NET.Test.Sdk |
| Tooling and Deployment | Docker, npm |

---

## Projects

### `BlazorServerDemo`

**Project type:** ASP.NET Core web application  
**Target framework:** `net7.0`

This is the main web application project. It hosts the Blazor Server application and acts as the entry point for the solution.

**Purpose:**

- Hosts the Blazor Server UI
- Configures the ASP.NET Core application
- Serves Razor components and web assets
- Wires together application services and infrastructure
- Provides the main runtime experience for users

**Notable technologies/packages:**

- ASP.NET Core
- Blazor Server
- Razor
- Entity Framework Core InMemory
- SmartComponents.AspNetCore
- Docker Linux target configuration

---

### `Domain`

**Project type:** .NET class library  
**Target framework:** `net7.0`

The `Domain` project contains the core business concepts of the solution.

**Purpose:**

- Defines domain models and business entities
- Contains core business rules and domain-level abstractions
- Provides a framework-independent layer for the rest of the application
- Avoids dependencies on UI, persistence, or infrastructure concerns

**Notable technologies/packages:**

- .NET 7
- C#
- Nullable reference types
- Implicit usings

---

### `Application`

**Project type:** .NET class library  
**Target framework:** `net7.0`

The `Application` project contains application-level behavior and use cases. It references the `Domain` project.

**Purpose:**

- Coordinates application workflows
- Defines application services, requests, handlers, or commands
- Acts as a bridge between the domain model and outer layers
- Uses MediatR to support request/response and messaging patterns

**Project references:**

- `Domain`

**Notable technologies/packages:**

- MediatR
- MediatR.Contracts
- .NET 7
- C#

---

### `DataAccess`

**Project type:** .NET class library  
**Target framework:** `net7.0`

The `DataAccess` project contains persistence-related functionality.

**Purpose:**

- Provides data access implementation details
- Encapsulates database-related operations
- Supports persistence using Entity Framework Core and Dapper
- Keeps database concerns separate from the domain and application layers

**Notable technologies/packages:**

- Entity Framework Core 7
- Dapper
- Dapper.Extensions.PostgreSQL
- .NET 7
- C#

---

### `DataAccess.Tests`

**Project type:** .NET test project  
**Target framework:** `net7.0`

The `DataAccess.Tests` project contains automated tests for the data access layer.

**Purpose:**

- Verifies data access behavior
- Tests persistence-related services and repositories
- Uses mocking where appropriate to isolate dependencies

**Notable technologies/packages:**

- xUnit
- Moq
- Microsoft.NET.Test.Sdk
- .NET 7

---

### `BlazorServerDemobUnit`

**Project type:** Razor test project  
**Target framework:** `net7.0`

The `BlazorServerDemobUnit` project contains bUnit-based tests for Blazor components.

**Purpose:**

- Tests Blazor/Razor components
- Verifies component rendering behavior
- Tests UI interactions in isolation
- Provides test doubles for Blazor-specific services where needed

**Notable technologies/packages:**

- bUnit
- bUnit test doubles
- xUnit
- Razor SDK
- Microsoft.Extensions.DependencyInjection

---

### `BlazorServerDemo.SpecFlow`

**Project type:** Razor test project  
**Target framework:** `net7.0`

The `BlazorServerDemo.SpecFlow` project contains SpecFlow-based tests, likely focused on behavior-driven testing scenarios.

**Purpose:**

- Defines behavior-driven test scenarios
- Supports readable acceptance-style tests
- Can combine SpecFlow scenarios with bUnit-based component testing
- Helps validate application behavior from a user or feature perspective

**Notable technologies/packages:**

- SpecFlow
- bUnit
- Microsoft.NET.Test.Sdk
- Razor SDK
- .NET 7

---

## Solution Architecture

The solution follows a layered structure:
```text
BlazorServerDemo
└── Web/UI layer
Application
└── Application workflows and request handling
Domain
└── Core business concepts and rules
DataAccess
└── Persistence and database access
DataAccess.Tests
└── Tests for data access behavior
BlazorServerDemobUnit
└── Blazor component tests
BlazorServerDemo.SpecFlow
└── Behavior-driven tests
```

Known project dependency:
```text
Application -> Domain
```


The intended layering keeps domain logic independent from UI and infrastructure concerns.

---

## Testing Strategy

The solution contains multiple test projects, each focused on a different testing concern.

### Data access tests

`DataAccess.Tests` verifies persistence-related behavior using:

- xUnit
- Moq
- Microsoft.NET.Test.Sdk

### Blazor component tests

`BlazorServerDemobUnit` verifies Razor component behavior using:

- bUnit
- xUnit
- Blazor test doubles

### Behavior-driven tests

`BlazorServerDemo.SpecFlow` supports BDD-style scenarios using:

- SpecFlow
- bUnit
- Microsoft.NET.Test.Sdk

---

## Getting Started

### Prerequisites

Install the following:

- .NET SDK 7.0
- An IDE such as JetBrains Rider or Visual Studio
- Node.js and npm, if frontend package management is used by the application

---

## Restore Dependencies

Restore .NET dependencies:
```bash
dotnet restore
```

---

## Build the Solution
```bash
dotnet build
```

---

## Run the Application
```bash
  dotnet run --project BlazorServerDemo
```


---

## Run Tests

Run all tests:
```bash
dotnet test
```

Run a specific test project:
```bash
dotnet test DataAccess.Tests
```

```bash
dotnet test BlazorServerDemobUnit
```

```bash
dotnet test BlazorServerDemo.SpecFlow
```


---

## Project Summary

| Project | Purpose | Key Technologies |
| --- | --- | --- |
| `BlazorServerDemo` | Main Blazor Server web application | ASP.NET Core, Blazor Server, Razor, EF Core InMemory, SmartComponents |
| `Domain` | Core business concepts and domain models | .NET 7, C# |
| `Application` | Application workflows and MediatR-based behavior | MediatR, .NET 7, C# |
| `DataAccess` | Persistence and database access | EF Core, Dapper, PostgreSQL extensions |
| `DataAccess.Tests` | Data access tests | xUnit, Moq |
| `BlazorServerDemobUnit` | Blazor component tests | bUnit, xUnit, Razor |
| `BlazorServerDemo.SpecFlow` | BDD-style tests | SpecFlow, bUnit |

---

## Notes for Contributors

- Keep domain logic in the `Domain` project.
- Keep application workflows in the `Application` project.
- Keep persistence implementation details in `DataAccess`.
- Keep UI concerns in `BlazorServerDemo`.
- Add data access tests to `DataAccess.Tests`.
- Add Blazor component tests to `BlazorServerDemobUnit`.
- Add behavior-driven scenarios to `BlazorServerDemo.SpecFlow`.

Avoid committing generated files, local environment files, build outputs, or sensitive configuration values.

