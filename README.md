# CQRS Demo Projects

This repository contains three different implementations of the CQRS (Command Query Responsibility Segregation) pattern in ASP.NET Core.

## Branches Overview

### 1. `cqrs-custom` — Custom CQRS Implementation  
A clean CQRS implementation **without external libraries**, showing the fundamentals with custom dispatchers.

**Features**
- Custom Command & Query dispatchers  
- PostgreSQL database  
- Controller-based API  
- Educational approach to understand CQRS internals  

**Tech stack:** ASP.NET Core, PostgreSQL, EF Core  

---

### 2. `cqrs-mediatr` — CQRS with MediatR  
Industry-standard implementation using the **MediatR** library.

**Features**
- MediatR request/response pattern  
- Automatic handler discovery  
- Feature-based folder structure  
- PostgreSQL database  
- Clean and scalable structure  

**Tech stack:** ASP.NET Core, MediatR, PostgreSQL, EF Core  

---

### 3. *(coming soon)* `cqrs-event-driven` — Event-Driven CQRS  
Event-driven architecture using RabbitMQ for messaging.

**Features**
- PostgreSQL for write-side  
- MongoDB for read-side  
- RabbitMQ for domain events  
- Eventual consistency  
- Docker Compose infrastructure  

**Tech stack:** ASP.NET Core, PostgreSQL, MongoDB, RabbitMQ, Docker  

---

## Getting Started

### Clone & switch branches
```bash
git clone https://github.com/ZuraArabidze/CQRSDemo.git
cd CQRSDemo

git checkout cqrs-custom     # fundamentals  
git checkout cqrs-mediatr    # industry standard  
git checkout cqrs-event-driven   # advanced event-driven (coming soon)
