use master;
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
  PizzaId int not null,
  CrustId int null,
  SizeId int null,
  OrderId int null,
  [Name] nvarchar(255) not null,
  DateModified DATETIME2(0) not null,
  Active bit not null default 1
);

--drop table Pizza.Pizza;

create table Pizza.Crust
(
  CrustId int not null,
  [Type] nvarchar(255) not null,
  Price decimal not null,
  DateModified DATETIME2(0) not null,
  Active bit not null default 1
);

create table Pizza.Size
(
  SizeId int not null,
  [Name] nvarchar(255) not null,
  Price decimal not null,
  DateModified DATETIME2(0) not null,
  Active bit not null default 1
);

create table Pizza.Topping
(
  ToppingId int not null,
  [Name] nvarchar(255) not null,
  Price decimal not null,
  DateModified DATETIME2(0) not null,
  Active bit not null
);

create table Pizza.PizzaTopping
(
  PizzaToppingId int not null,
  PizzaId int not null,
  ToppingId int not null,
  Active bit not null
);
go

create table [Order].[Order]
(
  OrderId int not null,
  [Status] nvarchar(255) not null,
  UserId int null,
  StoreId int null,
  DateCreated DATETIME2(0) not null,
  Active bit not null default 1
);
go

create table [User].[User]
(
  UserId int not null,
  Email nvarchar(255) not null,
  LastOrdered DATETIME2(0) null,
  CurrentStore nvarchar(255) null,
  Active bit not null default 1
);

create table Store.Store
(
  StoreId int not null,
  [Location] nvarchar(255) not null,
  LastOrdered DATETIME2(0) null,
  CurrentStore nvarchar(255) null,
  Active bit not null default 1
);
go

-- Alters

alter table Pizza.size
  add constraint PK_Size_SizeId primary key (SizeId)

alter table Pizza.Topping
  add constraint PK_ToppingId primary key (ToppingId)

alter table Pizza.Crust
  add constraint PK_CrustId primary key (CrustId)

alter table Pizza.Pizza
  add constraint PK_PizzaId primary key (PizzaId)

alter table Pizza.Pizza
  add constraint FK_CrustId foreign key (CrustId) references Pizza.Crust(CrustId)

alter table Pizza.Pizza
  add constraint FK_SizeId foreign key (SizeId) references Pizza.Size(SizeId)

alter table Pizza.Pizza
  add constraint FK_OrderId foreign key (OrderId) references [Order].[Order](OrderId)

alter table Pizza.PizzaTopping
  add constraint PK_PizzaToppingId primary key (PizzaToppingId)

alter table Pizza.PizzaTopping
  add constraint FK_PizzaTopping_PizzaId foreign key (PizzaId) references Pizza.Pizza(PizzaId)

alter table Pizza.PizzaTopping
  add constraint FK_PizzaTopping_ToppingId foreign key (ToppingId) references Pizza.Topping(ToppingId)

alter table [User].[User]
  add constraint PK_UserId primary key (UserId)

alter table [Order].[Order]
  add constraint PK_OrderId primary key (OrderId)

alter table [Order].[Order]
  add constraint FK_UserId foreign key (UserId) references [User].[User](UserId)

alter table [Order].[Order]
  add constraint FK_StoreId foreign key (StoreId) references Store.Store(StoreId)

go
