USE [master]
GO
/****** Object:  Database [Test]    Script Date: 1/15/2023 6:30:14 PM ******/
CREATE DATABASE [Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Test] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Test] SET  MULTI_USER 
GO
ALTER DATABASE [Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Test] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Test] SET QUERY_STORE = OFF
GO
USE [Test]
GO
/****** Object:  Table [dbo].[TipoProducto]    Script Date: 1/15/2023 6:30:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProducto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 1/15/2023 6:30:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idTipoProducto] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[precio] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 1/15/2023 6:30:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_StockProducto]    Script Date: 1/15/2023 6:30:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_StockProducto] as
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
GO
/****** Object:  Table [dbo].[Rangos]    Script Date: 1/15/2023 6:30:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rangos](
	[idRango] [int] NOT NULL,
	[descripcion] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRango] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 1/15/2023 6:30:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nro_legajo] [varchar](10) NOT NULL,
	[nombre] [varchar](15) NOT NULL,
	[apellido] [varchar](15) NOT NULL,
	[email] [varchar](60) NULL,
	[username] [varchar](15) NOT NULL,
	[pass] [varchar](50) NOT NULL,
	[isBlocked] [bit] NULL,
	[idRango] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((0)) FOR [isBlocked]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([idTipoProducto])
REFERENCES [dbo].[TipoProducto] ([id])
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([id])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([idRango])
REFERENCES [dbo].[Rangos] ([idRango])
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarProducto]    Script Date: 1/15/2023 6:30:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarProducto]  @nombre varchar(50)
AS
BEGIN
DELETE FROM Stock WHERE idProducto = (SELECT id FROM PRODUCTO WHERE nombre = @nombre)
DELETE FROM Producto WHERE  id = (SELECT id FROM PRODUCTO WHERE nombre = @nombre)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarUsuario]    Script Date: 1/15/2023 6:30:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarUsuario]  @username varchar(15)
AS
BEGIN
DELETE FROM Usuarios WHERE  username = @username
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarProducto]    Script Date: 1/15/2023 6:30:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarProducto] @idTipoProducto int,@nombre varchar(50),@precio int, @cantidad int
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
/****** Object:  StoredProcedure [dbo].[sp_InsertarUsuario]    Script Date: 1/15/2023 6:30:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarUsuario] @nrolegajo varchar(10) ,@nombre varchar(15), @apellido varchar(15),@email varchar(60), @username varchar(15), @pass varchar(50), @isBlocked bit, @idRango int
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
/****** Object:  StoredProcedure [dbo].[sp_ModificarProducto]    Script Date: 1/15/2023 6:30:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ModificarProducto] @idSelected int, @idTipoProducto int,@nombre varchar(50),@precio int, @cantidad int
AS
BEGIN
UPDATE Producto SET idTipoProducto = @idTipoProducto,nombre = @nombre,precio = @precio WHERE id = @idSelected
UPDATE Stock SET cantidad = @cantidad WHERE idProducto = (SELECT id FROM Producto WHERE nombre = @nombre)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarUsuario]    Script Date: 1/15/2023 6:30:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ModificarUsuario] @idSelected int, @nrolegajo varchar(10) ,@nombre varchar(15), @apellido varchar(15),@email varchar(60), @username varchar(15), @pass varchar(50), @isBlocked bit, @idRango int
AS
BEGIN
UPDATE Usuarios SET nro_legajo = @nrolegajo, nombre = @nombre, apellido = @apellido, email = @email, username = @username, pass = @pass, isBlocked = @isBlocked, idRango = @idRango WHERE id = @idSelected
END
GO
USE [master]
GO
ALTER DATABASE [Test] SET  READ_WRITE 
GO
