USE [master]
GO
/****** Object:  Database [BdIntermedio]    Script Date: 16/09/2018 15:15:46 ******/
CREATE DATABASE [BdIntermedio]
GO
USE [BdIntermedio]
GO
/****** Object:  Table [dbo].[Opcion]    Script Date: 16/09/2018 15:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Opcion](
	[IdOpcion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[Url] [nvarchar](150) NOT NULL,
	[IdOpcionRef] [int] NOT NULL,
	[Titulo] [nvarchar](50) NOT NULL,
	[Controladora] [nvarchar](50) NULL,
	[Accion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Opcion] PRIMARY KEY CLUSTERED 
(
	[IdOpcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 16/09/2018 15:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 16/09/2018 15:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[IdPerfil] [int] IDENTITY(1,1) NOT NULL,
	[NombrePerfil] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilOpcion]    Script Date: 16/09/2018 15:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilOpcion](
	[IdPerfilOpcion] [int] IDENTITY(1,1) NOT NULL,
	[IdPerfil] [int] NOT NULL,
	[IdOpcion] [int] NOT NULL,
 CONSTRAINT [PK_PerfilOpcion] PRIMARY KEY CLUSTERED 
(
	[IdPerfilOpcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/09/2018 15:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](150) NOT NULL,
	[Correo] [nvarchar](150) NOT NULL,
	[Clave] [varbinary](150) NULL,
	[Imagen] [nvarchar](150) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioPerfil]    Script Date: 16/09/2018 15:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPerfil](
	[IdUsuarioPerfil] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdPefil] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioPerfil] PRIMARY KEY CLUSTERED 
(
	[IdUsuarioPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Opcion] ON 
GO
INSERT [dbo].[Opcion] ([IdOpcion], [Nombre], [Url], [IdOpcionRef], [Titulo], [Controladora], [Accion]) VALUES (1, N'MAESTRAS', N'#', 0, N'fa fa-dashboard', N'', N'')
GO
INSERT [dbo].[Opcion] ([IdOpcion], [Nombre], [Url], [IdOpcionRef], [Titulo], [Controladora], [Accion]) VALUES (2, N'USUARIO', N'/Usuario/Index', 1, N'fa fa-circle-o', N'Usuario', N'Index')
GO
INSERT [dbo].[Opcion] ([IdOpcion], [Nombre], [Url], [IdOpcionRef], [Titulo], [Controladora], [Accion]) VALUES (3, N'OPCION', N'/Opcion/Index', 1, N'fa fa-circle-o', N'Opcion', N'index')
GO
INSERT [dbo].[Opcion] ([IdOpcion], [Nombre], [Url], [IdOpcionRef], [Titulo], [Controladora], [Accion]) VALUES (4, N'PROCESOS', N'#', 0, N'fa fa-files-o', N'', N'')
GO
INSERT [dbo].[Opcion] ([IdOpcion], [Nombre], [Url], [IdOpcionRef], [Titulo], [Controladora], [Accion]) VALUES (1002, N'FACTURACION', N'/Factura/Index', 4, N'fa fa-circle-o', N'Factura', N'Index')
GO
INSERT [dbo].[Opcion] ([IdOpcion], [Nombre], [Url], [IdOpcionRef], [Titulo], [Controladora], [Accion]) VALUES (1003, N'PLANILLAS', N'#', 4, N'fa fa-dashboard', N'', N'')
GO
INSERT [dbo].[Opcion] ([IdOpcion], [Nombre], [Url], [IdOpcionRef], [Titulo], [Controladora], [Accion]) VALUES (1004, N'EMPLEADOS', N'/Empleado/Index', 1003, N'fa fa-circle-o', N'Empleado', N'Indez')
GO
INSERT [dbo].[Opcion] ([IdOpcion], [Nombre], [Url], [IdOpcionRef], [Titulo], [Controladora], [Accion]) VALUES (1005, N'PRACTICANTES', N'/Practicante/Index', 1003, N'fa fa-circle-o', N'Practicante', N'Index')
GO
INSERT [dbo].[Opcion] ([IdOpcion], [Nombre], [Url], [IdOpcionRef], [Titulo], [Controladora], [Accion]) VALUES (1006, N'OTROS', N'#', 1003, N'fa fa-files-o', N'', N'')
GO
INSERT [dbo].[Opcion] ([IdOpcion], [Nombre], [Url], [IdOpcionRef], [Titulo], [Controladora], [Accion]) VALUES (1007, N'FUNCIONARIOS', N'/Funcionario/Index', 1006, N'fa fa-files-o', N'Funcionario', N'Index')
GO
SET IDENTITY_INSERT [dbo].[Opcion] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Nombres], [Correo], [Clave], [Imagen]) VALUES (1, N'Juan Perez', N'jperez@hotmail.com', NULL, NULL)
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Nombres], [Correo], [Clave], [Imagen]) VALUES (2, N'Ana Maria', N'agonzales@hotmail.com', 0xDF31D7224FC87EB05D483580028E0FF9, NULL)
--pass 123456789
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO