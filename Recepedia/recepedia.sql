USE [master]
GO
/****** Object:  Database [RecepediaDB]    Script Date: 18/12/2023 18:50:16 ******/
CREATE DATABASE [RecepediaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RecepediaDB', FILENAME = N'D:\SQL Server\Data\RecepediaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RecepediaDB_log', FILENAME = N'D:\SQL Server\Data\RecepediaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RecepediaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RecepediaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RecepediaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RecepediaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RecepediaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RecepediaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [RecepediaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RecepediaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RecepediaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RecepediaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RecepediaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RecepediaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RecepediaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RecepediaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RecepediaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RecepediaDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RecepediaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RecepediaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RecepediaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RecepediaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RecepediaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RecepediaDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [RecepediaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RecepediaDB] SET RECOVERY FULL 
GO
ALTER DATABASE [RecepediaDB] SET  MULTI_USER 
GO
ALTER DATABASE [RecepediaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RecepediaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RecepediaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RecepediaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RecepediaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RecepediaDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [RecepediaDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO)
GO
USE [RecepediaDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 18/12/2023 18:50:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 18/12/2023 18:50:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nom_Categoria] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dificultad]    Script Date: 18/12/2023 18:50:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dificultad](
	[IDDificultad] [int] IDENTITY(1,1) NOT NULL,
	[NombreDificultad] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Dificultad] PRIMARY KEY CLUSTERED 
(
	[IDDificultad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favoritos]    Script Date: 18/12/2023 18:50:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favoritos](
	[IdFavorito] [int] IDENTITY(1,1) NOT NULL,
	[IdReceta] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Favoritos] PRIMARY KEY CLUSTERED 
(
	[IdFavorito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngPorRec]    Script Date: 18/12/2023 18:50:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngPorRec](
	[IdIngPorRec] [int] IDENTITY(1,1) NOT NULL,
	[IdReceta] [int] NOT NULL,
	[IdIngrediente] [int] NOT NULL,
	[Cantidad] [nvarchar](max) NOT NULL,
	[RecetaIDReceta] [int] NULL,
 CONSTRAINT [PK_IngPorRec] PRIMARY KEY CLUSTERED 
(
	[IdIngPorRec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingrediente]    Script Date: 18/12/2023 18:50:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingrediente](
	[IDIngrediente] [int] IDENTITY(1,1) NOT NULL,
	[NombreIngrediente] [nvarchar](max) NOT NULL,
	[Cantidad] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Ingrediente] PRIMARY KEY CLUSTERED 
(
	[IDIngrediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receta]    Script Date: 18/12/2023 18:50:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receta](
	[IDReceta] [int] IDENTITY(1,1) NOT NULL,
	[NombreReceta] [nvarchar](max) NOT NULL,
	[CategoriaIdCategoria] [int] NOT NULL,
	[Preparacion] [nvarchar](max) NOT NULL,
	[TiempoPreparacion] [int] NOT NULL,
	[CantidadPlatos] [real] NOT NULL,
	[DificultadIdDificultad] [int] NOT NULL,
	[Cant_Likes] [int] NOT NULL,
	[Autor] [int] NOT NULL,
	[UsuarioIDUsuario] [int] NULL,
 CONSTRAINT [PK_Receta] PRIMARY KEY CLUSTERED 
(
	[IDReceta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 18/12/2023 18:50:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Usuario] [nvarchar](max) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Mail] [nvarchar](max) NOT NULL,
	[Contraseña] [nvarchar](16) NOT NULL,
	[RepetirContraseña] [nvarchar](max) NOT NULL,
	[Admin] [bit] NOT NULL,
	[NombreFoto] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231102002120_Inicial', N'7.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231123021724_IngPorRec', N'7.0.13')
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([IdCategoria], [Nom_Categoria]) VALUES (1, N'Aves')
INSERT [dbo].[Categoria] ([IdCategoria], [Nom_Categoria]) VALUES (2, N'Bebidas')
INSERT [dbo].[Categoria] ([IdCategoria], [Nom_Categoria]) VALUES (3, N'Carnes')
INSERT [dbo].[Categoria] ([IdCategoria], [Nom_Categoria]) VALUES (4, N'Verduras')
INSERT [dbo].[Categoria] ([IdCategoria], [Nom_Categoria]) VALUES (5, N'Guisos y Sopas')
INSERT [dbo].[Categoria] ([IdCategoria], [Nom_Categoria]) VALUES (6, N'Pastas y Arroces')
INSERT [dbo].[Categoria] ([IdCategoria], [Nom_Categoria]) VALUES (7, N'Pastelería')
INSERT [dbo].[Categoria] ([IdCategoria], [Nom_Categoria]) VALUES (8, N'Pescados y Mariscos')
INSERT [dbo].[Categoria] ([IdCategoria], [Nom_Categoria]) VALUES (9, N'Pizzas')
INSERT [dbo].[Categoria] ([IdCategoria], [Nom_Categoria]) VALUES (10, N'Postres')
INSERT [dbo].[Categoria] ([IdCategoria], [Nom_Categoria]) VALUES (11, N'Panadería')
INSERT [dbo].[Categoria] ([IdCategoria], [Nom_Categoria]) VALUES (12, N'Salsas')
INSERT [dbo].[Categoria] ([IdCategoria], [Nom_Categoria]) VALUES (13, N'Huevos y Lácteos')
INSERT [dbo].[Categoria] ([IdCategoria], [Nom_Categoria]) VALUES (14, N'Otros')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
SET IDENTITY_INSERT [dbo].[Dificultad] ON 

INSERT [dbo].[Dificultad] ([IDDificultad], [NombreDificultad]) VALUES (1, N'Fácil')
INSERT [dbo].[Dificultad] ([IDDificultad], [NombreDificultad]) VALUES (2, N'Medio')
INSERT [dbo].[Dificultad] ([IDDificultad], [NombreDificultad]) VALUES (3, N'Difícil')
SET IDENTITY_INSERT [dbo].[Dificultad] OFF
SET IDENTITY_INSERT [dbo].[IngPorRec] ON 

INSERT [dbo].[IngPorRec] ([IdIngPorRec], [IdReceta], [IdIngrediente], [Cantidad], [RecetaIDReceta]) VALUES (1, 1, 1, N'2', 1)
INSERT [dbo].[IngPorRec] ([IdIngPorRec], [IdReceta], [IdIngrediente], [Cantidad], [RecetaIDReceta]) VALUES (2, 1, 2, N'200 gr', 1)
INSERT [dbo].[IngPorRec] ([IdIngPorRec], [IdReceta], [IdIngrediente], [Cantidad], [RecetaIDReceta]) VALUES (3, 1, 3, N'300 gr', 1)
INSERT [dbo].[IngPorRec] ([IdIngPorRec], [IdReceta], [IdIngrediente], [Cantidad], [RecetaIDReceta]) VALUES (4, 1, 4, N'150 gr', 1)
INSERT [dbo].[IngPorRec] ([IdIngPorRec], [IdReceta], [IdIngrediente], [Cantidad], [RecetaIDReceta]) VALUES (5, 1, 5, N'4', 1)
INSERT [dbo].[IngPorRec] ([IdIngPorRec], [IdReceta], [IdIngrediente], [Cantidad], [RecetaIDReceta]) VALUES (6, 1, 6, N'100 gr', 1)
INSERT [dbo].[IngPorRec] ([IdIngPorRec], [IdReceta], [IdIngrediente], [Cantidad], [RecetaIDReceta]) VALUES (7, 1, 7, N'7', 1)
INSERT [dbo].[IngPorRec] ([IdIngPorRec], [IdReceta], [IdIngrediente], [Cantidad], [RecetaIDReceta]) VALUES (8, 1, 8, N'2 tazas', 1)
INSERT [dbo].[IngPorRec] ([IdIngPorRec], [IdReceta], [IdIngrediente], [Cantidad], [RecetaIDReceta]) VALUES (1002, 3007, 1002, N'200 gr', NULL)
SET IDENTITY_INSERT [dbo].[IngPorRec] OFF
SET IDENTITY_INSERT [dbo].[Ingrediente] ON 

INSERT [dbo].[Ingrediente] ([IDIngrediente], [NombreIngrediente], [Cantidad]) VALUES (1, N'Cebolla', N'2')
INSERT [dbo].[Ingrediente] ([IDIngrediente], [NombreIngrediente], [Cantidad]) VALUES (2, N'Leche', N'200gr')
INSERT [dbo].[Ingrediente] ([IDIngrediente], [NombreIngrediente], [Cantidad]) VALUES (3, N'Harina 000', N'300gr')
INSERT [dbo].[Ingrediente] ([IDIngrediente], [NombreIngrediente], [Cantidad]) VALUES (4, N'Manteca', N'150gr')
INSERT [dbo].[Ingrediente] ([IDIngrediente], [NombreIngrediente], [Cantidad]) VALUES (5, N'Huevo', N'4')
INSERT [dbo].[Ingrediente] ([IDIngrediente], [NombreIngrediente], [Cantidad]) VALUES (6, N'Chocolate', N'100gr')
INSERT [dbo].[Ingrediente] ([IDIngrediente], [NombreIngrediente], [Cantidad]) VALUES (7, N'Zanahoria', N'7')
INSERT [dbo].[Ingrediente] ([IDIngrediente], [NombreIngrediente], [Cantidad]) VALUES (8, N'Arroz', N'2 tazas')
INSERT [dbo].[Ingrediente] ([IDIngrediente], [NombreIngrediente], [Cantidad]) VALUES (1001, N'Papa', N'2 kg')
INSERT [dbo].[Ingrediente] ([IDIngrediente], [NombreIngrediente], [Cantidad]) VALUES (1002, N'Carne', N'200 gr')
SET IDENTITY_INSERT [dbo].[Ingrediente] OFF
SET IDENTITY_INSERT [dbo].[Receta] ON 

INSERT [dbo].[Receta] ([IDReceta], [NombreReceta], [CategoriaIdCategoria], [Preparacion], [TiempoPreparacion], [CantidadPlatos], [DificultadIdDificultad], [Cant_Likes], [Autor], [UsuarioIDUsuario]) VALUES (1, N'Soupe l''Oignon (Sopa de cebollas)', 5, N'1- Pelar, lavar y picar finamente las cebollas. Lubricar una olla con rocío vegetal y dorarlas
2- Agregar el caldo y el vino y proseguir la cocción durante 15''. Salar.
3- Disolver la maicena con la leche fría e incorporar a la sopa. Revolver hasta que hierva durante 3''.
4- Servir con queso rallado y pimienta. Decorar cada plato con una rebanada de pan tostado cortada en diagonal.', 45, 4, 1, 0, 1, NULL)
SET IDENTITY_INSERT [dbo].[Receta] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IDUsuario], [Nombre_Usuario], [Nombre], [Apellido], [Mail], [Contraseña], [RepetirContraseña], [Admin], [NombreFoto]) VALUES (1, N'aylu_lee', N'Aylen', N'Lee', N'aylulee@ort.edu.ar', N'��큒쉍㘀�㸱嗐', N'��큒쉍㘀�㸱嗐', 1, N'esto es una foto')
INSERT [dbo].[Usuario] ([IDUsuario], [Nombre_Usuario], [Nombre], [Apellido], [Mail], [Contraseña], [RepetirContraseña], [Admin], [NombreFoto]) VALUES (3, N'juli_taiter', N'Julian', N'Taiter', N'julian@ort.edu.ar', N'taiter', N'taiter', 0, N'foto.jpg')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
/****** Object:  Index [IX_IngPorRec_RecetaIDReceta]    Script Date: 18/12/2023 18:50:16 ******/
CREATE NONCLUSTERED INDEX [IX_IngPorRec_RecetaIDReceta] ON [dbo].[IngPorRec]
(
	[RecetaIDReceta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Receta_UsuarioIDUsuario]    Script Date: 18/12/2023 18:50:16 ******/
CREATE NONCLUSTERED INDEX [IX_Receta_UsuarioIDUsuario] ON [dbo].[Receta]
(
	[UsuarioIDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IngPorRec]  WITH CHECK ADD  CONSTRAINT [FK_IngPorRec_Receta_RecetaIDReceta] FOREIGN KEY([RecetaIDReceta])
REFERENCES [dbo].[Receta] ([IDReceta])
GO
ALTER TABLE [dbo].[IngPorRec] CHECK CONSTRAINT [FK_IngPorRec_Receta_RecetaIDReceta]
GO
ALTER TABLE [dbo].[Receta]  WITH CHECK ADD  CONSTRAINT [FK_Receta_Usuario_UsuarioIDUsuario] FOREIGN KEY([UsuarioIDUsuario])
REFERENCES [dbo].[Usuario] ([IDUsuario])
GO
ALTER TABLE [dbo].[Receta] CHECK CONSTRAINT [FK_Receta_Usuario_UsuarioIDUsuario]
GO
USE [master]
GO
ALTER DATABASE [RecepediaDB] SET  READ_WRITE 
GO
