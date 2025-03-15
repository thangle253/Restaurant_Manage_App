CREATE DATABASE LoginDoAn;
GO
USE LoginDoAn;
GO

-- Tạo bảng Đăng nhập (Login)
CREATE TABLE dbo.Login (
    Username NVARCHAR(50) NOT NULL PRIMARY KEY, 
    Password NVARCHAR(50) NOT NULL,             
    Type INT NOT NULL DEFAULT 0  -- 0: Nhân viên, 1: Admin
);
GO

-- Tạo bảng Nhân viên (Employees)
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,  
    Username NVARCHAR(50) UNIQUE NOT NULL,  -- ✅ Liên kết với bảng Login
    FullName NVARCHAR(100) NOT NULL,        
    PhoneNumber NVARCHAR(15) NOT NULL,      
    ProfilePicture NVARCHAR(255),           
    Address NVARCHAR(255),                  
    DateOfBirth DATE,                       
    BaseSalary DECIMAL(10,2) DEFAULT 0,     
    TotalWorkHours DECIMAL(10,2) DEFAULT 0, 
    FOREIGN KEY (Username) REFERENCES dbo.Login(Username) ON DELETE CASCADE
);
GO

-- Tạo bảng Chấm công (Attendance)
CREATE TABLE Attendance (
    AttendanceID INT IDENTITY(1,1) PRIMARY KEY,  
    EmployeeID INT NOT NULL,                     
    TimeCheckIn DATETIME NOT NULL,              
    TimeCheckOut DATETIME NULL,                  
    HoursWorked DECIMAL(10,2) DEFAULT 0,         
    SalaryEarned DECIMAL(10,2) DEFAULT 0,        
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE
);
GO

-- Tạo bảng Phiên đăng nhập (UserSession)
CREATE TABLE UserSession (
    ID INT IDENTITY(1001,1) PRIMARY KEY,        
    Username NVARCHAR(50) NOT NULL,  -- ✅ Giữ nguyên Username
    SessionTime DATETIME DEFAULT GETDATE(),     
    FOREIGN KEY (Username) REFERENCES dbo.Login(Username) ON DELETE CASCADE
);
GO


-- Thêm dữ liệu vào bảng Login
INSERT INTO dbo.Login (Username, Password, Type)
VALUES 
('admin', 'admin123', 1),  
('user1', 'password1', 0), 
('user2', 'password2', 0),
('user3', 'password3', 0),
('user4', 'password4', 0);
GO

-- Thêm dữ liệu vào bảng Employees
INSERT INTO Employees (Username, FullName, PhoneNumber, Address, DateOfBirth, BaseSalary)
VALUES 
('user1', 'Nguyễn Văn A', '0987654321', 'Hà Nội', '1990-05-12', 8000000),
('user2', 'Trần Thị B', '0976543210', 'TP. Hồ Chí Minh', '1995-10-22', 7500000),
('user3', 'Lê Văn C', '0965432109', 'Đà Nẵng', '1992-03-18', 7000000),
('user4', 'Phạm Thị D', '0954321098', 'Hải Phòng', '1998-07-25', 6800000),
('admin', 'Hoàng Văn E', '0943210987','Cần Thơ', '1993-12-05', 7200000);
GO

-- Thêm dữ liệu vào bảng Attendance
INSERT INTO Attendance (EmployeeID, TimeCheckIn, TimeCheckOut, HoursWorked, SalaryEarned)
VALUES 
(1, '2024-03-01 08:00:00', '2024-03-01 17:00:00', 9, 450000),
(1, '2024-03-02 08:15:00', '2024-03-02 17:05:00', 8.5, 425000),
(2, '2024-03-01 07:45:00', '2024-03-01 16:45:00', 9, 450000),
(2, '2024-03-02 08:30:00', '2024-03-02 17:30:00', 9, 450000),
(3, '2024-03-01 08:30:00', '2024-03-01 17:15:00', 8.75, 437500),
(3, '2024-03-02 09:00:00', '2024-03-02 18:00:00', 9, 450000)
