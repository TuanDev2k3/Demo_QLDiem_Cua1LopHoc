Create database QL_Diem
set identity_insert [dbo].[HocSinh] on
Insert MonHoc (MaMon, TenMon) Values (1, N'Toán')
Insert MonHoc (MaMon, TenMon) Values (2, N'Tiếng việt')
Insert MonHoc (MaMon, TenMon) Values (3, N'Anh văn')
Insert MonHoc (MaMon, TenMon) Values (4, N'Âm nhạc')
Insert MonHoc (MaMon, TenMon) Values (5, N'Lịch sử')
Insert MonHoc (MaMon, TenMon) Values (6, N'Địa lý')
Insert MonHoc (MaMon, TenMon) Values (7, N'Thể dục')
Insert MonHoc (MaMon, TenMon) Values (8, N'Tin học')

ALTER TABLE HocSinh
ADD FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon);
set identity_insert [dbo].[HocSinh] on
Insert HocSinh (MaHS, TenHS) Values (1, N'Uông Minh Khải')
Insert HocSinh (MaHS, TenHS) Values (2, N'Trần Duy Trí')

ALTER TABLE DiemSo
ADD FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon);
ALTER TABLE DiemSo
ADD FOREIGN KEY (MaHS) REFERENCES HocSinh(MaHS);

set identity_insert [dbo].[DiemSo] on
Alter table DiemSo
Alter column DiemCK float NULL;

Insert DiemSo (MaMon, MaHS, Diem15p, Diem1t, DiemGk, DiemCk) Values (1, 1, 0, 0, 0, 0);
Insert DiemSo (MaMon, MaHS, Diem15p, Diem1t, DiemGk, DiemCk) Values (1, 2, 0, 0, 0, 0);
Insert DiemSo (MaMon, MaHS, Diem15p, Diem1t, DiemGk, DiemCk) Values (2, 2, 0, 0, 0, 0);
