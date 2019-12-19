USE [master]
GO
/****** Object:  Database [dbMardomExamen]    Script Date: 19/12/2019 12:51:31 a. m. ******/
CREATE DATABASE [dbMardomExamen]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbExamenMardom', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\dbExamenMardom.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbExamenMardom_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\dbExamenMardom_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbMardomExamen] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbMardomExamen].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbMardomExamen] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbMardomExamen] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbMardomExamen] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbMardomExamen] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbMardomExamen] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbMardomExamen] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbMardomExamen] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbMardomExamen] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbMardomExamen] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbMardomExamen] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbMardomExamen] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbMardomExamen] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbMardomExamen] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbMardomExamen] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbMardomExamen] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbMardomExamen] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbMardomExamen] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbMardomExamen] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbMardomExamen] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbMardomExamen] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbMardomExamen] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbMardomExamen] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbMardomExamen] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbMardomExamen] SET  MULTI_USER 
GO
ALTER DATABASE [dbMardomExamen] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbMardomExamen] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbMardomExamen] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbMardomExamen] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbMardomExamen] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbMardomExamen] SET QUERY_STORE = OFF
GO
USE [dbMardomExamen]
GO
/****** Object:  Table [dbo].[Almacenes]    Script Date: 19/12/2019 12:51:31 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacenes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Almacen] [varchar](50) NOT NULL,
	[Ubicacion] [varchar](50) NOT NULL,
	[Capacidad] [int] NOT NULL,
 CONSTRAINT [PK_Almacenes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticuloAlmacen]    Script Date: 19/12/2019 12:51:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticuloAlmacen](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NULL,
	[Articulo_ID] [int] NOT NULL,
	[Almacen_ID] [int] NOT NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [PK_ArticuloAlmacen] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 19/12/2019 12:51:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Articulo] [varchar](50) NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[Precio] [decimal](7, 2) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vwArticuloAlmaces]    Script Date: 19/12/2019 12:51:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[vwArticuloAlmaces] as
Select 
	aa.ID,
	aa.Fecha,
	a.Articulo,
	al.Almacen,
	al.Capacidad,
	aa.Cantidad
From ArticuloAlmacen aa
	Left Join Articulos a On a.ID = aa.Articulo_ID
	Left Join Almacenes al ON al.ID = aa.Almacen_ID
GO
/****** Object:  View [dbo].[vwCantidadArticulosAlmacen]    Script Date: 19/12/2019 12:51:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[vwCantidadArticulosAlmacen] As
Select 
	aa.Almacen_ID,
	al.Almacen,
	SUM(aa.Cantidad) As Cantidad
From ArticuloAlmacen aa
	Left Join Articulos a On a.ID = aa.Articulo_ID
	Left Join Almacenes al ON al.ID = aa.Almacen_ID
Group BY 
	aa.Almacen_ID,
	al.Almacen
GO
SET IDENTITY_INSERT [dbo].[Almacenes] ON 
GO
INSERT [dbo].[Almacenes] ([ID], [Almacen], [Ubicacion], [Capacidad]) VALUES (1, N'Almacen Principal', N'Calle Principal', 5)
GO
INSERT [dbo].[Almacenes] ([ID], [Almacen], [Ubicacion], [Capacidad]) VALUES (2, N'Almacen 2', N'SanCarlos', 5)
GO
INSERT [dbo].[Almacenes] ([ID], [Almacen], [Ubicacion], [Capacidad]) VALUES (3, N'Almacen 3', N'Villa Juana', 6)
GO
INSERT [dbo].[Almacenes] ([ID], [Almacen], [Ubicacion], [Capacidad]) VALUES (4, N'Almacen 4', N'Villa Francisca', 4)
GO
INSERT [dbo].[Almacenes] ([ID], [Almacen], [Ubicacion], [Capacidad]) VALUES (5, N'Almacen 5', N'Lejos', 20)
GO
SET IDENTITY_INSERT [dbo].[Almacenes] OFF
GO
SET IDENTITY_INSERT [dbo].[ArticuloAlmacen] ON 
GO
INSERT [dbo].[ArticuloAlmacen] ([ID], [Fecha], [Articulo_ID], [Almacen_ID], [Cantidad]) VALUES (20, CAST(N'2019-12-19' AS Date), 1, 1, 5)
GO
INSERT [dbo].[ArticuloAlmacen] ([ID], [Fecha], [Articulo_ID], [Almacen_ID], [Cantidad]) VALUES (21, CAST(N'2019-12-19' AS Date), 2, 2, 4)
GO
INSERT [dbo].[ArticuloAlmacen] ([ID], [Fecha], [Articulo_ID], [Almacen_ID], [Cantidad]) VALUES (22, CAST(N'2019-12-19' AS Date), 3, 3, 6)
GO
SET IDENTITY_INSERT [dbo].[ArticuloAlmacen] OFF
GO
SET IDENTITY_INSERT [dbo].[Articulos] ON 
GO
INSERT [dbo].[Articulos] ([ID], [Articulo], [Codigo], [Precio], [Activo]) VALUES (1, N'Monitor 17 pulgadas-9', N'45241', CAST(2500.00 AS Decimal(7, 2)), 1)
GO
INSERT [dbo].[Articulos] ([ID], [Articulo], [Codigo], [Precio], [Activo]) VALUES (2, N'Mouse', N'2421212', CAST(4555.00 AS Decimal(7, 2)), 1)
GO
INSERT [dbo].[Articulos] ([ID], [Articulo], [Codigo], [Precio], [Activo]) VALUES (3, N'Monitor 21 pulgadas', N'333', CAST(3333.00 AS Decimal(7, 2)), 1)
GO
INSERT [dbo].[Articulos] ([ID], [Articulo], [Codigo], [Precio], [Activo]) VALUES (4, N'Bocina', N'4785', CAST(452.00 AS Decimal(7, 2)), 1)
GO
INSERT [dbo].[Articulos] ([ID], [Articulo], [Codigo], [Precio], [Activo]) VALUES (5, N'USB', N'8963', CAST(500.00 AS Decimal(7, 2)), 1)
GO
INSERT [dbo].[Articulos] ([ID], [Articulo], [Codigo], [Precio], [Activo]) VALUES (6, N'Teclado', N'852', CAST(1422.00 AS Decimal(7, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[Articulos] OFF
GO
ALTER TABLE [dbo].[ArticuloAlmacen]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloAlmacen_Almacenes] FOREIGN KEY([Almacen_ID])
REFERENCES [dbo].[Almacenes] ([ID])
GO
ALTER TABLE [dbo].[ArticuloAlmacen] CHECK CONSTRAINT [FK_ArticuloAlmacen_Almacenes]
GO
ALTER TABLE [dbo].[ArticuloAlmacen]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloAlmacen_Articulos] FOREIGN KEY([Articulo_ID])
REFERENCES [dbo].[Articulos] ([ID])
GO
ALTER TABLE [dbo].[ArticuloAlmacen] CHECK CONSTRAINT [FK_ArticuloAlmacen_Articulos]
GO
USE [master]
GO
ALTER DATABASE [dbMardomExamen] SET  READ_WRITE 
GO
