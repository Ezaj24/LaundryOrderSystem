# Laundry Order Management System

A lightweight REST API built with ASP.NET Core Web API to manage daily orders for a dry cleaning store.

## Setup Instructions

### Prerequisites
- .NET 8 SDK
- Visual Studio 2022 or VS Code

### How to Run
1. Clone the repository
git clone https://github.com/Ezaj24/LaundryOrderSystem.git

2. Navigate to project folder
cd LaundryOrderSystem

3. Run the project
dotnet run

4. Open Swagger UI
https://localhost:{port}/swagger

## Features Implemented

- Create order with customer name, phone, garments, quantity, price
- Auto-generated unique Order ID (LD-001, LD-002...)
- Auto-calculated total bill
- Estimated delivery date (2 days from order creation)
- Update order status — RECEIVED, PROCESSING, READY, DELIVERED
- View all orders with filter by status or customer name/phone
- Dashboard — total orders, total revenue, orders per status

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | /api/orders | Create new order |
| PATCH | /api/orders/{orderId}/status | Update order status |
| GET | /api/orders | Get all orders with optional filters |
| GET | /api/orders/dashboard | Get dashboard summary |

## AI Usage Report

### Tools Used
- Claude AI (Anthropic) — primary development assistant
- Used for scaffolding, code generation, bug fixing

### How AI Helped
- Generated initial project structure and folder layout
- Scaffolded Models, DTOs, Service, and Controller
- Identified and fixed enum serialization bug (status showing as 0 instead of "Received")
- Suggested AddSingleton for in-memory storage pattern

### Sample Prompts Used
- "Create an Order model with OrderId, CustomerName, PhoneNumber, Garments list, TotalBill, Status enum and CreatedAt"
- "Write an OrderService with CreateOrder that calculates total bill and generates unique order ID"
- "Fix enum serialization so status shows as string not number"

### What AI Got Wrong
- Initial code had a counter bug where _counter was leaking into TotalBill calculation
- Had to manually identify the bug and ask AI to fix it

### What I Improved
- Verified all calculations manually
- Tested each endpoint in Swagger
- Added estimated delivery date as bonus feature

## Tradeoffs

### What I Skipped
- Database persistence (in-memory resets on restart)
- Authentication
- Frontend UI

### What I Would Improve With More Time
- Add PostgreSQL for persistent storage
- Add JWT authentication
- Add React frontend
- Deploy to Render

## Tech Stack
- C# / .NET 8
- ASP.NET Core Web API
- In-memory storage
- Swagger / OpenAPI