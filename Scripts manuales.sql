--CREACION DE TABLAS
CREATE TABLE TipoProducto (
	id int identity(1,1),
	descripcion varchar(20) not null,
	primary key (id)
)

GO
CREATE TABLE Producto (
	id int identity(1,1),
	idTipoProducto int not null,
	nombre varchar(50) not null,
	precio int not null,
	primary key(id),
	foreign key (idTipoProducto) references TipoProducto(id)
)

GO
CREATE TABLE Stock (
	id int identity(1,1),
	idProducto int not null,
	cantidad int not null,
	primary key(id),
	foreign key (idProducto) references Producto(id)
)

--CREACION DE VISTA
GO
CREATE VIEW vw_StockProducto as
SELECT 
	P.nombre as 'Nombre',
	P.precio as 'Precio',
	TP.descripcion as 'Categoría',
	S.cantidad as 'Cantidad'
FROM Producto P
INNER JOIN TipoProducto TP
ON P.idTipoProducto = TP.id
INNER JOIN Stock S
ON P.id = S.idProducto

--CREACION DE SP
GO
CREATE PROCEDURE sp_InsertarProducto @idTipoProducto int,@nombre varchar(50),@precio int, @cantidad int
AS
if (SELECT count(*) FROM Producto WHERE nombre = @nombre) = 0
BEGIN
INSERT INTO Producto values(@idTipoProducto,@nombre,@precio)
INSERT INTO Stock values((SELECT id FROM Producto WHERE nombre = @nombre),@cantidad)
END
ELSE
BEGIN
PRINT 'El producto ya se encuentra ingresado, no se cargaran los datos.'
END
GO
CREATE PROCEDURE sp_ModificarProducto @idSelected int, @idTipoProducto int,@nombre varchar(50),@precio int, @cantidad int
AS
BEGIN
UPDATE Producto SET idTipoProducto = @idTipoProducto,nombre = @nombre,precio = @precio WHERE id = @idSelected
UPDATE Stock SET cantidad = @cantidad WHERE idProducto = (SELECT id FROM Producto WHERE nombre = @nombre)
END

GO
CREATE PROCEDURE sp_EliminarProducto  @idSelected int
AS
BEGIN
DELETE FROM Producto WHERE  id = @idSelected
END

--CREACION DE INSERTS TipoProductos

INSERT INTO TipoProducto values('Carne')
INSERT INTO TipoProducto values('Vegetales')
INSERT INTO TipoProducto values('Lacteos')
INSERT INTO TipoProducto values('Frutas')
INSERT INTO TipoProducto values('Snacks')
INSERT INTO TipoProducto values('Bebida')
INSERT INTO TipoProducto values('Otros')

--Ingreso productos con el SP para modificar ambas tablas (Productos y Stock)
EXEC sp_InsertarProducto 2, 'Tomate',100, 4
EXEC sp_InsertarProducto 2, 'Lechuga',70, 7
EXEC sp_InsertarProducto 3, 'Choclo',20, 2
EXEC sp_InsertarProducto 2, 'Papa',10, 9

EXEC sp_InsertarProducto 3, 'Queso cremoso',100,20
EXEC sp_InsertarProducto 3, 'Yoghurt',200, 10
EXEC sp_InsertarProducto 3, 'Queso crema',300, 12
EXEC sp_InsertarProducto 3, 'Leche',50, 15

EXEC sp_InsertarProducto 4, 'Manzana',50, 20
EXEC sp_InsertarProducto 4, 'Pera',50, 30
EXEC sp_InsertarProducto 4, 'Durazno',50, 12

--ADICIONALES
GO
CREATE TABLE Rangos (
	idRango int not null,
	descripcion varchar(20) not null,
	primary key (idRango)
)
GO
CREATE TABLE Usuarios (
	id int identity(1,1),
	nro_legajo varchar(10) not null,
	nombre varchar(15) not null,
	apellido varchar(15) not null,
	email varchar(60) null,
	username varchar(15) not null,
	pass varchar(50) not null,
	isBlocked bit default 0,
	idRango int not null,
	primary key (id),
	foreign key (idRango) references Rangos(idRango)
)

INSERT INTO Rangos VALUES (10,'Administrador')
INSERT INTO Rangos VALUES (20,'Empleado')
INSERT INTO Rangos VALUES (30,'Cliente')

GO
CREATE PROCEDURE sp_InsertarUsuario @nrolegajo varchar(10) ,@nombre varchar(15), @apellido varchar(15),@email varchar(60), @username varchar(15), @pass varchar(50), @isBlocked bit, @idRango int
AS
if (SELECT count(*) FROM Usuarios WHERE username = @username) = 0
BEGIN
INSERT INTO Usuarios values(@nrolegajo,@nombre,@apellido,@email,@username,@pass,@isBlocked, @idRango)
END
ELSE
BEGIN
PRINT 'El usuario ya se encuentra registrado, no se cargaran los datos.'
END

GO
CREATE PROCEDURE sp_ModificarUsuario @idSelected int, @nrolegajo varchar(10) ,@nombre varchar(15), @apellido varchar(15),@email varchar(60), @username varchar(15), @pass varchar(50), @isBlocked bit, @idRango int
AS
BEGIN
UPDATE Usuarios SET nro_legajo = @nrolegajo, nombre = @nombre, apellido = @apellido, email = @email, username = @username, pass = @pass, isBlocked = @isBlocked, idRango = @idRango WHERE id = @idSelected
END

GO
CREATE PROCEDURE sp_EliminarUsuario  @username int
AS
BEGIN
DELETE FROM Usuarios WHERE  username = @username
END