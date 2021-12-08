USE CACHLY

go
if exists (select 1
            from  sysobjects
           where  id = object_id('CN_TC')
            and   type = 'U')
	begin
		alter table CN_TC
			drop constraint FK_MACONGNHAN;
		
		alter table CN_TC
			drop constraint FK_MATRIEUCHUNG;

		drop table CN_TC
	end;
if exists (select 1
            from  sysobjects
           where  id = object_id('CONGNHAN')
            and   type = 'U')
	begin		
		alter table CONGNHAN
			drop constraint FK_MADIEMCACHLY;
		drop table CONGNHAN
	end;
if exists (select 1
            from  sysobjects
           where  id = object_id('DIEMCACHLY')
            and   type = 'U')
   drop table DIEMCACHLY

if exists (select 1
            from  sysobjects
           where  id = object_id('TRIEUCHUNG')
            and   type = 'U')
   drop table TRIEUCHUNG

go
Create table DIEMCACHLY(
	MaDiemCachLy char(4),
	TenDiemCachLy nvarchar(256),
	DiaChi nvarchar(256),
	Constraint PK_DIEMCACHLY primary key (MaDiemCachLy)
)

create table CONGNHAN(
	MaCongNhan char(4),
	TenCongNhan nvarchar(256),
	GioiTinh bit,
	NamSinh int,
	NuocVe nvarchar(256), 
	MaDiemCachLy char(4),
	Constraint PK_CONGNHAN primary key (MaCongNhan)
)
create table TRIEUCHUNG(
	MaTrieuChung char(4), 
	TenTrieuChung nvarchar(256),
	Constraint PK_TRIEUCHUNG primary key (MaTrieuChung)
)
create table CN_TC(
	MaCongNhan char(4),
	MaTrieuChung char(4)
	Constraint PK_CN_TC primary key (MaCongNhan, MaTrieuChung)
)
go
alter table CN_TC
	add constraint FK_MACONGNHAN foreign key (MaCongNhan)
		references CONGNHAN(MaCongNhan)
alter table CN_TC
	add constraint FK_MATRIEUCHUNG foreign key (MaTrieuChung)
		references TRIEUCHUNG(MaTrieuChung)
alter table CONGNHAN
	add constraint FK_MADIEMCACHLY foreign key (MaDiemCachLy)
		references DIEMCACHLY(MaDiemCachLy)
