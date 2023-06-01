
create database LIBRARIUMDB

USE LIBRARIUMDB

CREATE TABLE Clientes (
  Cedula VARCHAR(20) PRIMARY KEY,
  Nombres VARCHAR(100),
  Telefono VARCHAR(10),
  Direccion VARCHAR(100)
);

CREATE TABLE Ventas (
  CodigoVenta VARCHAR(10) PRIMARY KEY,
  CodigoProducto VARCHAR(10),
  FechaVenta DATE,
  PuntoVenta VARCHAR(50),
  CedulaCliente VARCHAR(20),
  Total DECIMAL(10, 2),
  FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula)
);

----------------------------------------------------------------------
----------------------- CLIENTES--------------------------------------
--procedimiento para listar los contactos
create procedure sp_listar_cliente
as 
begin
	select * from Clientes
end
------- Test ----------
EXEC sp_listar_cliente;

--Obtener contacto por id
create procedure sp_obtener_cliente(
@Cedula VARCHAR(20)
)
as 
begin
	select * from Clientes where Cedula = @Cedula
end

--------- TEST ---------------------
EXEC sp_obtener_cliente @Cedula='0001';


--procedimiento para guardar datos
create procedure sp_Guardar_cliente(
@Cedula varchar(20),
@Nombres varchar(100),
@Telefono varchar(10),
@Direccion varchar(100)
)
as
begin
	insert into Clientes(Cedula, Nombres, Telefono, Direccion) values (@Cedula, @Nombres, @Telefono, @Direccion)
end
--------- TEST ---------------------
EXEC sp_Guardar_cliente @Cedula='0001', @Nombres='Reyes Dario Castro', @Telefono='3156802266', @Direccion='diagonal 87b # 22-18';

---DROP PROCEDURE IF EXISTS sp_Guardar_cliente;



----------------------------------------------------------------------
----------------------- Ventas--------------------------------------
--procedimiento para listar los contactos
CREATE PROCEDURE sp_Listar_ventas
AS
BEGIN
    SELECT V.CodigoVenta, V.CodigoProducto, V.FechaVenta, V.PuntoVenta, C.Cedula, C.Nombres, C.Telefono, C.Direccion, V.Total
    FROM Ventas V
    INNER JOIN Clientes C ON V.CedulaCliente = C.Cedula;
END;
--------- Test ------
EXEC sp_listar_Ventas;



--Obtener contacto por id
create procedure sp_obtener_ventas(
@CodigoVenta varchar(10)
)
as 
begin
    SELECT V.CodigoVenta, V.CodigoProducto, V.FechaVenta, V.PuntoVenta, C.Cedula, C.Nombres, C.Telefono, C.Direccion, V.Total
    FROM Ventas V
    INNER JOIN Clientes C ON V.CedulaCliente = C.Cedula
	    WHERE V.CodigoVenta = @CodigoVenta;
end;
---------- test -------
EXEC sp_obtener_ventas @CodigoVenta='00001';


--DROP PROCEDURE IF EXISTS sp_obtener_ventas;


--procedimiento para guardar datos
CREATE PROCEDURE sp_Guardar_ventas (
    @CodigoVenta VARCHAR(10),
    @CodigoProducto VARCHAR(10),
    @FechaVenta DATE,
    @PuntoVenta VARCHAR(50),
    @CedulaCliente VARCHAR(20),
    @Total DECIMAL(10, 2)
)
AS
BEGIN
    INSERT INTO Ventas (CodigoVenta, CodigoProducto, FechaVenta, PuntoVenta, CedulaCliente, Total)
    VALUES (@CodigoVenta, @CodigoProducto, @FechaVenta, @PuntoVenta, @CedulaCliente, @Total);
END;
--------- Test ------
EXEC sp_Guardar_ventas @CodigoVenta='00001', @CodigoProducto='102010', @FechaVenta='2023-05-31', @PuntoVenta='Punto de Venta 1', @CedulaCliente='0001', @Total=150.50;




--procedimiento para editar datos
create procedure sp_Editar_ventas(
    @CodigoVenta VARCHAR(10),
    @CodigoProducto VARCHAR(10),
    @FechaVenta DATE,
    @PuntoVenta VARCHAR(50),
    @CedulaCliente VARCHAR(20),
    @Total DECIMAL(10, 2)
)
as
begin
	update Ventas set CodigoProducto = @CodigoProducto, FechaVenta = @FechaVenta, PuntoVenta = @PuntoVenta, CedulaCliente = @CedulaCliente, Total = @Total  where CodigoVenta = @CodigoVenta
end;
--------- Test ------
exec sp_Editar_ventas @CodigoVenta='00001', @CodigoProducto='9999', @FechaVenta='2023-05-30', @PuntoVenta='Punto de Venta 2', @CedulaCliente='0002', @Total=250.50;




--Procedimiento para eliminar por su IdContacto
create procedure sp_Eliminar_ventas(
    @CodigoVenta VARCHAR(10)
)
as
begin
	delete from Ventas where CodigoVenta = @CodigoVenta
end
--------- Test ------
exec sp_Eliminar_ventas @CodigoVenta = '00003';