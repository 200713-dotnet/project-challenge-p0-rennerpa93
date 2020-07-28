use PizzaBoxDb;
go

-- Store Setup

insert into Store.Store(Location)
values('Michigan')
insert into Store.Store(Location)
values('Texas')

select * from Store.Store

select * from [Order].[Order];
select * from [User].[User];

--insert into [User].[User](Email, LastOrdered, CurrentStore)
--values('rawr', convert(datetime,getdate(),103), 1)

--insert into [Order].[Order](Status, UserId, StoreId, DateCreated)
--values('Completed', 1, 1, convert(datetime,getdate(),103));

-- Insert Crusts

insert into Pizza.Crust([Type], Price)
values('Normal Crust', 0);
insert into Pizza.Crust([Type], Price)
values('Cheese-Stuffed Crust', 1.00);
insert into Pizza.Crust([Type], Price)
values('Parmesan Garlic Crust', 1.00);
insert into Pizza.Crust([Type], Price)
values('Parmesan Garlic Cheese-Stuffed Crust', 2.00);

-- Insert Sizes

insert into Pizza.Size([Name], Price)
values('Small', 5);
insert into Pizza.Size([Name], Price)
values('Medium', 7.00);
insert into Pizza.Size([Name], Price)
values('Large', 9.00);
insert into Pizza.Size([Name], Price)
values('Extra-Large', 11.00);

-- Insert Toppings

insert into Pizza.Topping([Name], Price)
values('Cheese', 0.25);
insert into Pizza.Topping([Name], Price)
values('Pepperoni', 0.25);
insert into Pizza.Topping([Name], Price)
values('Green Peppers', 0.25);
insert into Pizza.Topping([Name], Price)
values('Onions', 0.25);
insert into Pizza.Topping([Name], Price)
values('Ham', 0.50);
insert into Pizza.Topping([Name], Price)
values('Sausage', 0.50);
insert into Pizza.Topping([Name], Price)
values('Pineapple', 0.50);


--insert into Pizza.Pizza(CrustId,SizeId,OrderId,Name)
--values(1,1,1,'Cheese Pizza');

--insert into Pizza.PizzaTopping(PizzaId, ToppingId)
--values(1,1);


use PizzaBoxDb;
go

select * from Pizza.Crust;
select * from Pizza.Size;
select * from Pizza.Topping;
select * from Pizza.Pizza;
select * from Pizza.PizzaTopping;