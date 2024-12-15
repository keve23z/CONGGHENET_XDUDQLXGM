create database QL_CH_Xe

use QL_CH_XE

CREATE TABLE NHACUNGCAP(
    MA_NCC CHAR(6) PRIMARY KEY,  -- Mã nhà cung cấp (độ dài tối đa 6 ký tự)
    TEN_NCC NVARCHAR(100) NOT NULL   -- Tên nhà cung cấp (độ dài tối đa 100 ký tự)
);
INSERT INTO NHACUNGCAP(MA_NCC , TEN_NCC) 
VALUES 
('NCC001',N'Honda Việt Nam'),
('NCC002',N'Yamaha Motor Việt Nam'),
('NCC003',N'Suzuki Việt Nam'),
('NCC004',N'Piaggio Việt Nam'),
('NCC005',N'SYM Việt Nam');

select * from NHACUNGCAP


CREATE TABLE LOAISANPHAM (
    MA_LOAI CHAR(7) PRIMARY KEY,  -- Mã loại sản phẩm (độ dài tối đa 10 ký tự)
    TENLOAI NVARCHAR(100) NOT NULL     -- Tên loại sản phẩm (độ dài tối đa 100 ký tự)
);
INSERT INTO LOAISANPHAM (MA_LOAI, TENLOAI) 
VALUES 
('LOAI001',N'Xe tay ga'),
('LOAI002',N'Xe số'),
('LOAI003',N'Xe côn tay');

CREATE TABLE SANPHAM (
    MA_SP CHAR(6) PRIMARY KEY,  -- Mã sản phẩm (độ dài tối đa 6 ký tự)
    TEN_SP NVARCHAR(100) NOT NULL, -- Tên sản phẩm
    MOTA_SP NVARCHAR(255),  -- Mô tả sản phẩm
    SOLUONG_SP INT NOT NULL,  -- Số lượng sản phẩm
    GIA_BAN DECIMAL(18,2) NOT NULL,  -- Giá bán
	GIA_NHAP DECIMAL(18,2) NOT NULL,  -- Giá nhập
    TGBAOHANH INT NOT NULL,  -- Thời gian bảo hành (tháng)
	ANH_SP NVARCHAR(200),
    MA_LOAI CHAR(7) NOT NULL,  -- Mã loại sản phẩm
	FOREIGN KEY (MA_LOAI) REFERENCES LOAISANPHAM(MA_LOAI),
);
INSERT INTO SANPHAM (MA_SP, TEN_SP, MOTA_SP, SOLUONG_SP, GIA_BAN, GIA_NHAP, TGBAOHANH,ANH_SP, MA_LOAI)
VALUES
('SP001', N'Vision 2024',		N'Xe tay ga Honda',			50, 35000000, 30000000, 24,'image1.png', 'LOAI001'),
('SP002', N'Air Blade 2024',	N'Xe tay ga Honda',			40, 45000000, 40000000, 24,'image2.png', 'LOAI001'),
('SP003', N'Exciter 150',		N'Xe côn tay Yamaha',		30, 50000000, 47000000, 24,'image3.png', 'LOAI003'),
('SP004', N'Sirius 2024',		N'Xe số Yamaha',			60, 25000000, 22000000, 18,'image4.png', 'LOAI002'),
('SP005', N'Janus 2024',		N'Xe tay ga Yamaha',		40, 32000000, 29000000, 24,'image5.png', 'LOAI001'),
('SP006', N'Piaggio Liberty',	N'Xe tay ga Piaggio',		20, 60000000, 55000000, 24,'image6.png', 'LOAI001'),
('SP007', N'Piaggio Vespa',		N'Xe tay ga Piaggio',		15, 80000000, 75000000, 24,'image7.png', 'LOAI001'),
('SP008', N'SYM Galaxy',		N'Xe số SYM',				50, 20000000, 18000000, 18,'image8.png', 'LOAI002'),
('SP009', N'SYM Elegant',		N'Xe số SYM',				60, 18000000, 16000000, 18,'image9.png', 'LOAI002'),
('SP010', N'Suzuki Raider',		N'Xe côn tay Suzuki',		25, 51000000, 47000000, 24,'image10.png','LOAI003');
select * from SANPHAM
CREATE TABLE KHACHHANG (
    SDT_KH CHAR(10) PRIMARY KEY,  -- Số điện thoại khách hàng
    TENKH NVARCHAR(100) NOT NULL,  -- Tên khách hàng
    DIACHI_KH NVARCHAR(255),  -- Địa chỉ khách hàng
    MAIL NVARCHAR(100)  -- Email khách hàng

);
INSERT INTO KHACHHANG (SDT_KH, TENKH, DIACHI_KH, MAIL)
VALUES
('0901234567', N'Nguyễn Văn A',		 N'123 Phố Huế, Hà Nội',		 'vana@gmail.com'),
('0912345678', N'Trần Thị B',		 N'456 Lê Lợi, TP.HCM',			 'thib@gmail.com'),
('0923456789', N'Lê Văn C',			 N'789 Trần Hưng Đạo, Đà Nẵng',	 'vanc@gmail.com'),
('0934567890', N'Phạm Văn D',		 N'321 Lý Thái Tổ, Hải Phòng',	 'vand@gmail.com'),
('0945678901', N'Ngô Thị E',		 N'654 Nguyễn Huệ, Nha Trang',	 'thie@gmail.com');

CREATE TABLE NHANVIEN (
    MA_NV CHAR(6) PRIMARY KEY,  -- Mã nhân viên (độ dài tối đa 6 ký tự)
    TENNV NVARCHAR(100) NOT NULL,  -- Tên nhân viên
	GIOITINH NVARCHAR(3) NOT NULL,  -- Giới tính nhân viên
    CHUCVU NVARCHAR(50),  -- Chức vụ
    SDT_NV CHAR(10),  -- Số điện thoại nhân viên
    NGAYSINH DATE,  -- Ngày sinh
    DIACHI_NV NVARCHAR(255)  -- Địa chỉ nhân viên
);

INSERT INTO NHANVIEN (MA_NV, TENNV,GIOITINH, CHUCVU, SDT_NV, NGAYSINH, DIACHI_NV)
VALUES
('NV010', N'hi', N'Nam', N'Nhân viên bán hàng', '0987654321', '2000-09-09', N'Cao Bằng'),
('NV001', N'Trần Văn A',	N'Nam',		 N'Quản lý',			'0909876543', '1985-05-15', N'123 Hoàng Diệu, Hà Nội'),
('NV002', N'Nguyễn Thị B',	N'Nữ',		 N'Nhân viên bán hàng', '0918765432', '1990-11-20', N'234 Hùng Vương, TP.HCM'),
('NV003', N'Lê Văn C',		N'Nam',		 N'Nhân viên kỹ thuật', '0927654321', '1988-09-30', N'456 Trần Phú, Đà Nẵng');

CREATE TABLE TAIKHOAN_NV (
    MA_NV CHAR(6) PRIMARY KEY,  -- Mã nhân viên (khóa ngoại từ bảng NHANVIEN)
    PASS NVARCHAR(50) NOT NULL,  -- Mật khẩu
	IS_ACTIVE BIT DEFAULT 1,
    FOREIGN KEY (MA_NV) REFERENCES NHANVIEN(MA_NV)  -- Khóa ngoại tham chiếu đến bảng NHANVIEN
);

INSERT INTO TAIKHOAN_NV (MA_NV, PASS, IS_ACTIVE)
VALUES
('NV010','NV09', 1),
('NV001', '111111', 1),
('NV002', '101010', 1),
('NV003', '123123', 1);

select * from NHANVIEN WHERE MA_NV ='NV002'
SELECT MAHD_NHAP,NGAYNHAP 
FROM HD_NHAP 
WHERE MA_NV ='NV002'
CREATE TABLE HD_NHAP (
    MAHD_NHAP CHAR(8) PRIMARY KEY,  -- Mã hóa đơn nhập (độ dài tối đa 8 ký tự)
    MA_NCC CHAR(6) NOT NULL,  -- Mã nhà cung cấp (khóa ngoại từ bảng NHACUNGCAP)
    MA_NV CHAR(6) NOT NULL,  -- Mã nhân viên (khóa ngoại từ bảng NHANVIEN)
    TONGBILL_NHAP DECIMAL(18,2),  -- Tổng số tiền hóa đơn nhập
    NGAYNHAP DATE NOT NULL,  -- Ngày nhập hàng
    FOREIGN KEY (MA_NCC) REFERENCES NHACUNGCAP(MA_NCC),
    FOREIGN KEY (MA_NV) REFERENCES NHANVIEN(MA_NV)
);

INSERT INTO HD_NHAP (MAHD_NHAP, MA_NCC, MA_NV, TONGBILL_NHAP, NGAYNHAP)
VALUES
('HDN001', 'NCC001', 'NV001', 120000000, '2024-12-01'),
('HDN002', 'NCC002', 'NV002', 140000000, '2024-12-02'),
('HDN003', 'NCC003', 'NV003', 117500000, '2024-12-03'),
('HDN004', 'NCC004', 'NV001', 157500000, '2024-12-04'),
('HDN005', 'NCC005', 'NV002', 90000000, '2024-12-05'),
('HDN006', 'NCC001', 'NV001', 175000000, '2024-12-06'),
('HDN007', 'NCC002', 'NV002', 87000000, '2024-12-07'),
('HDN008', 'NCC003', 'NV003', 47000000, '2024-12-08'),
('HDN009', 'NCC004', 'NV001', 110000000, '2024-12-09'),
('HDN010', 'NCC005', 'NV002', 60000000, '2024-12-10');

SELECT * FROM HD_NHAP

CREATE TABLE CTHD_NHAP (
    MAHD_NHAP CHAR(8),  -- Mã hóa đơn nhập (khóa ngoại từ bảng HD_NHAP)
    MA_SP CHAR(6),  -- Mã sản phẩm (khóa ngoại từ bảng SANPHAM)
    SL_NHAP INT NOT NULL,  -- Số lượng nhập
    GIA_SP DECIMAL(18,2),  -- Giá sản phẩm (SL_NHAP * GIA_NHAP)
    FOREIGN KEY (MAHD_NHAP) REFERENCES HD_NHAP(MAHD_NHAP),
    FOREIGN KEY (MA_SP) REFERENCES SANPHAM(MA_SP)
);
INSERT INTO CTHD_NHAP (MAHD_NHAP, MA_SP, SL_NHAP, GIA_SP)
VALUES
('HDN001', 'SP001', 10, 30000000),
('HDN001', 'SP002', 5, 40000000),
('HDN002', 'SP003', 10, 47000000),
('HDN002', 'SP004', 20, 22000000),
('HDN003', 'SP005', 15, 29000000),
('HDN003', 'SP006', 5, 55000000),
('HDN004', 'SP007', 3, 75000000),
('HDN004', 'SP008', 25, 18000000),
('HDN005', 'SP009', 30, 16000000),
('HDN005', 'SP010', 5, 47000000),
('HDN006', 'SP002', 8, 40000000),
('HDN007', 'SP004', 10, 22000000),
('HDN008', 'SP010', 5, 47000000),
('HDN009', 'SP006', 7, 55000000),
('HDN010', 'SP008', 10, 18000000);

SELECT * FROM CTHD_NHAP
SELECT * FROM HD_XUAT_BAOHANH
CREATE TABLE HD_XUAT_BAOHANH (
    MAHD_XUAT CHAR(8) PRIMARY KEY,  -- Mã hóa đơn xuất (độ dài tối đa 8 ký tự)
    SDT_KH CHAR(10) NOT NULL,  -- Số điện thoại khách hàng (khóa ngoại từ bảng KHACHHANG)
    MA_NV CHAR(6) NOT NULL,  -- Mã nhân viên (khóa ngoại từ bảng NHANVIEN)
    TONGBILL_XUAT DECIMAL(18,2),  -- Tổng số tiền hóa đơn xuất
    PHUONGTHUCGIAODICH NVARCHAR(50),  -- Phương thức giao dịch
    NGAYXUAT DATE NOT NULL,  -- Ngày xuất hàng
    FOREIGN KEY (SDT_KH) REFERENCES KHACHHANG(SDT_KH),
    FOREIGN KEY (MA_NV) REFERENCES NHANVIEN(MA_NV)
);
INSERT INTO HD_XUAT_BAOHANH (MAHD_XUAT, SDT_KH, MA_NV, TONGBILL_XUAT, PHUONGTHUCGIAODICH, NGAYXUAT)
VALUES
('HDX001', '0901234567', 'NV001', 35000000, N'Tiền mặt', '2024-12-01'),
('HDX002', '0912345678', 'NV002', 45000000, N'Chuyển khoản', '2024-12-02'),
('HDX003', '0923456789', 'NV003', 50000000, N'Tiền mặt', '2024-12-03'),
('HDX004', '0934567890', 'NV010', 60000000, N'Chuyển khoản', '2024-12-04'),
('HDX005', '0945678901', 'NV001', 51000000, N'Tiền mặt', '2024-12-05');

SELECT * FROM HD_XUAT_BAOHANH

CREATE TABLE CTHD_XUAT (
    MAHD_XUAT CHAR(8),  -- Mã hóa đơn xuất (khóa ngoại từ bảng HD_XUAT)
    MA_SP CHAR(6),  -- Mã sản phẩm (khóa ngoại từ bảng SANPHAM)
	SOLAN_XUAT INT,
    SL_SANPHAM INT NOT NULL,  -- Số lượng sản phẩm
    GIA_SP DECIMAL(18,2),  -- Giá sản phẩm (SL_SANPHAM * GIA_BAN)
	NGAY_BD DATE,  -- Ngày bắt đầu bảo hành và xuất sản phẩm
    NGAY_KT DATE,  -- Ngày kết thúc bảo hành
    FOREIGN KEY (MAHD_XUAT) REFERENCES HD_XUAT_BAOHANH(MAHD_XUAT),
    FOREIGN KEY (MA_SP) REFERENCES SANPHAM(MA_SP)
);

INSERT INTO CTHD_XUAT (MAHD_XUAT, MA_SP,  SL_SANPHAM, GIA_SP, NGAY_BD, NGAY_KT)
VALUES
('HDX001', 'SP001',  1, 35000000, '2024-12-01', '2026-12-01'),
('HDX002', 'SP002',  1, 45000000, '2024-12-02', '2026-12-02'),
('HDX003', 'SP003',  1, 50000000, '2024-12-03', '2026-12-03'),
('HDX004', 'SP006',  1, 60000000, '2024-12-04', '2026-12-04'),
('HDX005', 'SP010',  1, 51000000, '2024-12-05', '2026-12-05'),
('HDX001', 'SP004',  2, 44000000, '2024-12-01', '2025-12-01'),
('HDX002', 'SP005',  1, 32000000, '2024-12-02', '2026-12-02'),
('HDX003', 'SP008',  1, 20000000, '2024-12-03', '2025-12-03'),
('HDX004', 'SP007',  1, 80000000, '2024-12-04', '2026-12-04'),
('HDX005', 'SP009',  2, 36000000, '2024-12-05', '2025-12-05');

SELECT * FROM CTHD_XUAT





SELECT SUM(TONGBILL_XUAT) FROM HD_XUAT_BAOHANH WHERE MONTH(NGAYXUAT) = 11 AND YEAR(NGAYXUAT) = 2024