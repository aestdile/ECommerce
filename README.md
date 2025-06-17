# E-Commerce API

This is a full-stack, clean architecture-based E-Commerce Web API built using ASP.NET Core, Entity Framework Core, and following domain-driven design (DDD) principles.

## Project Overview

The project allows managing products, orders, payments, users, and roles in an online store system. It follows a modular structure separating concerns into distinct layers:

* **Domain Layer**: Core business logic, entities, value objects, and domain events.
* **Application Layer**: Use cases, CQRS commands/queries, DTOs, validation, and business services.
* **Infrastructure Layer**: Database access (EF Core), external services (File storage, Email, Payment gateway).
* **WebAPI Layer**: RESTful API controllers, middleware, filters, and configurations.

---

## Technologies Used

* **.NET 8**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **Clean Architecture**
* **CQRS Pattern (MediatR)**
* **FluentValidation**
* **AutoMapper**
* **JWT Authentication**
* **XUnit (for Testing)**
* **Swagger (OpenAPI)**

---

## Solution Structure

### ECommerce.Domain

Contains core business models:

* **Common**: `BaseEntity`, `AuditableEntity`
* **Entities**: `Product`, `Category`, `Brand`, `ProductImage`, `ProductReview`, `Order`, `OrderItem`, `Payment`, `PaymentMethod`, `User`, `Role`, `UserRole`
* **Enums**: `OrderStatus`, `PaymentStatus`
* **ValueObjects**: `Address`
* **Events**: `OrderCreatedEvent`, `ProductStockChangedEvent`, `PaymentProcessedEvent`
---
### ECommerce.Application

Application logic, CQRS handlers, DTOs, services:

* **Abstractions**: Repository interfaces, service interfaces
* **Features**:

  * **Auth**: Registration, login
  * **Products**: CRUD operations for products
  * **Categories**: Manage categories
  * **Brands**: Manage brands
  * **Orders**: Create and manage orders
  * **Payments**: Process payments
  * **Users**: Manage user profiles and roles
* **Behaviors**: Validation, Logging, Performance behaviors for pipeline
* **Common**: `Result`, `PaginatedList`, `ApplicationException`
---
### ECommerce.Infrastructure

Data access, persistence implementations, integrations:

* **Data**: EF Core `ECommerceDbContext`, configurations, data seeding
* **Persistence**: Repository implementations, UnitOfWork
* **Services**:

  * File Storage: Local and Cloud (optional)
  * Email Service
  * Payment Gateway integration
* **Migrations**: Database schema migrations
---
### ECommerce.WebAPI

REST API interface:

* **Controllers**: Auth, Product, Category, Brand, Order, Payment, User
* **Middlewares**: Global exception handling
* **Filters**: Validation filter
* **Extensions**: Service registration, middleware configurations
* **Configurations**: `appsettings.json`, JWT, DB Connection, Mail, File storage

---

## Getting Started

### Prerequisites

* .NET 8 SDK
* SQL Server (or other supported DB)
* Visual Studio 2022+ or VS Code

### Setup Instructions

1. **Clone Repository**

```bash
[git clone <your-repo-url>](https://github.com/aestdile/ECommerce.git)
cd ECommerce
```

2. **Update appsettings.json**

* Setup your DB connection string
* Setup JWT secret, Mail configurations, FileStorage path, etc.

3. **Apply EF Core Migrations**

```bash
dotnet ef database update --project ECommerce.Infrastructure --startup-project ECommerce.WebAPI
```

4. **Run the Application**

```bash
dotnet run --project ECommerce.WebAPI
```

5. **API Documentation**

* Open Swagger UI at `https://localhost:{port}/swagger`

---

## Main Features

* ✅ User Registration & Login (JWT)
* ✅ Role-based Authorization
* ✅ Product Management (CRUD)
* ✅ Category & Brand Management
* ✅ Order Placement & Management
* ✅ Payment Processing (Simulation)
* ✅ File Upload (Local or Cloud Storage)
* ✅ Email Notifications (Configurable)
* ✅ Full Validation, Logging, Exception Handling

---

## Clean Architecture Principles

* Separation of Concerns
* Dependency Inversion
* Domain-Driven Design (DDD)
* Single Responsibility Principle (SRP)
* Unit of Work Pattern
* Repository Pattern
* CQRS with MediatR

---

## Future Improvements

* ✅ Implement UI Frontend (Blazor, React, or Angular)
* ✅ Integrate Real Payment Gateway (Stripe, PayPal, etc.)
* ✅ Dockerize the solution
* ✅ CI/CD Pipeline
* ✅ Cloud Deployment

---

## ✍️ Muallif
👤 Mukhtor Eshboyev\
🔗 GitHub: [@aestdile](https://github.com/aestdile)\
📌 "When you finish this project, upload it to GitHub and send me the repository link, I'll wait for it!"

---

## License

This project is open-source and available under the MIT License.



## 🌐 Social Networks

<div align="center">
  <a href="https://t.me/aestdile"><img src="https://img.shields.io/badge/Telegram-2CA5E0?style=for-the-badge&logo=telegram&logoColor=white" /></a>
  <a href="https://github.com/aestdile"><img src="https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white" /></a>
  <a href="https://leetcode.com/aestdile"><img src="https://img.shields.io/badge/LeetCode-FFA116?style=for-the-badge&logo=leetcode&logoColor=black" /></a>
  <a href="https://linkedin.com/in/aestdile"><img src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white" /></a>
  <a href="https://youtube.com/@aestdile"><img src="https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white" /></a>
  <a href="https://instagram.com/aestdile"><img src="https://img.shields.io/badge/Instagram-E4405F?style=for-the-badge&logo=instagram&logoColor=white" /></a>
  <a href="https://facebook.com/aestdile"><img src="https://img.shields.io/badge/Facebook-1877F2?style=for-the-badge&logo=facebook&logoColor=white" /></a>
  <a href="mailto:aestdile@gmail.com"><img src="https://img.shields.io/badge/Gmail-D14836?style=for-the-badge&logo=gmail&logoColor=white" /></a>
  <a href="https://twitter.com/aestdile"><img src="https://img.shields.io/badge/Twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white" /></a>
  <a href="tel:+998772672774"><img src="https://img.shields.io/badge/Phone:+998772672774-25D366?style=for-the-badge&logo=whatsapp&logoColor=white" /></a>
</div>
