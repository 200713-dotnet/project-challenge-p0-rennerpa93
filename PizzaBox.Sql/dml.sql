use PizzaBoxDb;
go

-- Store Setup

insert into Store.Store(Location)
values('Michigan')

select * from Store.Store

insert into Store.Store(Location)
values('Texas')

select * from [Order].[Order];
select * from [User].[User];

insert into [User].[User](Email, LastOrdered, CurrentStore)
values('rawr', convert(datetime,getdate(),103), 1)

insert into [Order].[Order](Status, UserId, StoreId, DateCreated)
values('Completed', 1, 1, convert(datetime,getdate(),103));

insert into Pizza.Crust([Type], Price)
values('Normal Crust', 0);

insert into Pizza.Size([Name], Price)
values('Small', 0);

insert into Pizza.Topping([Name], Price)
values('Cheese', 0.25);

select * from Pizza.Crust;
select * from Pizza.Size;
select * from Pizza.Topping;

insert into Pizza.Pizza(CrustId,SizeId,OrderId,Name)
values(1,1,1,'Cheese Pizza');

select * from Pizza.Pizza;

insert into Pizza.PizzaTopping(PizzaId, ToppingId)
values(1,1);