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
    Username NVARCHAR(50) UNIQUE NOT NULL,  --Liên kết với bảng Login
    FullName NVARCHAR(100) NOT NULL,        
    PhoneNumber NVARCHAR(15) NOT NULL,      
    ProfilePicture NVARCHAR(255),           
    Address NVARCHAR(255),                  
    DateOfBirth DATE,                       
    BaseSalary DECIMAL(10,2) DEFAULT 0,     
    TotalWorkHours DECIMAL(10,2) DEFAULT 0, -- Tổng số giờ làm trong một tháng
    FOREIGN KEY (Username) REFERENCES dbo.Login(Username) ON DELETE CASCADE
);
GO

-- Tạo bảng Chấm công (Attendance)
CREATE TABLE Attendance (
    AttendanceID INT IDENTITY(1,1) PRIMARY KEY,  
    EmployeeID INT NOT NULL,                     
    TimeCheckIn DATETIME NOT NULL,              
    TimeCheckOut DATETIME NULL,                  
    HoursWorked DECIMAL(10,2) DEFAULT 0, -- Tổng số giờ làm trong một ngày        
    SalaryEarned DECIMAL(10,2) DEFAULT 0,  -- Tính lương dựa trên số giờ làm 
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE
);
GO

-- Tạo bảng Phiên đăng nhập (UserSession)
CREATE TABLE UserSession (
    ID INT IDENTITY(1001,1) PRIMARY KEY,        
    Username NVARCHAR(50) NOT NULL,  -- Giữ nguyên Username
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

--Dùng để đặt lại ID tự tăng: DBCC CHECKIDENT ('Employees', RESEED, 0);

-- Thêm dữ liệu vào bảng Employees
INSERT INTO Employees (Username, FullName, PhoneNumber, ProfilePicture, Address, DateOfBirth, BaseSalary)
VALUES 
('user1', N'Võ Thanh Sang', '0987654321','Employee_Images\sang.jpg', N'TP.Hồ Chí Minh', '2005-05-01', 8000000),
('user2', N'Lê Văn Chiến Thắng', '0976543210','Employee_Images\thangle.jpg', N'TP.Hồ Chí Minh', '2005-03-25', 7500000),
('user3', N'Trịnh Nguyễn Hoàng Nguyên', '0965432109','Employee_Images\nguyen.jpg', N'TP.Hồ Chí Minh', '1992-03-18', 7000000),
('user4', N'Nguyễn Phước Khang', '0954321098','Employee_Images\khang.jpg', N'TP.Hồ Chí Minh', '2005-01-07', 6800000),
('admin', N'Trịnh Trần Phương Tuấn', '0943210987','Employee_Images\default.jpg',N'Bến Tre', '1993-04-12', 7200000);
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


