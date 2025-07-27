-- 1. Create the database
CREATE DATABASE Spedy;
GO

-- 2. Use the database
USE Spedy;
GO

-- 3. Create Users table
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    UserRole NVARCHAR(20) NOT NULL DEFAULT 'User',
    Balance DECIMAL(18, 2) NOT NULL DEFAULT 0,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    DateCreated DATETIME NOT NULL DEFAULT GETUTCDATE(),
    LastLogin DATETIME NULL,
    IsLocked BIT NOT NULL DEFAULT 0,
    DeletedAt DATETIME NULL,
    NumberOfBookings INT NOT NULL DEFAULT 0
);
GO

-- 4. Create Customers table
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    DrivingLicenseNum NVARCHAR(50) NOT NULL,
    Nationality NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    DateOfBirth DATE NOT NULL
);
GO

-- 5. Create Cars table
CREATE TABLE Cars (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PlateNumber NVARCHAR(20) NOT NULL,
    Brand NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    Year INT NOT NULL,
    Color NVARCHAR(30) NOT NULL,
    RentalPricePerDay DECIMAL(18, 2) NOT NULL,
    Status NVARCHAR(30) NOT NULL
);
GO

-- 6. Create Bookings table
CREATE TABLE Bookings (
    BookingId INT PRIMARY KEY IDENTITY(1,1),
    CarId INT NOT NULL,
    CustomerId INT NOT NULL,
    UserId INT NOT NULL,
    BookingDate DATETIME NOT NULL,
    BookingStartAt DATETIME NOT NULL,
    BookingEndAt DATETIME NOT NULL,
    TotalPrice DECIMAL(18, 2) NOT NULL,

    FOREIGN KEY (CarId) REFERENCES Cars(Id),
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
GO
