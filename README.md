# eCommerce Platform Microservices

A modern eCommerce platform utilizing microservices architecture built with .NET 6 and leveraging CQRS and the MediatR pattern.

## Microservices Overview

1. **Catalog.Api**: Responsible for managing product listings and categories.
2. **Basket.Api**: Handles user shopping cart functionality.
3. **Discount.Grpc**: Offers GRPC-based services for managing and applying discounts.
4. **Ordering.Api**: Manages customer orders, processing, and tracking.

## Tech Stack

- .NET 6
- CQRS with MediatR
- GRPC
- RabbitMQ
- MongoDB
- Redis
- SQL Server
- PostgreSQL

## Getting Started

### Prerequisites

- .NET SDK 6.0
- Docker
- [Any other prerequisites]

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Ecommar/Ecommar.Catalog.git
