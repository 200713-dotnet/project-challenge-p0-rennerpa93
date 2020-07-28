use master;
go

drop database PizzaBoxDb;
go

-- creates
create database PizzaBoxDb;
go

use PizzaBoxDb;
go

create schema Pizza;
go

create schema [Order];
GO

create schema [User];
go

create schema Store;
go

-- Create Tables

create table Pizza.Pizza
(
  PizzaId int not null identity(1,1) primary key,
  CrustId int null,
  SizeId int null,
  OrderId int null,
  [Name] nvarchar(255) not null
);

--drop table Pizza.Pizza;

create table Pizza.Crust
(
  CrustId int not null identity(1,1) primary key,
  [Type] nvarchar(255) not null,
  Price decimal not null
);

create table Pizza.Size
(
  SizeId int not null identity(1,1) primary key,
  [Name] nvarchar(255) not null,
  Price decimal not null
);

create table Pizza.Topping
(
  ToppingId int not null identity(1,1) primary key,
  [Name] nvarchar(255) not null,
  Price decimal not null
);

create table Pizza.PizzaTopping
(
  PizzaToppingId int not null identity(1,1) primary key,
  PizzaId int not null,
  ToppingId int not null,
);
go

create table [Order].[Order]
(
  OrderId int not null identity(1,1) primary key,
  [Status] nvarchar(255) not null,
  UserId int null,
  StoreId int null,
  DateCreated DATETIME2(0) not null,
);
go

create table [User].[User]
(
  UserId int not null identity(1,1) primary key,
  Email nvarchar(255) not null,
  LastOrdered DATETIME2(0) null,
  CurrentStore nvarchar(255) null,
);

create table Store.Store
(
  StoreId int not null identity(1,1) primary key,
  [Location] nvarchar(255) not null,
);
go

-- Alters

alter table Pizza.Pizza
  add constraint FK_CrustId foreign key (CrustId) references Pizza.Crust(CrustId)

alter table Pizza.Pizza
  add constraint FK_SizeId foreign key (SizeId) references Pizza.Size(SizeId)

alter table Pizza.Pizza
  add constraint FK_OrderId foreign key (OrderId) references [Order].[Order](OrderId)

alter table Pizza.PizzaTopping
  add constraint FK_PizzaTopping_PizzaId foreign key (PizzaId) references Pizza.Pizza(PizzaId)

alter table Pizza.PizzaTopping
  add constraint FK_PizzaTopping_ToppingId foreign key (ToppingId) references Pizza.Topping(ToppingId)

alter table [Order].[Order]
  add constraint FK_UserId foreign key (UserId) references [User].[User](UserId)

alter table [Order].[Order]
  add constraint FK_StoreId foreign key (StoreId) references Store.Store(StoreId)

go
