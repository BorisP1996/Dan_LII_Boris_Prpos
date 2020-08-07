--Creating database only if database is not created yet
IF DB_ID('Zadatak_52') IS NULL
CREATE DATABASE Zadatak_52
GO
USE Zadatak_52;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblOrder')
drop table tblOrder;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblUser')
drop table tblUser;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblCakeList')
drop table tblCakeList;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblCake')
drop table tblCake;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'vwOrder')
drop view vwOrder;

create table tblUser (
UserID int identity(1,1) primary key,
Fullname nvarchar (50) not null ,
Adress nvarchar (50) not null,
Phone nvarchar (30) unique not null ,
NumberOfOrders int not null,
Username nvarchar(50) unique not null,
Pasword nvarchar (50) unique not null
)

create table tblOrder(
CakeID int identity(1,1) primary key,
TotalPrice float not null ,
OrderDate date not null,
NumberOfCakes int  not null,
UserID int not null,
CakeListID int not null
)

create table tblCakeList(
CakeListID int identity(1,1) primary key,
LjubavnoGnezdo int,
Lincer int,
Cheese int,
Dobos int,
Bomba int,
Kinder int
)

create table tblCake(
CakeID int identity(1,1) primary key,
CakeName nvarchar (20),
Price float,
Grown bit,
Kids bit
)


Alter table tblOrder 
add foreign key (UserID) references tblUser(UserID)

Alter table tblOrder 
add foreign key (CakeListID) references tblCakeList(CakeListID)

Insert into tblCake values ('Ljubavno Gnezdo',1000.00,1,0),('Lincer',2000,1,0),('Cheese cake',1200,1,0),('Dobos',2500,0,1),('Bomba',800,0,1),('Kinder',1100,0,1)

GO
CREATE VIEW vwOrder AS
	SELECT	tblOrder.*, 
			tblCakeList.Bomba,tblCakeList.Cheese,tblCakeList.Dobos,tblCakeList.Kinder,tblCakeList.Lincer,tblCakeList.LjubavnoGnezdo
	FROM	tblOrder, tblCakeList 
	WHERE	tblOrder.CakeListID = tblCakeList.CakeListID






