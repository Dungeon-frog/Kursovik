USE [master]
GO
/****** Object:  Database [kursovik]    Script Date: 20.12.2022 3:38:05 ******/
CREATE DATABASE [kursovik]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kursovik', FILENAME = N'D:\Programs\MSSQLSERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\kursovik.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'kursovik_log', FILENAME = N'D:\Programs\MSSQLSERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\kursovik_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kursovik].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [kursovik] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [kursovik] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [kursovik] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [kursovik] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [kursovik] SET ARITHABORT OFF 
GO
ALTER DATABASE [kursovik] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [kursovik] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [kursovik] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [kursovik] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [kursovik] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [kursovik] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [kursovik] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [kursovik] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [kursovik] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [kursovik] SET  DISABLE_BROKER 
GO
ALTER DATABASE [kursovik] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [kursovik] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [kursovik] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [kursovik] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [kursovik] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [kursovik] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [kursovik] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [kursovik] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [kursovik] SET  MULTI_USER 
GO
ALTER DATABASE [kursovik] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [kursovik] SET DB_CHAINING OFF 
GO
ALTER DATABASE [kursovik] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [kursovik] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [kursovik] SET DELAYED_DURABILITY = DISABLED 
GO
USE [kursovik]
GO
/****** Object:  Table [dbo].[materials]    Script Date: 20.12.2022 3:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materials](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Size] [nchar](20) NOT NULL,
	[Thickness] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_materials] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationMaterial]    Script Date: 20.12.2022 3:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationMaterial](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OperationID] [int] NOT NULL,
	[MaterialID] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[Nds] [int] NOT NULL,
 CONSTRAINT [PK_OperationMaterial] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[operations]    Script Date: 20.12.2022 3:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[operations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [bit] NOT NULL,
	[Status] [nchar](30) NOT NULL,
	[Provider] [nchar](30) NOT NULL,
	[DateDoc] [date] NOT NULL,
	[DateFact] [date] NOT NULL,
 CONSTRAINT [PK_operations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 20.12.2022 3:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NOT NULL,
	[BDate] [date] NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[materials] ON 

INSERT [dbo].[materials] ([ID], [Name], [Size], [Thickness], [Price], [Count]) VALUES (1, N'Фанера ФК(4\4)                                    ', N'1520х1520 ММ.       ', 6, 50, 800)
INSERT [dbo].[materials] ([ID], [Name], [Size], [Thickness], [Price], [Count]) VALUES (2, N'Фанера ФК(5\5)                                    ', N'1780х1780           ', 9, 120, -100)
INSERT [dbo].[materials] ([ID], [Name], [Size], [Thickness], [Price], [Count]) VALUES (3, N'Фанера ФСФ(4\4)                                   ', N'1220х2440 ММ.       ', 6, 320, -250)
INSERT [dbo].[materials] ([ID], [Name], [Size], [Thickness], [Price], [Count]) VALUES (4, N'Фанера ФСФ(4\4)                                   ', N'1220х2440 ММ.       ', 9, 440, 500)
INSERT [dbo].[materials] ([ID], [Name], [Size], [Thickness], [Price], [Count]) VALUES (5, N'Фнера ФСФ(4\4)                                    ', N'1220х2440 ММ.       ', 12, 550, 1500)
INSERT [dbo].[materials] ([ID], [Name], [Size], [Thickness], [Price], [Count]) VALUES (15, N'Пленка ПВА                                        ', N'100х30              ', 16, 100, 0)
SET IDENTITY_INSERT [dbo].[materials] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationMaterial] ON 

INSERT [dbo].[OperationMaterial] ([ID], [OperationID], [MaterialID], [Count], [Nds]) VALUES (1, 1, 1, 200, 10)
INSERT [dbo].[OperationMaterial] ([ID], [OperationID], [MaterialID], [Count], [Nds]) VALUES (3, 1, 2, 100, 0)
INSERT [dbo].[OperationMaterial] ([ID], [OperationID], [MaterialID], [Count], [Nds]) VALUES (4, 1, 3, 500, 0)
INSERT [dbo].[OperationMaterial] ([ID], [OperationID], [MaterialID], [Count], [Nds]) VALUES (5, 2, 3, 250, 20)
INSERT [dbo].[OperationMaterial] ([ID], [OperationID], [MaterialID], [Count], [Nds]) VALUES (6, 2, 4, 500, 20)
INSERT [dbo].[OperationMaterial] ([ID], [OperationID], [MaterialID], [Count], [Nds]) VALUES (7, 3, 1, 1000, 0)
INSERT [dbo].[OperationMaterial] ([ID], [OperationID], [MaterialID], [Count], [Nds]) VALUES (8, 4, 5, 500, 20)
INSERT [dbo].[OperationMaterial] ([ID], [OperationID], [MaterialID], [Count], [Nds]) VALUES (9, 5, 5, 1000, 0)
INSERT [dbo].[OperationMaterial] ([ID], [OperationID], [MaterialID], [Count], [Nds]) VALUES (23, 6, 15, 10, 0)
SET IDENTITY_INSERT [dbo].[OperationMaterial] OFF
GO
SET IDENTITY_INSERT [dbo].[operations] ON 

INSERT [dbo].[operations] ([ID], [Type], [Status], [Provider], [DateDoc], [DateFact]) VALUES (1, 0, N'Проверено                     ', N'ООО "Сима"                    ', CAST(N'2022-01-19' AS Date), CAST(N'2022-01-20' AS Date))
INSERT [dbo].[operations] ([ID], [Type], [Status], [Provider], [DateDoc], [DateFact]) VALUES (2, 1, N'Проверено                     ', N'ИП Иванов К.С.                ', CAST(N'2022-01-16' AS Date), CAST(N'2022-01-19' AS Date))
INSERT [dbo].[operations] ([ID], [Type], [Status], [Provider], [DateDoc], [DateFact]) VALUES (3, 1, N'Проверено                     ', N'ООО "Хрум"                    ', CAST(N'2022-01-13' AS Date), CAST(N'2022-01-16' AS Date))
INSERT [dbo].[operations] ([ID], [Type], [Status], [Provider], [DateDoc], [DateFact]) VALUES (4, 1, N'Проверено                     ', N'ИП Волков И.Н.                ', CAST(N'2022-01-12' AS Date), CAST(N'2022-01-14' AS Date))
INSERT [dbo].[operations] ([ID], [Type], [Status], [Provider], [DateDoc], [DateFact]) VALUES (5, 1, N'Проверено                     ', N'ООО "Тундра"                  ', CAST(N'2022-01-10' AS Date), CAST(N'2022-01-12' AS Date))
INSERT [dbo].[operations] ([ID], [Type], [Status], [Provider], [DateDoc], [DateFact]) VALUES (6, 1, N'Проверено                     ', N'ООО "Максим"                  ', CAST(N'2022-11-29' AS Date), CAST(N'2022-12-16' AS Date))
SET IDENTITY_INSERT [dbo].[operations] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([ID], [LastName], [FirstName], [MiddleName], [BDate], [Role], [Login], [Password]) VALUES (1, N'Admin                         ', N'Admin                         ', N'Admin                         ', CAST(N'2000-01-01' AS Date), N'Admin               ', N'admin               ', N'9af15b336e6a9619928537df30b2e6a2376569fcf9d7e773eccede65606529a0')
SET IDENTITY_INSERT [dbo].[users] OFF
GO
ALTER TABLE [dbo].[OperationMaterial]  WITH CHECK ADD  CONSTRAINT [FK_OperationMaterial_materials] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[materials] ([ID])
GO
ALTER TABLE [dbo].[OperationMaterial] CHECK CONSTRAINT [FK_OperationMaterial_materials]
GO
ALTER TABLE [dbo].[OperationMaterial]  WITH CHECK ADD  CONSTRAINT [FK_OperationMaterial_operations] FOREIGN KEY([OperationID])
REFERENCES [dbo].[operations] ([ID])
GO
ALTER TABLE [dbo].[OperationMaterial] CHECK CONSTRAINT [FK_OperationMaterial_operations]
GO
USE [master]
GO
ALTER DATABASE [kursovik] SET  READ_WRITE 
GO
