CREATE DATABASE QuanLyNhaHang;
GO
-- Sử dụng Database
USE QuanLyNhaHang;
GO

-- Bảng LoaiMon (Tạo trước vì MonAn tham chiếu đến bảng này)
CREATE TABLE LoaiMon (
    MaLoaiMon INT PRIMARY KEY, 
    TenLoaiMon NVARCHAR(50) NOT NULL -- Dùng NVARCHAR cho tiếng Việt có dấu
);
GO

-- Bảng MonAn
CREATE TABLE MonAn (
    MaMon INT PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL, -- Dùng NVARCHAR cho tiếng Việt có dấu
    MaLoaiMon INT NOT NULL,
    GiaTien DECIMAL(18, 2) NOT NULL,
	HinhAnh NVARCHAR(255) ,
    FOREIGN KEY (MaLoaiMon) REFERENCES LoaiMon(MaLoaiMon)
);
GO

-- Bảng BanAn
CREATE TABLE BanAn (
    MaBan INT PRIMARY KEY, 
    TenBan NVARCHAR(50) NOT NULL, -- Dùng NVARCHAR cho tên bàn có thể có dấu
    TrangThai NVARCHAR(20) NOT NULL,
    SoLuongChoNgoi INT NOT NULL

);
GO

-- Bảng DonHang
CREATE TABLE DonHang (
    MaDonHang INT PRIMARY KEY, 
    MaBan INT NOT NULL,
    NgayDat DATETIME NOT NULL,
    TongTien DECIMAL(18, 2),
    TrangThai NVARCHAR(20) NOT NULL,
    FOREIGN KEY (MaBan) REFERENCES BanAn(MaBan)
);
GO

-- Bảng ChiTietDonHang
CREATE TABLE ChiTietDonHang (
    MaChiTiet INT PRIMARY KEY, 
    MaDonHang INT NOT NULL,
    MaMon INT NOT NULL,
    SoLuong INT NOT NULL,
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang),
    FOREIGN KEY (MaMon) REFERENCES MonAn(MaMon)
);
GO
-- Bảng ThongKe
CREATE TABLE ThongKe (
    MaThongKe INT PRIMARY KEY IDENTITY(1,1), -- Khóa chính, tự động tăng
    MaBan INT NOT NULL,                     -- Mã bàn (khóa ngoại)
    Ngay DATE NOT NULL,                     -- Ngày thanh toán (Ngày vào và Ngày ra chung)
    SoLuongMon INT NOT NULL,                -- Tổng số lượng món
    TongTien DECIMAL(18, 2) NOT NULL,       -- Tổng tiền thanh toán
    FOREIGN KEY (MaBan) REFERENCES BanAn(MaBan) -- Ràng buộc khóa ngoại với bảng BanAn
);
GO
CREATE TRIGGER trg_ThanhToan
ON DonHang
AFTER UPDATE
AS
BEGIN
    -- Kiểm tra xem trạng thái đơn hàng có phải là 'Đã Thanh Toán' hay không
    IF EXISTS (SELECT * FROM Inserted WHERE TrangThai = N'Đã Thanh Toán')
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION;

            -- Lưu thông tin vào bảng ThongKe khi đơn hàng đã thanh toán
            INSERT INTO ThongKe (MaBan, Ngay, SoLuongMon, TongTien)
            SELECT d.MaBan, GETDATE(), COUNT(ct.MaMon), d.TongTien
            FROM Inserted d
            JOIN ChiTietDonHang ct ON d.MaDonHang = ct.MaDonHang
            WHERE d.TrangThai = N'Đã Thanh Toán'
            GROUP BY d.MaBan, d.TongTien;

            -- Xóa chi tiết đơn hàng đã thanh toán
            DELETE FROM ChiTietDonHang
            WHERE MaDonHang IN (SELECT MaDonHang FROM Inserted WHERE TrangThai = N'Đã Thanh Toán');

            -- Xóa đơn hàng đã thanh toán
            DELETE FROM DonHang
            WHERE MaDonHang IN (SELECT MaDonHang FROM Inserted WHERE TrangThai = N'Đã Thanh Toán');

            -- Cập nhật trạng thái bàn thành 'Trống'
            UPDATE BanAn
            SET TrangThai = N'Trống'
            WHERE MaBan IN (SELECT MaBan FROM Inserted WHERE TrangThai = N'Đã Thanh Toán');

            COMMIT TRANSACTION;
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION;
            THROW;
        END CATCH
    END
END;
GO

-- Dữ liệu bảng BanAn (20 bàn, mặc định trạng thái "Trống")
INSERT INTO BanAn (MaBan, TenBan, TrangThai, SoLuongChoNgoi) VALUES 
(1, N'Bàn 1', N'Trống', 4),
(2, N'Bàn 2', N'Trống', 6),
(3, N'Bàn 3', N'Trống', 4),
(4, N'Bàn 4', N'Trống', 8),
(5, N'Bàn 5', N'Trống', 4),
(6, N'Bàn 6', N'Trống', 6),
(7, N'Bàn 7', N'Trống', 4),
(8, N'Bàn 8', N'Trống', 6),
(9, N'Bàn 9', N'Trống', 8),
(10, N'Bàn 10', N'Trống', 4),
(11, N'Bàn 11', N'Trống', 4),
(12, N'Bàn 12', N'Trống', 6),
(13, N'Bàn 13', N'Trống', 4),
(14, N'Bàn 14', N'Trống', 8),
(15, N'Bàn 15', N'Trống', 4),
(16, N'Bàn 16', N'Trống', 6),
(17, N'Bàn 17', N'Trống', 8),
(18, N'Bàn 18', N'Trống', 4),
(19, N'Bàn 19', N'Trống', 6),
(20, N'Bàn 20', N'Trống', 8);
GO

-- Dữ liệu bảng LoaiMon
INSERT INTO LoaiMon (MaLoaiMon, TenLoaiMon) VALUES 
(1, N'Khai Vị'),
(2, N'Món Chính'),
(3, N'Tráng Miệng'),
(4, N'Nước Uống');
GO

-- Dữ liệu bảng MonAn
INSERT INTO MonAn (MaMon, TenMon, MaLoaiMon, GiaTien, HinhAnh) VALUES 
(1, N'Gỏi cuốn', 1, 35000, 'Food_Image\GoiCuon.png'),
(2, N'Chả giò', 1, 40000, 'Food_Image\ChaGio.png'),
(3, N'Cơm tấm sườn', 2, 45000, 'Food_Image\ComTam.png'),
(4, N'Phở bò', 2, 50000, 'Food_Image\PhoBo.png'),
(5, N'Bánh xèo', 2, 60000, 'Food_Image\BanhXeo.png'),
(6, N'Bánh bèo', 2, 30000, 'Food_Image\BanhBeo.png'),
(7, N'Chè trôi nước', 3, 20000, 'Food_Image\CheTroiNuoc.png'),
(8, N'Rau câu dừa', 3, 15000, 'Food_Image\RauCauDua.png'),
(9, N'Sinh tố dâu', 4, 30000, 'Food_Image\SinhToDau.png'),
(10, N'Trà đá', 4, 5000, 'Food_Image\TraDa.png'),
(11, N'Cà phê sữa', 4, 20000, 'Food_Image\CafeSua.png'),
(12, N'Nước ngọt', 4, 15000, 'Food_Image\Coca.png');
GO








