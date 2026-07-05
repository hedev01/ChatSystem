<div align="center">

<h1>💬 Chat System API</h1>

<p>
A scalable Chat Backend API built with <b>ASP.NET Core</b> and <b>Clean Architecture</b>.
</p>

<p>
Real-world backend architecture with authentication, authorization, validation, and real-time messaging design.
</p>

<br/>

<img src="https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
<img src="https://img.shields.io/badge/Clean%20Architecture-success?style=for-the-badge"/>
<img src="https://img.shields.io/badge/JWT-Authentication-orange?style=for-the-badge&logo=jsonwebtokens&logoColor=white"/>
<img src="https://img.shields.io/badge/SignalR-Real%20Time-1E88E5?style=for-the-badge"/>
<img src="https://img.shields.io/badge/Entity%20Framework-Core-6DB33F?style=for-the-badge"/>
<img src="https://img.shields.io/badge/Status-Under%20Development-orange?style=for-the-badge"/>

</div>

---

## ✨ Features

### 👤 User Management
- User Registration  
- Secure Identity Management  
- Authentication-ready architecture (Login/Logout expansion ready)  

---

### 🔐 Authentication & Security
- JWT-based Authentication  
- Secure token handling  
- Protected API endpoints  
- Extensible authorization system  

---

### 💬 Chat System (Architecture Design)
- Private messaging structure (in progress)  
- Group chat support (planned)  
- Real-time communication using SignalR  
- Message history persistence  
- Scalable chat domain design  

---

### 🛡️ Validation & Error Handling
- FluentValidation integration  
- Centralized error handling  
- Clean separation of concerns  

---

### 🗄️ Data Layer
- Entity Framework Core  
- Repository pattern  
- Clean separation of persistence and domain layers  
- Scalable database architecture  

---

## 🏗️ Architecture

<pre>
ChatSystem
│
├── Presentation Layer (API)
│   ├── Controllers
│   ├── Hubs
│   ├── DI
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
</pre>

---

<div align="center">

<b>Built with ASP.NET Core • Clean Architecture • SignalR Ready</b>

</div>
