CREATE USER C##QLCD_VNeID IDENTIFIED BY 123;

grant create session to  C##QLCD_VNeID;

grant create table to C##QLCD_VNeID;

alter user C##QLCD_VNeID quota 100M on users;

DROP TABLE GiayPhepLaiXe;
-- B?ng Công Dân
CREATE TABLE CongDan (
    congdan_id NUMBER PRIMARY KEY,  -- T?o ID t? tãng
    ho_ten VARCHAR2(100) NOT NULL,  -- H? tên
    ngay_sinh DATE NOT NULL,         -- Ngày sinh
    gioi_tinh VARCHAR2(10) CHECK (gioi_tinh IN ('Nam', 'N?')),  -- Gi?i tính v?i CHECK constraint
    so_cmnd VARCHAR2(15) UNIQUE NOT NULL,  -- S? CMND/CCCD (ð?m b?o duy nh?t)
    dien_thoai VARCHAR2(15) NOT NULL,  -- S? ði?n tho?i
    email VARCHAR2(100),  -- Email
    hokhau_id NUMBER NOT NULL,  -- ID h? kh?u (khóa ngo?i ti?m nãng)
    diachi NVARCHAR2(100) NOT NULL  -- Ð?a ch?
);


-- B?ng H? Kh?u
CREATE TABLE HoKhau (
    hokhau_id NUMBER PRIMARY KEY,
    ma_ho_khau VARCHAR2(50) UNIQUE NOT NULL,
    dia_chi VARCHAR2(200) NOT NULL,
    phuong VARCHAR2(30) NOT NULL,
    quan NVARCHAR2(30) NOT NULL,
    thanh_pho NVARCHAR2(30),
    tinh NVARCHAR2(30) NOT NULL,
    ngay_tao DATE
);


CREATE TABLE GiayPhepLaiXe (
    giayphep_id NUMBER PRIMARY KEY,        -- M? gi?y phép
    congdan_id NUMBER NOT NULL,            -- M? công dân (khóa ngo?i ti?m nãng)
    so_giay_phep VARCHAR2(20) UNIQUE NOT NULL,  -- S? gi?y phép
    loaibang_id NUMBER NOT NULL,           -- Lo?i b?ng (khóa ngo?i ti?m nãng)
    ngay_cap DATE NOT NULL,                -- Ngày c?p gi?y phép
    co_quan_cap VARCHAR2(100) NOT NULL     -- Cõ quan c?p
);




ALTER TABLE CongDan
ADD CONSTRAINT fk_hokhau FOREIGN KEY (hokhau_id) REFERENCES HoKhau(hokhau_id);

ALTER TABLE GiayPhepLaiXe
ADD CONSTRAINT fk_gplx_congdan FOREIGN KEY (congdan_id) REFERENCES CongDan(congdan_id);

ALTER TABLE GiayPhepLaiXe
ADD CONSTRAINT fk_gplx_lblx FOREIGN KEY (loaibang_id) REFERENCES LoaiBangLaiXe(loaibang_id);
------------------------------------------------------------------------------------------------
-- Trigger ð? t? ð?ng tãng congdan_id
CREATE OR REPLACE TRIGGER trg_congdan_id
BEFORE INSERT ON CongDan
FOR EACH ROW
BEGIN
    SELECT congdan_seq.NEXTVAL INTO :NEW.congdan_id FROM dual;
END;

-- Trigger ð? t? ð?ng tãng giayphep_id
CREATE OR REPLACE TRIGGER trg_giayphep_id
BEFORE INSERT ON GiayPhepLaiXe
FOR EACH ROW
BEGIN
    SELECT giayphep_seq.NEXTVAL INTO :NEW.giayphep_id FROM dual;
END;

-- Trigger ð? t? ð?ng tãng hokhau_id
CREATE OR REPLACE TRIGGER trg_hokhau_id
BEFORE INSERT ON HoKhau
FOR EACH ROW
BEGIN
    SELECT hokhau_seq.NEXTVAL INTO :NEW.hokhau_id FROM dual;
END;
------------------------------------------------------------------------------------------------

-- Thêm d? li?u vào b?ng HoKhau
INSERT INTO HoKhau (hokhau_id, ma_ho_khau, dia_chi, phuong, quan, thanh_pho, tinh, ngay_tao)
VALUES (1, 'HK001', '123 Ðý?ng Nguy?n Hu?', 'Phý?ng 1', 'Qu?n 1', 'TP. H? Chí Minh', 'H? Chí Minh', TO_DATE('2020-01-15', 'YYYY-MM-DD'));

INSERT INTO HoKhau (hokhau_id, ma_ho_khau, dia_chi, phuong, quan, thanh_pho, tinh, ngay_tao)
VALUES (2, 'HK002', '456 Ðý?ng Tr?n Hýng Ð?o', 'Phý?ng 2', 'Qu?n 5', 'TP. H? Chí Minh', 'H? Chí Minh', TO_DATE('2021-03-22', 'YYYY-MM-DD'));

INSERT INTO HoKhau (hokhau_id, ma_ho_khau, dia_chi, phuong, quan, thanh_pho, tinh, ngay_tao)
VALUES (3, 'HK003', '789 Ðý?ng Ði?n Biên Ph?', 'Phý?ng 6', 'Qu?n 3', 'TP. H? Chí Minh', 'H? Chí Minh', TO_DATE('2019-11-11', 'YYYY-MM-DD'));


-- Thêm d? li?u vào b?ng CongDan
INSERT INTO CongDan (congdan_id, ho_ten, ngay_sinh, gioi_tinh, so_cmnd, dien_thoai, email, hokhau_id, diachi)
VALUES (1, 'Nguy?n Vãn A', TO_DATE('1990-05-20', 'YYYY-MM-DD'), 'Nam', '0123456789', '0909123456', 'nguyenvana@gmail.com', 1, '123 Ðý?ng Nguy?n Hu?');

INSERT INTO CongDan (congdan_id, ho_ten, ngay_sinh, gioi_tinh, so_cmnd, dien_thoai, email, hokhau_id, diachi)
VALUES (2, 'Tr?n Th? B', TO_DATE('1985-08-15', 'YYYY-MM-DD'), 'N?', '9876543210', '0909765432', 'tranthib@gmail.com', 2, '456 Ðý?ng Tr?n Hýng Ð?o');

INSERT INTO CongDan (congdan_id, ho_ten, ngay_sinh, gioi_tinh, so_cmnd, dien_thoai, email, hokhau_id, diachi)
VALUES (3, 'Lê Hoàng C', TO_DATE('1992-11-02', 'YYYY-MM-DD'), 'Nam', '1122334455', '0911234567', 'lehoangc@gmail.com', 3, '789 Ðý?ng Ði?n Biên Ph?');


-- Thêm d? li?u vào b?ng GiayPhepLaiXe (m?i gi?y phép lái xe liên k?t v?i m?t công dân)
INSERT INTO GiayPhepLaiXe (giayphep_id, congdan_id, so_giay_phep, loaibang_id, ngay_cap, co_quan_cap)
VALUES (1, 1, 'GPLX001', 1, TO_DATE('2022-02-18', 'YYYY-MM-DD'), 'S? Giao thông V?n t?i TP. H? Chí Minh');

INSERT INTO GiayPhepLaiXe (giayphep_id, congdan_id, so_giay_phep, loaibang_id, ngay_cap, co_quan_cap)
VALUES (2, 2, 'GPLX002', 2, TO_DATE('2023-01-10', 'YYYY-MM-DD'), 'S? Giao thông V?n t?i TP. H? Chí Minh');

INSERT INTO GiayPhepLaiXe (giayphep_id, congdan_id, so_giay_phep, loaibang_id, ngay_cap, co_quan_cap)
VALUES (3, 3, 'GPLX003', 3, TO_DATE('2023-07-12', 'YYYY-MM-DD'), 'S? Giao thông V?n t?i TP. H? Chí Minh');


select * from CongDan

