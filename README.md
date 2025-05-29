Dynatron Customer Service API
Overview
Dynatron Customer Service is a RESTful API built with .NET 7 and Entity Framework Core that provides CRUD operations for managing customer data.
It follows clean architecture principles with a layered design separating Domain, Application, and Infrastructure concerns. This backend powers a frontend Angular 15+ Customer app.

Features
* Full CRUD operations for Customer entities:

* Create, Read (single/all), Update, Delete

* Database: PostgreSQL with EF Core migrations

* Repository and Service patterns with Dependency Injection

* Async/await for scalable asynchronous operations

* Entity configuration using EF Core Fluent API

* Automatic database seeding with 20 initial customers

* CORS enabled for Angular frontend (http://localhost:4200)

* Swagger UI for easy API exploration and testing

* Global error handling middleware for consistent error responses

* HTTPS enforcement

Getting Started
Prerequisites
.NET 7 SDK

PostgreSQL


Setup
Clone the repository

git clone https://github.com/your-username/dynatron-customer-service.git
cd dynatron-customer-service
Configure the database connection;

Update the appsettings.json file with your PostgreSQL connection string:

"ConnectionStrings": {
  "Connection": "Host=localhost;Database=dynatron_customer_db;Username=yourusername;Password=yourpassword"
}
Run database migrations and seed data

The application automatically runs migrations and seeds 20 customer records on startup (in Development environment).

Run the application

dotnet run
Access API

Swagger UI: https://localhost:{port}/swagger

API base URL: https://localhost:{port}/api/customers

API Endpoints
Method	Endpoint	Description
GET	/api/customers	Get all customers
GET	/api/customers/{id}	Get a customer by ID
POST	/api/customers	Create a new customer
PUT	/api/customers/{id}	Update an existing customer
DELETE	/api/customers/{id}	Delete a customer

Architecture & Design Decisions
* Clean Architecture: Separation of concerns into Domain, Application, and Infrastructure projects/folders.

* Repository Pattern: Abstracts data access, improving testability and flexibility.

* DTOs: Prevent exposing internal domain entities directly; support API contract stability.

* Async Methods: All I/O operations are asynchronous for scalability.

* Middleware: Centralized error handling to return consistent HTTP error responses.

* CORS Policy: Restricts API access to the Angular frontend origin.

* Database Seeding: Ensures the application has initial sample data for immediate use.

* Entity Configuration: Fluent API used for maintainability and explicit schema definition.

Error Handling
*Global exception middleware captures unhandled exceptions.

*Returns structured error responses with HTTP status codes.

*Ensures sensitive internal details are not exposed.

Future Improvements (Not implemented)
* Add FluentValidation for robust request validation.

* Implement unit and integration tests.

* Add authentication and authorization.

* Use AutoMapper for DTO mapping.

* Add paging, sorting, and filtering support.

