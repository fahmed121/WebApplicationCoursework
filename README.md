FastFood API

Overview

FastFood API is a RESTful web service built using ASP.NET Core that provides endpoints for managing customers, staff, orders, and menu items in a fast-food restaurant. The API includes authentication, authorization, business logic layers, and database integration.

Features

Authentication & Authorization using JWT and Identity Framework

CRUD Operations for Customers, Staff, Orders, and Menu Items

DTO Implementation to manage data flow

Business Logic Layer (BLL) for clean architecture

Swagger API Documentation

Technologies Used

ASP.NET Core 8

Entity Framework Core (EF Core)

SQLite

Identity Framework & JWT Authentication

Swagger for API Documentation


Installation & Setup

Prerequisites

.NET SDK 8+

SQL Server

Visual Studio / VS Code

Docker (optional, for containerization)

Steps

Update database connection string and JWT secret key in appsettings.json

Run Database Migrations

dotnet ef database update

Run the API

dotnet run

The API will be available at http://localhost:5284.

API Endpoints

Authentication & Authorization

Method

Endpoint

Description

POST

/api/accounts/register

Register a new user

POST

/api/accounts/login

User login (returns JWT)

POST

/api/accounts/logout

Logout user

Customers

Method

Endpoint

Description

GET

/api/customers

Get all customers

GET

/api/customers/{id}

Get customer by ID

POST

/api/customers

Create new customer

PUT

/api/customers

Update customer

DELETE

/api/customers/{id}

Delete customer

Orders

Method

Endpoint

Description

GET

/api/orders

Get all orders

GET

/api/orders/{id}

Get order by ID

POST

/api/orders

Create new order

PUT

/api/orders

Update order

DELETE

/api/orders/{id}

Delete order

Running with Docker

Build and run the container

docker-compose up --build

The API will be accessible at http://localhost:5284

Testing

Run unit tests using:

dotnet test

API Documentation

The API provides Swagger documentation.
After running the API, open:

http://localhost:5284/swagger

Contribution Guidelines

Fork the repo and create a new branch.

Implement changes and write unit tests.

Commit your changes and open a pull request.

License

MIT License
