CREATE USER C##QLCD_VNeID IDENTIFIED BY 123;

grant create session to  C##QLCD_VNeID;

grant create table to C##QLCD_VNeID;

alter user C##QLCD_VNeID quota 100M on users;

DROP TABLE GiayPhepLaiXe;
-- B?ng C�ng D�n
CREATE TABLE CongDan (
    congdan_id NUMBER PRIMARY KEY,  -- T?o ID t? t�ng
    ho_ten VARCHAR2(100) NOT NULL,  -- H? t�n
    ngay_sinh DATE NOT NULL,         -- Ng�y sinh
    gioi_tinh VARCHAR2(10) CHECK (gioi_tinh IN ('Nam', 'N?')),  -- Gi?i t�nh v?i CHECK constraint
    so_cmnd VARCHAR2(15) UNIQUE NOT NULL,  -- S? CMND/CCCD (�?m b?o duy nh?t)
    dien_thoai VARCHAR2(15) NOT NULL,  -- S? �i?n tho?i
    email VARCHAR2(100),  -- Email
    hokhau_id NUMBER NOT NULL,  -- ID h? kh?u (kh�a ngo?i ti?m n�ng)
    diachi NVARCHAR2(100) NOT NULL  -- �?a ch?
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
    giayphep_id NUMBER PRIMARY KEY,        -- M? gi?y ph�p
    congdan_id NUMBER NOT NULL,            -- M? c�ng d�n (kh�a ngo?i ti?m n�ng)
    so_giay_phep VARCHAR2(20) UNIQUE NOT NULL,  -- S? gi?y ph�p
    loaibang_id NUMBER NOT NULL,           -- Lo?i b?ng (kh�a ngo?i ti?m n�ng)
    ngay_cap DATE NOT NULL,                -- Ng�y c?p gi?y ph�p
    co_quan_cap VARCHAR2(100) NOT NULL     -- C� quan c?p
);




ALTER TABLE CongDan
ADD CONSTRAINT fk_hokhau FOREIGN KEY (hokhau_id) REFERENCES HoKhau(hokhau_id);

ALTER TABLE GiayPhepLaiXe
ADD CONSTRAINT fk_gplx_congdan FOREIGN KEY (congdan_id) REFERENCES CongDan(congdan_id);

ALTER TABLE GiayPhepLaiXe
ADD CONSTRAINT fk_gplx_lblx FOREIGN KEY (loaibang_id) REFERENCES LoaiBangLaiXe(loaibang_id);
------------------------------------------------------------------------------------------------
-- Trigger �? t? �?ng t�ng congdan_id
CREATE OR REPLACE TRIGGER trg_congdan_id
BEFORE INSERT ON CongDan
FOR EACH ROW
BEGIN
    SELECT congdan_seq.NEXTVAL INTO :NEW.congdan_id FROM dual;
END;

-- Trigger �? t? �?ng t�ng giayphep_id
CREATE OR REPLACE TRIGGER trg_giayphep_id
BEFORE INSERT ON GiayPhepLaiXe
FOR EACH ROW
BEGIN
    SELECT giayphep_seq.NEXTVAL INTO :NEW.giayphep_id FROM dual;
END;

-- Trigger �? t? �?ng t�ng hokhau_id
CREATE OR REPLACE TRIGGER trg_hokhau_id
BEFORE INSERT ON HoKhau
FOR EACH ROW
BEGIN
    SELECT hokhau_seq.NEXTVAL INTO :NEW.hokhau_id FROM dual;
END;
------------------------------------------------------------------------------------------------

-- Th�m d? li?u v�o b?ng HoKhau
INSERT INTO HoKhau (hokhau_id, ma_ho_khau, dia_chi, phuong, quan, thanh_pho, tinh, ngay_tao)
VALUES (1, 'HK001', '123 ��?ng Nguy?n Hu?', 'Ph�?ng 1', 'Qu?n 1', 'TP. H? Ch� Minh', 'H? Ch� Minh', TO_DATE('2020-01-15', 'YYYY-MM-DD'));

INSERT INTO HoKhau (hokhau_id, ma_ho_khau, dia_chi, phuong, quan, thanh_pho, tinh, ngay_tao)
VALUES (2, 'HK002', '456 ��?ng Tr?n H�ng �?o', 'Ph�?ng 2', 'Qu?n 5', 'TP. H? Ch� Minh', 'H? Ch� Minh', TO_DATE('2021-03-22', 'YYYY-MM-DD'));

INSERT INTO HoKhau (hokhau_id, ma_ho_khau, dia_chi, phuong, quan, thanh_pho, tinh, ngay_tao)
VALUES (3, 'HK003', '789 ��?ng �i?n Bi�n Ph?', 'Ph�?ng 6', 'Qu?n 3', 'TP. H? Ch� Minh', 'H? Ch� Minh', TO_DATE('2019-11-11', 'YYYY-MM-DD'));


-- Th�m d? li?u v�o b?ng CongDan
INSERT INTO CongDan (congdan_id, ho_ten, ngay_sinh, gioi_tinh, so_cmnd, dien_thoai, email, hokhau_id, diachi)
VALUES (1, 'Nguy?n V�n A', TO_DATE('1990-05-20', 'YYYY-MM-DD'), 'Nam', '0123456789', '0909123456', 'nguyenvana@gmail.com', 1, '123 ��?ng Nguy?n Hu?');

INSERT INTO CongDan (congdan_id, ho_ten, ngay_sinh, gioi_tinh, so_cmnd, dien_thoai, email, hokhau_id, diachi)
VALUES (2, 'Tr?n Th? B', TO_DATE('1985-08-15', 'YYYY-MM-DD'), 'N?', '9876543210', '0909765432', 'tranthib@gmail.com', 2, '456 ��?ng Tr?n H�ng �?o');

INSERT INTO CongDan (congdan_id, ho_ten, ngay_sinh, gioi_tinh, so_cmnd, dien_thoai, email, hokhau_id, diachi)
VALUES (3, 'L� Ho�ng C', TO_DATE('1992-11-02', 'YYYY-MM-DD'), 'Nam', '1122334455', '0911234567', 'lehoangc@gmail.com', 3, '789 ��?ng �i?n Bi�n Ph?');


-- Th�m d? li?u v�o b?ng GiayPhepLaiXe (m?i gi?y ph�p l�i xe li�n k?t v?i m?t c�ng d�n)
INSERT INTO GiayPhepLaiXe (giayphep_id, congdan_id, so_giay_phep, loaibang_id, ngay_cap, co_quan_cap)
VALUES (1, 1, 'GPLX001', 1, TO_DATE('2022-02-18', 'YYYY-MM-DD'), 'S? Giao th�ng V?n t?i TP. H? Ch� Minh');

INSERT INTO GiayPhepLaiXe (giayphep_id, congdan_id, so_giay_phep, loaibang_id, ngay_cap, co_quan_cap)
VALUES (2, 2, 'GPLX002', 2, TO_DATE('2023-01-10', 'YYYY-MM-DD'), 'S? Giao th�ng V?n t?i TP. H? Ch� Minh');

INSERT INTO GiayPhepLaiXe (giayphep_id, congdan_id, so_giay_phep, loaibang_id, ngay_cap, co_quan_cap)
VALUES (3, 3, 'GPLX003', 3, TO_DATE('2023-07-12', 'YYYY-MM-DD'), 'S? Giao th�ng V?n t?i TP. H? Ch� Minh');


select * from CongDan

