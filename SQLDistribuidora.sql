use master
go
create database Distribuidora
go
use Distribuidora
go
create table Publicaciones
(Cod_Pub char(5) not null,
Titulo varchar(40) not null,
Pre_Unit float not null,
Primary Key (Cod_Pub))
go

create proc USP_ObtenerCodigoPubs(@cod varchar(5) output)
as
	declare @n as int
	select @cod = max(cod_pub) from Publicaciones
	if @cod is null
		set @cod = 'P0001'
	else
	begin
		set @cod = RIGHT(@cod,4)
		set @n = cast(@cod as int) + 1
		set @cod = 'P' + right('0000' + cast(@n as varchar(4)),4)
	end 
	return
go
declare @cod varchar(5)
exec USP_ObtenerCodigoPubs @cod
create proc USP_IngresarPub(@cod char(5),@titulo varchar(40),@pre float)
as
	insert into Publicaciones values (@cod,@titulo,@pre)
go
insert into Publicaciones values ('P0001','Un Libro',20.00)
create table Descuento
(Tipo_Desc varchar(20) not null,
Can_Min int not null,
Can_Max int not null,
Porcentaje float not null,
Primary Key (Tipo_Desc) 
)
go

create table Cabe_Ventas(
Cabe_Venta char(5) not null,
Fec_Ven date not null,
Importe float not null,
Primary Key (Cabe_Venta)
)
go
CREATE proc Usp_ObtenerCabe_Ventas(@cod varchar(5) output)
as
	declare @n int
	select @cod = max(Cabe_Venta) from Cabe_Ventas
	if @cod is null
		set	@cod = 'C0001'
	else
		begin
			set @cod = right(@cod,4)
			set @n = cast(@cod as int) +1
			set @cod = 'C' + RIGHT('0000' + CAST(@n as varchar(4)),4)			
		end	
	return			
go					
create proc USP_IngresarCabe_Ventas(@cod char(5),@fecha date, @total float)
as
	insert into Cabe_Ventas values (@cod,@fecha,@total)
go

create table Ventas(
Cabe_Venta char(5) not null,
Num_Ven char(5) not null,
Cod_Pub char(5) not null,
Tipo_Desc varchar(20) not null,
Cantidad int not null,
Importe float not null,
Primary Key(Num_Ven),
Foreign key (Cabe_Venta) references Cabe_Ventas(Cabe_Venta),
Foreign key (Cod_Pub) references Publicaciones(Cod_Pub),
Foreign key (Tipo_Desc) references Descuento(Tipo_Desc)
)
go
create proc USP_IngresarDetaVenta(@cab char(5),@cod_Pro char(5),@Tipo varchar(20),@can int,@imp float)
as
	declare @n int
	declare @cod varchar(5)
	select @cod = MAX(Cabe_Venta) from Ventas
	if @cod is null
		set @cod = 'V0001'
	else
	begin
		set @cod = RIGHT(@cod,4)
		set @n = CAST(@cod as int) + 1
		set @cod = 'V' + RIGHT('0000' + CAST(@n as varchar(4)),4)
	end
	insert into Ventas values (@cab,@cod,@cod_Pro,@Tipo,@can,@imp)
go	

alter proc USP_AnularVenta(@cab char(5))
as
	delete from Ventas where Cabe_Venta = @cab
GO
CREATE PROC USP_AnularCabeVenta(@cab char(5))
as
	delete from Cabe_Ventas where Cabe_Venta = @cab
go
	



select * From ventas
insert into descuento values ('No Descuento',0,5,0)
insert into descuento values ('Descuento 1',6,10,10.00)
insert into descuento values ('Descuento 2',11,15,20.00)
insert into descuento values ('Descuento 3',16,20,30.00)
insert into descuento values ('Descuento 4',20,100,40.00)

insert into Ventas values ('V0001','20181119','P0001','No Descuento',3,60)


SELECT cod_pub,Cantidad  FROM Ventas 
go
create proc ContadorVentas(@cod char(5))
as
	begin
	declare @numpubs as int
	declare @x as int =0
	select @numpubs = count(*) from Publicaciones
	while @x < @numpubs
		declare @acum as int
		declare @codpub as char(5)
		select p.Titulo,sum(Cantidad) as acumulado from ventas v,Publicaciones p,Cabe_Ventas c where v.Cod_Pub =p.Cod_Pub and v.Cabe_Venta=c.Cabe_Venta and c.Fec_Ven between   group by  p.Titulo having count(*) > 0 
		select * from Ventas


go

