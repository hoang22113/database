-- Tạo database
CREATE DATABASE SalesManagement;
GO

USE SalesManagement;
GO

-- Tạo bảng Category
CREATE TABLE Category (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);

-- Tạo bảng Supplier
CREATE TABLE Supplier (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Phone NVARCHAR(20),
    Email NVARCHAR(100)
);

-- Tạo bảng Product
CREATE TABLE Product (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    StockQuantity INT NOT NULL,
    Description NVARCHAR(500),
    CategoryID INT,
    FOREIGN KEY (CategoryID) REFERENCES Category(ID)
);

-- Tạo bảng Employee
CREATE TABLE Employee (
    ID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Position NVARCHAR(50),
    Level INT,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL
);

-- Tạo bảng Customer
CREATE TABLE Customer (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Phone NVARCHAR(20),
    Email NVARCHAR(100)
);

-- Tạo bảng Order
CREATE TABLE [Order] (
    ID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    EmployeeID INT,
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL,
    Status NVARCHAR(50),
    FOREIGN KEY (CustomerID) REFERENCES Customer(ID),
    FOREIGN KEY (EmployeeID) REFERENCES Employee(ID)
);

-- Tạo bảng OrderDetail
CREATE TABLE OrderDetail (
    ID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    ProductID INT,
    Quantity INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES [Order](ID),
    FOREIGN KEY (ProductID) REFERENCES Product(ID)
);

-- Chèn dữ liệu mẫu
-- Category
INSERT INTO Category (Name) VALUES 
(N'Electronics'),
(N'Clothing'),
(N'Books');

-- Supplier
INSERT INTO Supplier (Name, Address, Phone, Email) VALUES
(N'Tech Supplier Ltd', N'123 Tech Street, Hanoi', N'0123456789', N'tech@supplier.com'),
(N'Fashion Co', N'456 Fashion Ave, HCMC', N'0987654321', N'fashion@supplier.com');

-- Product
INSERT INTO Product (Name, Price, StockQuantity, Description, CategoryID) VALUES
(N'Smartphone X', 599.99, 100, N'Latest smartphone model', 1),
(N'T-Shirt Basic', 19.99, 200, N'Comfortable cotton t-shirt', 2),
(N'Programming Book', 49.99, 50, N'Learn C# programming', 3);

-- Employee
INSERT INTO Employee (FullName, Position, Level, Username, Password) VALUES
(N'Nguyen Van A', N'Sales Manager', 3, N'nguyenvana', N'password123'),
(N'Tran Thi B', N'Sales Staff', 1, N'tranthib', N'password456');

-- Customer
INSERT INTO Customer (Name, Address, Phone, Email) VALUES
(N'Le Van C', N'789 Customer Road, Hanoi', N'0912345678', N'levanc@email.com'),
(N'Pham Thi D', N'101 Customer Lane, HCMC', N'0908765432', N'phamthid@email.com');

-- Order
INSERT INTO [Order] (CustomerID, EmployeeID, OrderDate, TotalAmount, Status) VALUES
(1, 1, '2025-08-13 10:00:00', 619.98, N'Completed'),
(2, 2, '2025-08-13 11:00:00', 49.99, N'Pending');

-- OrderDetail
INSERT INTO OrderDetail (OrderID, ProductID, Quantity, Price) VALUES
(1, 1, 1, 599.99),
(1, 2, 1, 19.99),
(2, 3, 1, 49.99);