-- Sử dụng cơ sở dữ liệu vừa tạo
USE LoginDoAn;
GO

-- Tạo bảng Login
CREATE TABLE dbo.Login (
    Username NVARCHAR(50) NOT NULL PRIMARY KEY, -- Tên đăng nhập (khóa chính)
    Password NVARCHAR(50) NOT NULL,             -- Mật khẩu
    Type INT NOT NULL DEFAULT 0                 -- 0 là Nhân viên, 1 là Admin
);

-- Tạo bảng UserSession
CREATE TABLE dbo.UserSession (
    ID INT IDENTITY(1001,1) PRIMARY KEY,        -- ID tự động tăng từ 1001
    Username NVARCHAR(50) NOT NULL,             -- Tên đăng nhập
    SessionTime DATETIME DEFAULT GETDATE(),     -- Thời gian đăng nhập
    FOREIGN KEY (Username) REFERENCES dbo.Login(Username) ON DELETE CASCADE
);
GO

-- Thêm dữ liệu mẫu vào bảng Login
INSERT INTO dbo.Login (Username, Password, Type)
VALUES 
('admin', 'admin123', 1),  -- Admin
('user1', 'password1', 0), -- Nhân viên
('user2', 'password2', 0); -- Nhân viên