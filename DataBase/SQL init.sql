-- Create database if not exists
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Spedy')
BEGIN
    CREATE DATABASE Spedy;
END
GO

USE Spedy;
GO

-- Users table
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    UserRole INT NOT NULL,
    Balance DECIMAL(18, 2) NOT NULL DEFAULT 0,
    FirstName NVARCHAR(100) NULL,
    LastName NVARCHAR(100) NULL,
    DateCreated DATETIME NOT NULL DEFAULT GETUTCDATE(),
    LastLogin DATETIME NULL,
    IsLocked BIT NOT NULL DEFAULT 0,
    DeletedAt DATETIME NULL,
    NumberOfBookings INT NOT NULL DEFAULT 0,
    FailedLoginAttempts INT NOT NULL DEFAULT 0,
    LockoutEnd DATETIME NULL
);
GO

-- ActivityLogs table
CREATE TABLE ActivityLogs (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Username NVARCHAR(100) NOT NULL,
    Activity NVARCHAR(MAX) NOT NULL,
    Timestamp DATETIME NOT NULL DEFAULT GETUTCDATE()
);
GO

-- CarRentals table
CREATE TABLE CarRentals (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CarId INT NOT NULL,
    CustomerId INT NOT NULL,
    RentedAt DATETIME NOT NULL DEFAULT GETUTCDATE(),
    DueDate DATETIME NOT NULL,
    ReturnedAt DATETIME NULL
);
GO

-- Cars table
CREATE TABLE Cars (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PlateNumber NVARCHAR(50) NOT NULL,
    Brand NVARCHAR(100) NOT NULL,
    Model NVARCHAR(100) NOT NULL,
    Year INT NOT NULL,
    Color NVARCHAR(50) NULL,
    RentalPricePerDay DECIMAL(18, 2) NOT NULL,
    Status INT NOT NULL,
    ImageName NVARCHAR(256) NULL,
    DeletedAt DATETIME NULL
);
GO

-- Customers table
CREATE TABLE Customers (
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    DrivingLicenseNum NVARCHAR(50) NULL,
    Nationality NVARCHAR(100) NULL,
    Email NVARCHAR(256) NULL,
    Phone NVARCHAR(50) NULL,
    DateOfBirth DATE NULL
);
GO

-- Insert Admin user (Id auto-generated)
INSERT INTO Users (
    Username, PasswordHash, UserRole, Balance, FirstName, LastName, DateCreated, LastLogin, IsLocked, DeletedAt, NumberOfBookings, FailedLoginAttempts, LockoutEnd
)
VALUES (
    'Admin', 
    '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', 
    0,          -- UserRole (e.g., 0 for admin)
    0.00, 
    'Admin', 
    'Admin', 
    '2025-07-27 13:24:34.190', 
    NULL,       -- LastLogin
    0,          -- IsLocked (false)
    NULL,       -- DeletedAt
    0,          -- NumberOfBookings
    0,          -- FailedLoginAttempts
    NULL        -- LockoutEnd
);
GO
