# 💬 Chat System API

A modern and scalable Chat Backend API built with **ASP.NET Core** and **Clean Architecture** principles.

This project demonstrates real-world backend development practices including Authentication, Authorization, Validation, Domain Separation, and extensible architecture for real-time messaging systems.

---

## ✨ Features

### 👤 User Management

- User Registration
- (Login / Logout coming soon)
- JWT Authentication (planned expansion)
- Secure user identity management

---

### 🔐 Authentication & Security

- JWT-based Authentication
- Secure Token Handling
- Protected API Endpoints
- Extensible Authorization System

---

### 💬 Chat System (In Progress)

- Private Messaging (planned)
- Group Chat Support (planned)
- Real-time Communication with SignalR (planned)
- Message History Storage
- Scalable Chat Architecture Design

---

### 🛡️ Validation & Error Handling

- Request Validation using FluentValidation
- Clean and consistent error responses
- Separation of validation logic from business logic

---

### 🗄️ Data Layer

- Entity Framework Core
- Clean separation of persistence layer
- Scalable database design

---

## 🏗️ Architecture

This project follows the **Clean Architecture** pattern.

```text
ChatSystem
│
├── Presentation Layer (API)
│   ├── Controllers
│   ├── DI
│   ├── Hubs
│
├── Application Layer
│   ├── UseCases
│   ├── DTOs
│   ├── Interfaces
│
├── Domain Layer
│   ├── Entities
│   ├── ValueObjects
│   ├── Enums
│   ├── Interfaces
│
├── Infrastructure Layer
│   ├── EF Core
│   ├── Repositories
│   ├── Services
│
└── Persistence
    └── SQL Server
