# QTKD

API đọc dữ liệu Customer và Contract. PostgreSQL, EF Core, ASP.NET Core.

## Yêu cầu

- .NET SDK 10
- PostgreSQL 18
- `dotnet-ef`: `dotnet tool install --global dotnet-ef`

Trên terminal mới, nếu `psql` hoặc `dotnet ef` không nhận lệnh, thêm vào PATH của phiên hiện tại:

```powershell
$env:PATH += ";$env:USERPROFILE\.dotnet\tools;C:\Program Files\PostgreSQL\18\bin"
```

## Cấu hình database

Tạo database:

```powershell
psql -U postgres -h localhost -c "CREATE DATABASE qtkd;"
```

Trong `src/QTKD.Api/appsettings.json`, connection string để trống. Mật khẩu đặt bằng User Secrets, không ghi vào Git:

```powershell
cd src
dotnet user-secrets init --project QTKD.Api
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=qtkd;Username=postgres;Password=YOUR_PASSWORD" --project QTKD.Api
```

## Chạy migration và dữ liệu mẫu

Đứng trong thư mục `src`:

```powershell
dotnet ef database update --project QTKD.Api
chcp 65001
$env:PGCLIENTENCODING = "UTF8"
psql -U postgres -h localhost -d qtkd -f QTKD.Api/seed.sql
```

`PGCLIENTENCODING=UTF8` để tên tiếng Việt trong `seed.sql` không bị sai chữ. File này gồm 2 Customer, 1 Contract trạng thái Draft (`HD-2026-018`) và 1 PriceList với 2 PriceItem.

## Chạy API

```powershell
dotnet run --project QTKD.Api --launch-profile http
```

Swagger: http://localhost:5279/swagger

| Method | Endpoint | Kết quả |
| :--- | :--- | :--- |
| GET | `/api/customers` | 200, danh sách khách hàng |
| GET | `/api/contracts/{id}` | 200 nếu có, 404 nếu không có |

## Cấu trúc

`Controller` nhận HTTP, `Service` xử lý, `Repository` đọc database, `QtkdDbContext` nối PostgreSQL. Response dùng DTO trong `DTOs/`.
