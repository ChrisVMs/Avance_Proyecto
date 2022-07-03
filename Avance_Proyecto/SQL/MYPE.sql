create database MYPE
USE MYPE


CREATE TABLE CONTACTO(
IdContacto int identity primary key,
Nombre varchar(50),
Telefono varchar(50),
Correo varchar(50)
)

CREATE TABLE PRODUCTOS(
IdProducto int identity primary key,
Nombre varchar(50),
Descripcion varchar(50),
Stock int
)


-----------------SP_CONTACTO----------------------------

create procedure sp_Listar
as
begin
	select * from CONTACTO
end

create procedure sp_Obtener(
@IdContacto int
)
as
begin
	select * from CONTACTO where  IdContacto = @IdContacto
end


create procedure sp_Guardar(
@Nombre varchar(100),
@Telefono varchar(100),
@Correo varchar(100) 
)
as
begin
	insert into CONTACTO(Nombre,Telefono,Correo) values (@Nombre,@Telefono,@Correo)
end


create procedure sp_Editar(
@IdContacto int,
@Nombre varchar(100),
@Telefono varchar(100),
@Correo varchar(100) 
)
as
begin
	update CONTACTO set Nombre = @Nombre, Telefono = @Telefono , Correo = @Correo where IdContacto = @IdContacto
end


create procedure sp_Eliminar(
@IdContacto int
)
as
begin
	delete from CONTACTO where IdContacto = @IdContacto
end


------------------SP_PRODUCTOS--------------------------
create procedure sp_Listar_Productos
as
begin
	select * from PRODUCTOS
end

create procedure sp_Obtener_Productos(
@IdProducto int
)
as
begin
	select * from PRODUCTOS where  IdProducto = @IdProducto
end


create procedure sp_Guardar_Productos(
@Nombre varchar(100),
@Descripcion varchar(100),
@Stock int
)
as
begin
	insert into PRODUCTOS(Nombre,Descripcion,stock) values (@Nombre,@Descripcion,@stock)
end


create procedure sp_Editar_Productos(
@IdProducto int,
@Nombre varchar(100),
@Descripcion varchar(100),
@Stock varchar(100) 
)
as
begin
	update PRODUCTOS set Nombre = @Nombre, Descripcion = @Descripcion , Stock = @Stock where IdProducto = @IdProducto
end

create procedure sp_Eliminar_Productos(
@IdProducto int
)
as
begin
	delete from PRODUCTOS where IdProducto = @IdProducto
end

select * from CONTACTO

create table usuario(
usuario varchar(25),
pass varchar(15)
)

create procedure sp_Guardar_Usuarios(
@Usuario varchar(25),
@Pass varchar(15)
)
as
begin
	insert into usuario(usuario, pass) values (@Usuario,@Pass)
end