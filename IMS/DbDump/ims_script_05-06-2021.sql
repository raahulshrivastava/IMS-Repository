USE [master]
GO
/****** Object:  Database [IMSFinal]    Script Date: 06/05/2021 18:27:17 ******/
CREATE DATABASE [IMSFinal] ON  PRIMARY 
( NAME = N'IMSFinal', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\IMSFinal.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'IMSFinal_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\IMSFinal_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [IMSFinal] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IMSFinal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IMSFinal] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [IMSFinal] SET ANSI_NULLS OFF
GO
ALTER DATABASE [IMSFinal] SET ANSI_PADDING OFF
GO
ALTER DATABASE [IMSFinal] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [IMSFinal] SET ARITHABORT OFF
GO
ALTER DATABASE [IMSFinal] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [IMSFinal] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [IMSFinal] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [IMSFinal] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [IMSFinal] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [IMSFinal] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [IMSFinal] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [IMSFinal] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [IMSFinal] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [IMSFinal] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [IMSFinal] SET  DISABLE_BROKER
GO
ALTER DATABASE [IMSFinal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [IMSFinal] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [IMSFinal] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [IMSFinal] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [IMSFinal] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [IMSFinal] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [IMSFinal] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [IMSFinal] SET  READ_WRITE
GO
ALTER DATABASE [IMSFinal] SET RECOVERY SIMPLE
GO
ALTER DATABASE [IMSFinal] SET  MULTI_USER
GO
ALTER DATABASE [IMSFinal] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [IMSFinal] SET DB_CHAINING OFF
GO
USE [IMSFinal]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](max) NOT NULL,
	[UserType] [int] NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[IsActive] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
 CONSTRAINT [PK_dbo.UserMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserMaster] ON
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (4, N'k', 1, N'raahulk,', N'raahul', N'Y', N'dfgdf', CAST(0x0000A97900000000 AS DateTime), 0, CAST(0x0000A98000000000 AS DateTime), 1)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (7, N'k', 1, N'raahulk,', N'raahul', NULL, N'dfgdf', CAST(0x0000AAB3012A0757 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (9, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (11, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (12, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (13, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (14, N'Admin', 1, N'admin', N'admin', N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (15, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (16, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (17, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (18, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (19, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (20, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (21, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (22, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (23, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (24, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (25, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (26, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (27, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (28, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (29, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (30, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (31, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (32, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (33, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (34, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (35, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (36, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (37, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (38, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (39, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (40, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (41, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (42, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (43, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (44, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (45, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (46, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (47, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (48, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (49, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (50, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (51, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (52, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (53, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserMaster] ([Id], [EmployeeName], [UserType], [UserName], [Password], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (54, N'raahul', 1, N'raahul', N'Admin@123', N'Y', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserMaster] OFF
/****** Object:  Table [dbo].[UnitMaster]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UnitName] [nvarchar](max) NULL,
	[ConversionUnit] [bigint] NULL,
	[ConversionQuantity] [int] NOT NULL,
	[IsActive] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[MdifiedBy] [bigint] NULL,
 CONSTRAINT [PK_dbo.UnitMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UnitMaster] ON
INSERT [dbo].[UnitMaster] ([Id], [UnitName], [ConversionUnit], [ConversionQuantity], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [MdifiedBy]) VALUES (10, N'Tab', 0, 0, N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[UnitMaster] ([Id], [UnitName], [ConversionUnit], [ConversionQuantity], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [MdifiedBy]) VALUES (11, N'Tab 1*10', 10, 10, N'Y', N'demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[UnitMaster] ([Id], [UnitName], [ConversionUnit], [ConversionQuantity], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [MdifiedBy]) VALUES (12, N'Tab 1*5', 10, 5, N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[UnitMaster] ([Id], [UnitName], [ConversionUnit], [ConversionQuantity], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [MdifiedBy]) VALUES (13, N'Tab 1*6', 10, 6, N'Y', N'demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[UnitMaster] ([Id], [UnitName], [ConversionUnit], [ConversionQuantity], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [MdifiedBy]) VALUES (14, N'Tab 1*3', 10, 3, N'Y', N'demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[UnitMaster] ([Id], [UnitName], [ConversionUnit], [ConversionQuantity], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [MdifiedBy]) VALUES (15, N'Bottle', 10, 0, N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, CAST(0x0000AB9400000000 AS DateTime), 9)
INSERT [dbo].[UnitMaster] ([Id], [UnitName], [ConversionUnit], [ConversionQuantity], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [MdifiedBy]) VALUES (16, N'Injection', 10, 0, N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[UnitMaster] ([Id], [UnitName], [ConversionUnit], [ConversionQuantity], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [MdifiedBy]) VALUES (17, N'Box', 10, 0, N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[UnitMaster] ([Id], [UnitName], [ConversionUnit], [ConversionQuantity], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [MdifiedBy]) VALUES (18, N'Other', 10, 0, N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[UnitMaster] ([Id], [UnitName], [ConversionUnit], [ConversionQuantity], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [MdifiedBy]) VALUES (19, N'Pouch', 10, 0, N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[UnitMaster] ([Id], [UnitName], [ConversionUnit], [ConversionQuantity], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [MdifiedBy]) VALUES (20, N'Bag', 10, 0, N'Y', N'Demo', CAST(0x0000ACF600000000 AS DateTime), 14, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UnitMaster] OFF
/****** Object:  Table [dbo].[TblRoles]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TblRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblParameters]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblParameters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RefType] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_dbo.TblParameters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblConfiguration]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblConfiguration](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StoreType] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TblConfiguration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblConfiguration] ON
INSERT [dbo].[TblConfiguration] ([Id], [StoreType], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (3, 1, CAST(0x0000A97700000000 AS DateTime), CAST(0x0000A97700000000 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[TblConfiguration] OFF
/****** Object:  Table [dbo].[TaxMaster]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TaxName] [nvarchar](max) NULL,
	[AppliedOn] [nvarchar](max) NULL,
	[TotalValue] [decimal](18, 2) NOT NULL,
	[CGSTValue] [decimal](18, 2) NOT NULL,
	[SGSTValue] [decimal](18, 2) NOT NULL,
	[IsActive] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[MdifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
 CONSTRAINT [PK_dbo.TaxMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TaxMaster] ON
INSERT [dbo].[TaxMaster] ([Id], [TaxName], [AppliedOn], [TotalValue], [CGSTValue], [SGSTValue], [IsActive], [Description], [CreatedOn], [CreatedBy], [MdifiedOn], [ModifiedBy]) VALUES (6, N'GST 5%', N'1', CAST(5.00 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, CAST(0x0000AB9500000000 AS DateTime), 14)
INSERT [dbo].[TaxMaster] ([Id], [TaxName], [AppliedOn], [TotalValue], [CGSTValue], [SGSTValue], [IsActive], [Description], [CreatedOn], [CreatedBy], [MdifiedOn], [ModifiedBy]) VALUES (7, N'GST 12%', N'1', CAST(12.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, CAST(0x0000AB9500000000 AS DateTime), 14)
INSERT [dbo].[TaxMaster] ([Id], [TaxName], [AppliedOn], [TotalValue], [CGSTValue], [SGSTValue], [IsActive], [Description], [CreatedOn], [CreatedBy], [MdifiedOn], [ModifiedBy]) VALUES (8, N'GST 18%', N'1', CAST(18.00 AS Decimal(18, 2)), CAST(9.00 AS Decimal(18, 2)), CAST(9.00 AS Decimal(18, 2)), N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, CAST(0x0000AB9500000000 AS DateTime), 14)
INSERT [dbo].[TaxMaster] ([Id], [TaxName], [AppliedOn], [TotalValue], [CGSTValue], [SGSTValue], [IsActive], [Description], [CreatedOn], [CreatedBy], [MdifiedOn], [ModifiedBy]) VALUES (9, N'GST 28%', N'1', CAST(28.00 AS Decimal(18, 2)), CAST(14.00 AS Decimal(18, 2)), CAST(14.00 AS Decimal(18, 2)), N'Y', N'demo', CAST(0x0000AB9400000000 AS DateTime), 9, CAST(0x0000AB9500000000 AS DateTime), 14)
SET IDENTITY_INSERT [dbo].[TaxMaster] OFF
/****** Object:  Table [dbo].[SupplierPayment]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SupplierPayment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseInvoiceId] [int] NULL,
	[SuppilerId] [int] NOT NULL,
	[PaymentAmount] [decimal](18, 2) NOT NULL,
	[Description] [varchar](50) NULL,
	[PaymentDate] [datetime] NOT NULL,
	[IsDeleted] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[IsPosted] [int] NULL,
	[IncrementNo] [int] NOT NULL,
	[PaymentNo] [varchar](50) NOT NULL,
	[TotalDue] [decimal](18, 2) NOT NULL,
	[TotalPaid] [decimal](18, 2) NOT NULL,
	[StoreId] [int] NOT NULL,
	[FinancialId] [int] NOT NULL,
 CONSTRAINT [PK_SupplierPayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[SupplierPayment] ON
INSERT [dbo].[SupplierPayment] ([Id], [PurchaseInvoiceId], [SuppilerId], [PaymentAmount], [Description], [PaymentDate], [IsDeleted], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsPosted], [IncrementNo], [PaymentNo], [TotalDue], [TotalPaid], [StoreId], [FinancialId]) VALUES (1, NULL, 9, CAST(4000.00 AS Decimal(18, 2)), N'Demo', CAST(0x0000ACF400000000 AS DateTime), 0, CAST(0x0000ACF600030D2E AS DateTime), 14, CAST(0x0000ACF600000000 AS DateTime), 14, 1, 1, N'SPN1001', CAST(90854.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[SupplierPayment] ([Id], [PurchaseInvoiceId], [SuppilerId], [PaymentAmount], [Description], [PaymentDate], [IsDeleted], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsPosted], [IncrementNo], [PaymentNo], [TotalDue], [TotalPaid], [StoreId], [FinancialId]) VALUES (2, NULL, 9, CAST(10000.00 AS Decimal(18, 2)), N'Demo', CAST(0x0000ACEC00000000 AS DateTime), 0, CAST(0x0000ACF60003219A AS DateTime), 14, CAST(0x0000ACF600000000 AS DateTime), 14, 1, 2, N'SPN1002', CAST(90854.00 AS Decimal(18, 2)), CAST(4000.00 AS Decimal(18, 2)), 1, 1)
SET IDENTITY_INSERT [dbo].[SupplierPayment] OFF
/****** Object:  Table [dbo].[SupplierMaster]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](max) NOT NULL,
	[ContactPerson] [nvarchar](max) NOT NULL,
	[ContactNumber] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[GSTNumber] [nvarchar](max) NOT NULL,
	[PANNumber] [nvarchar](max) NULL,
	[IsActive] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[OpeningBalance] [decimal](18, 2) NULL,
 CONSTRAINT [PK_dbo.SupplierMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SupplierMaster] ON
INSERT [dbo].[SupplierMaster] ([Id], [SupplierName], [ContactPerson], [ContactNumber], [City], [Address], [Email], [GSTNumber], [PANNumber], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [OpeningBalance]) VALUES (5, N'Jamil Silawat', N'Ramesh Kumar', N'6521411412', N'Udaipur', N'11 Demo Demo Test', N'jhonBhai@gmail.com', N'HGF552114', N'IU52214', N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL, CAST(60000.00 AS Decimal(18, 2)))
INSERT [dbo].[SupplierMaster] ([Id], [SupplierName], [ContactPerson], [ContactNumber], [City], [Address], [Email], [GSTNumber], [PANNumber], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [OpeningBalance]) VALUES (6, N'Raghunandan', N'Tahir Khan', N'9554522145', N'UYFAAS', N'145 Solanki Bhawan katmandu Nepal', N'Bheem@gmail.com', N'PLM76786', N'SDA4545', N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL, CAST(45000.00 AS Decimal(18, 2)))
INSERT [dbo].[SupplierMaster] ([Id], [SupplierName], [ContactPerson], [ContactNumber], [City], [Address], [Email], [GSTNumber], [PANNumber], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [OpeningBalance]) VALUES (7, N'Deshmukh and Sons', N'Vilas Rao Deshmukh', N'7541411145', N'Mumbai', N'11 Demo Demo Test', N'Tony@gmail.com', N'DSHU3432423', N'KJH23423', N'Y', N'demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL, CAST(5000.00 AS Decimal(18, 2)))
INSERT [dbo].[SupplierMaster] ([Id], [SupplierName], [ContactPerson], [ContactNumber], [City], [Address], [Email], [GSTNumber], [PANNumber], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [OpeningBalance]) VALUES (8, N'Anand Ji Ptv Ltd', N'Kumar Koshal', N'6521411212', N'Kerala', N'Demo', N'fsd@gmail.net', N'YTR45654', N'KJU66799', N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL, CAST(56584.00 AS Decimal(18, 2)))
INSERT [dbo].[SupplierMaster] ([Id], [SupplierName], [ContactPerson], [ContactNumber], [City], [Address], [Email], [GSTNumber], [PANNumber], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [OpeningBalance]) VALUES (9, N'Khan Akram', N'Sanaulla Khan', N'9555414142', N'Raipur', N'145, faruq e aazam, Mullatalai Udaipur(Raj)', N'Sana@gmail.com', N'YTGF8554', N'KJHHG874', N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL, CAST(78854.00 AS Decimal(18, 2)))
INSERT [dbo].[SupplierMaster] ([Id], [SupplierName], [ContactPerson], [ContactNumber], [City], [Address], [Email], [GSTNumber], [PANNumber], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [OpeningBalance]) VALUES (10, N'Rajnandani Pvt Ltd.', N'Raj Singh ', N'8541121455', N'UDAIPUR', N'287krishnapura', N'Rajbhai@gmail.com', N'JHYTR52214', N'DSEW21122', N'Y', N'Demo', CAST(0x0000ACF600000000 AS DateTime), 14, NULL, NULL, CAST(8000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[SupplierMaster] OFF
/****** Object:  Table [dbo].[StoreMaster]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StoreName] [nvarchar](max) NOT NULL,
	[OwnerName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[State] [nvarchar](max) NOT NULL,
	[GSTINNumber] [nvarchar](max) NULL,
	[DLNumber] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[ContactNumber1] [nvarchar](max) NOT NULL,
	[ContactNumber2] [nvarchar](max) NULL,
	[EmailId1] [nvarchar](max) NOT NULL,
	[EmailId2] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
	[TINNumber] [nvarchar](max) NOT NULL,
	[STNumber] [nvarchar](max) NULL,
	[IsActive] [nvarchar](max) NULL,
	[Logo] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[StoreType] [int] NULL,
	[PaymentType] [int] NULL,
 CONSTRAINT [PK_dbo.StoreMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[StoreMaster] ON
INSERT [dbo].[StoreMaster] ([Id], [StoreName], [OwnerName], [Address], [City], [State], [GSTINNumber], [DLNumber], [Description], [ContactNumber1], [ContactNumber2], [EmailId1], [EmailId2], [Website], [TINNumber], [STNumber], [IsActive], [Logo], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [StoreType], [PaymentType]) VALUES (1, N'mk', N'nkm', N'mkm', N'mkm', N'kmkm', N'km', N'km', N'km', N'kmk', N'mkm', N'mkm@', N'nk', N'km', N'km', N'km', N'Y', NULL, CAST(0x0000A97600000000 AS DateTime), 1, NULL, NULL, 1, 0)
INSERT [dbo].[StoreMaster] ([Id], [StoreName], [OwnerName], [Address], [City], [State], [GSTINNumber], [DLNumber], [Description], [ContactNumber1], [ContactNumber2], [EmailId1], [EmailId2], [Website], [TINNumber], [STNumber], [IsActive], [Logo], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [StoreType], [PaymentType]) VALUES (2, N'store', N'owner', N'address', N'city', N'state', N'gstin', N'dl', N'des', N'contact', N'alternatecontact', N'email@gmail.com', N'alternateemail', N'web', N'tin', N'st', N'Y', NULL, CAST(0x0000A97900000000 AS DateTime), 0, NULL, NULL, 0, 0)
INSERT [dbo].[StoreMaster] ([Id], [StoreName], [OwnerName], [Address], [City], [State], [GSTINNumber], [DLNumber], [Description], [ContactNumber1], [ContactNumber2], [EmailId1], [EmailId2], [Website], [TINNumber], [STNumber], [IsActive], [Logo], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [StoreType], [PaymentType]) VALUES (3, N'mk', N'nkm', N'mkm', N'mkm', N'kmkm', N'km', N'km', N'km', N'kmk', N'mkm', N'mkm@', N'nk', N'km', N'km', N'km', NULL, N'', CAST(0x0000AAB30129EED5 AS DateTime), 1, NULL, NULL, 0, 0)
INSERT [dbo].[StoreMaster] ([Id], [StoreName], [OwnerName], [Address], [City], [State], [GSTINNumber], [DLNumber], [Description], [ContactNumber1], [ContactNumber2], [EmailId1], [EmailId2], [Website], [TINNumber], [STNumber], [IsActive], [Logo], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [StoreType], [PaymentType]) VALUES (4, N'store', N'owner', N'address', N'city', N'state', N'gstin', N'dl', N'des', N'contact', N'alternatecontact', N'email@gmail.com', N'alternateemail', N'web', N'tin', N'st', NULL, N'', CAST(0x0000AAB30129EED5 AS DateTime), 1, NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[StoreMaster] OFF
/****** Object:  Table [dbo].[StockOutHeader]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockOutHeader](
	[StockOutHeaderId] [bigint] IDENTITY(1,1) NOT NULL,
	[StoreId] [bigint] NOT NULL,
	[FinYear] [varchar](10) NOT NULL,
	[Description] [varchar](max) NULL,
	[IsDeleted] [int] NULL,
	[IncrementedNo] [bigint] NOT NULL,
	[StockOutDate] [datetime] NOT NULL,
	[StockOutNo] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
 CONSTRAINT [PK_StockOutHeader] PRIMARY KEY CLUSTERED 
(
	[StockOutHeaderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[StockOutHeader] ON
INSERT [dbo].[StockOutHeader] ([StockOutHeaderId], [StoreId], [FinYear], [Description], [IsDeleted], [IncrementedNo], [StockOutDate], [StockOutNo], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1, 1, N'1', NULL, 0, 1, CAST(0x0000ACFA00000000 AS DateTime), N'STKOUT-1001', CAST(0x0000ACFA00000000 AS DateTime), 14, NULL, NULL)
SET IDENTITY_INSERT [dbo].[StockOutHeader] OFF
/****** Object:  Table [dbo].[StockOutDetailMaster]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockOutDetailMaster](
	[StockOuDetailId] [bigint] IDENTITY(1,1) NOT NULL,
	[StockOutHeaderId] [bigint] NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Quantity] [int] NULL,
	[BatchNo] [varchar](max) NULL,
	[ExpiryDate] [datetime] NULL,
	[UnitId] [bigint] NULL,
 CONSTRAINT [PK_dbo.StockOutDetailMaster] PRIMARY KEY CLUSTERED 
(
	[StockOuDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[StockOutDetailMaster] ON
INSERT [dbo].[StockOutDetailMaster] ([StockOuDetailId], [StockOutHeaderId], [CategoryId], [ProductId], [Quantity], [BatchNo], [ExpiryDate], [UnitId]) VALUES (1, 1, 13, 2, 10, N'', NULL, 15)
INSERT [dbo].[StockOutDetailMaster] ([StockOuDetailId], [StockOutHeaderId], [CategoryId], [ProductId], [Quantity], [BatchNo], [ExpiryDate], [UnitId]) VALUES (2, 1, 11, 3, 15, N'', NULL, 15)
SET IDENTITY_INSERT [dbo].[StockOutDetailMaster] OFF
/****** Object:  Table [dbo].[StockInHeaderMaster]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockInHeaderMaster](
	[StockInHeaderId] [bigint] IDENTITY(1,1) NOT NULL,
	[StoreId] [bigint] NOT NULL,
	[FinancialYearId] [bigint] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IncrementedNo] [bigint] NOT NULL,
	[StockInDate] [datetime] NOT NULL,
	[StockInNumber] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[IsDeleted] [int] NULL,
 CONSTRAINT [PK_dbo.StockInHeaderMaster] PRIMARY KEY CLUSTERED 
(
	[StockInHeaderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[StockInHeaderMaster] ON
INSERT [dbo].[StockInHeaderMaster] ([StockInHeaderId], [StoreId], [FinancialYearId], [Description], [IncrementedNo], [StockInDate], [StockInNumber], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (1, 1, 1, N'Demo', 1, CAST(0x0000ACFB00000000 AS DateTime), N'STKIN-1001', CAST(0x0000ACFA00000000 AS DateTime), 14, CAST(0x0000ACFC00000000 AS DateTime), 14, 1)
INSERT [dbo].[StockInHeaderMaster] ([StockInHeaderId], [StoreId], [FinancialYearId], [Description], [IncrementedNo], [StockInDate], [StockInNumber], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (2, 1, 1, NULL, 2, CAST(0x0000ACFC00000000 AS DateTime), N'STKIN-1002', CAST(0x0000ACFC00000000 AS DateTime), 14, CAST(0x0000ACFC00000000 AS DateTime), 14, 1)
INSERT [dbo].[StockInHeaderMaster] ([StockInHeaderId], [StoreId], [FinancialYearId], [Description], [IncrementedNo], [StockInDate], [StockInNumber], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (3, 1, 1, NULL, 3, CAST(0x0000ACFC00000000 AS DateTime), N'STKIN-1003', CAST(0x0000ACFC00000000 AS DateTime), 14, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[StockInHeaderMaster] OFF
/****** Object:  Table [dbo].[StockInDetailMaster]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockInDetailMaster](
	[StockInDetailId] [bigint] IDENTITY(1,1) NOT NULL,
	[StockInHeaderId] [bigint] NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Quantity] [int] NULL,
	[BatchNo] [nvarchar](max) NULL,
	[ExpiryDate] [datetime] NULL,
	[UnitId] [bigint] NULL,
 CONSTRAINT [PK_dbo.StockInDetailMaster] PRIMARY KEY CLUSTERED 
(
	[StockInDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[StockInDetailMaster] ON
INSERT [dbo].[StockInDetailMaster] ([StockInDetailId], [StockInHeaderId], [CategoryId], [ProductId], [Quantity], [BatchNo], [ExpiryDate], [UnitId]) VALUES (1, 1, 12, 4, 20, N'', NULL, 15)
INSERT [dbo].[StockInDetailMaster] ([StockInDetailId], [StockInHeaderId], [CategoryId], [ProductId], [Quantity], [BatchNo], [ExpiryDate], [UnitId]) VALUES (2, 1, 11, 3, 10, N'', NULL, 15)
INSERT [dbo].[StockInDetailMaster] ([StockInDetailId], [StockInHeaderId], [CategoryId], [ProductId], [Quantity], [BatchNo], [ExpiryDate], [UnitId]) VALUES (3, 1, 13, 2, 15, N'', NULL, 15)
INSERT [dbo].[StockInDetailMaster] ([StockInDetailId], [StockInHeaderId], [CategoryId], [ProductId], [Quantity], [BatchNo], [ExpiryDate], [UnitId]) VALUES (4, 2, 12, 4, 5, N'', NULL, 15)
INSERT [dbo].[StockInDetailMaster] ([StockInDetailId], [StockInHeaderId], [CategoryId], [ProductId], [Quantity], [BatchNo], [ExpiryDate], [UnitId]) VALUES (5, 3, 13, 2, 10, N'', NULL, 15)
INSERT [dbo].[StockInDetailMaster] ([StockInDetailId], [StockInHeaderId], [CategoryId], [ProductId], [Quantity], [BatchNo], [ExpiryDate], [UnitId]) VALUES (6, 3, 11, 3, 10, N'', NULL, 15)
SET IDENTITY_INSERT [dbo].[StockInDetailMaster] OFF
/****** Object:  Table [dbo].[SalesInvoiceReturnHeader]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SalesInvoiceReturnHeader](
	[SalesInvoiceReturnHeaderId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[ReturnNo] [varchar](50) NULL,
	[CustomerId] [int] NULL,
	[InvoiceNo] [varchar](50) NULL,
	[InvoiceDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ReturnReason] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[IncrementedNo] [int] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SalesInvoiceReturnHeaderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SalesInvoiceReturnDetail]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SalesInvoiceReturnDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SalesRerutnHeaderId] [int] NULL,
	[ProductId] [int] NULL,
	[BatchNo] [varchar](100) NULL,
	[ExpiryDate] [datetime] NULL,
	[Quantity] [int] NULL,
	[FreeQuantity] [int] NULL,
	[TotalQuantity] [int] NULL,
	[ReturnQuantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SalesInvoiceDetail]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SalesInvoiceDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SalesInvInvoiceId] [bigint] NOT NULL,
	[ProductId] [int] NOT NULL,
	[BatchNo] [varchar](50) NULL,
	[ExpiryDate] [date] NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[MPR] [decimal](10, 2) NOT NULL,
	[TotalAmount] [decimal](10, 2) NOT NULL,
	[Discount] [decimal](10, 2) NOT NULL,
	[TaxableAmount] [decimal](10, 2) NOT NULL,
	[IGSTAmount] [decimal](10, 2) NOT NULL,
	[CGSTAmount] [decimal](10, 2) NOT NULL,
	[SGSTAmount] [decimal](10, 2) NOT NULL,
	[IGSTPercentage] [decimal](10, 2) NOT NULL,
	[CGSTPercentage] [decimal](10, 2) NOT NULL,
	[SGSTPercent] [decimal](10, 2) NOT NULL,
	[GrossAmount] [decimal](10, 2) NOT NULL,
	[FreeQuantity] [int] NULL,
	[TotalQauntity] [int] NULL,
 CONSTRAINT [PK_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[SalesInvoiceDetail] ON
INSERT [dbo].[SalesInvoiceDetail] ([Id], [SalesInvInvoiceId], [ProductId], [BatchNo], [ExpiryDate], [Quantity], [Price], [MPR], [TotalAmount], [Discount], [TaxableAmount], [IGSTAmount], [CGSTAmount], [SGSTAmount], [IGSTPercentage], [CGSTPercentage], [SGSTPercent], [GrossAmount], [FreeQuantity], [TotalQauntity]) VALUES (1, 1, 4, N'', NULL, 2, CAST(20.00 AS Decimal(10, 2)), CAST(150.00 AS Decimal(10, 2)), CAST(300.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(300.01 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(42.00 AS Decimal(10, 2)), CAST(42.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(14.00 AS Decimal(10, 2)), CAST(14.00 AS Decimal(10, 2)), CAST(300.01 AS Decimal(10, 2)), 0, 2)
INSERT [dbo].[SalesInvoiceDetail] ([Id], [SalesInvInvoiceId], [ProductId], [BatchNo], [ExpiryDate], [Quantity], [Price], [MPR], [TotalAmount], [Discount], [TaxableAmount], [IGSTAmount], [CGSTAmount], [SGSTAmount], [IGSTPercentage], [CGSTPercentage], [SGSTPercent], [GrossAmount], [FreeQuantity], [TotalQauntity]) VALUES (2, 1, 3, N'', NULL, 10, CAST(30.00 AS Decimal(10, 2)), CAST(80.00 AS Decimal(10, 2)), CAST(800.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(800.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(48.00 AS Decimal(10, 2)), CAST(48.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(6.00 AS Decimal(10, 2)), CAST(6.00 AS Decimal(10, 2)), CAST(800.00 AS Decimal(10, 2)), 0, 10)
INSERT [dbo].[SalesInvoiceDetail] ([Id], [SalesInvInvoiceId], [ProductId], [BatchNo], [ExpiryDate], [Quantity], [Price], [MPR], [TotalAmount], [Discount], [TaxableAmount], [IGSTAmount], [CGSTAmount], [SGSTAmount], [IGSTPercentage], [CGSTPercentage], [SGSTPercent], [GrossAmount], [FreeQuantity], [TotalQauntity]) VALUES (3, 2, 2, N'', NULL, 5, CAST(10.00 AS Decimal(10, 2)), CAST(50.00 AS Decimal(10, 2)), CAST(250.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(250.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(22.50 AS Decimal(10, 2)), CAST(22.50 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(9.00 AS Decimal(10, 2)), CAST(9.00 AS Decimal(10, 2)), CAST(250.00 AS Decimal(10, 2)), 0, 5)
SET IDENTITY_INSERT [dbo].[SalesInvoiceDetail] OFF
/****** Object:  Table [dbo].[SalesInvoice]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SalesInvoice](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[InvoiceNo] [varchar](50) NOT NULL,
	[IncrementNo] [int] NOT NULL,
	[ModifiedOn] [date] NULL,
	[ModifiedBy] [int] NULL,
	[TotalCGST] [decimal](10, 2) NULL,
	[TotalSGST] [decimal](10, 2) NULL,
	[TotalIGST] [decimal](10, 2) NULL,
	[TotalTaxAmount] [decimal](10, 2) NULL,
	[Discount] [decimal](10, 2) NULL,
	[TotalAmount] [decimal](10, 2) NULL,
	[ExtraAmount] [decimal](10, 2) NULL,
	[FinalAmount] [decimal](10, 2) NULL,
	[FinalDiscount] [decimal](10, 2) NULL,
	[PaidAmount] [decimal](10, 2) NULL,
	[FinancialId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[CustomerId] [int] NULL,
	[Description] [varchar](max) NULL,
	[InvoiceType] [varchar](7) NULL,
	[IsPosted] [int] NULL,
	[IsDeleted] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [date] NULL,
	[NetAmount] [decimal](10, 2) NULL,
 CONSTRAINT [PK_SalesId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[SalesInvoice] ON
INSERT [dbo].[SalesInvoice] ([Id], [Date], [CustomerName], [InvoiceNo], [IncrementNo], [ModifiedOn], [ModifiedBy], [TotalCGST], [TotalSGST], [TotalIGST], [TotalTaxAmount], [Discount], [TotalAmount], [ExtraAmount], [FinalAmount], [FinalDiscount], [PaidAmount], [FinancialId], [StoreId], [CustomerId], [Description], [InvoiceType], [IsPosted], [IsDeleted], [CreatedBy], [CreatedOn], [NetAmount]) VALUES (1, CAST(0x51420B00 AS Date), N'Snehalata Joshi', N'SIINV2001', 1, CAST(0x51420B00 AS Date), 14, CAST(90.00 AS Decimal(10, 2)), CAST(90.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(1100.01 AS Decimal(10, 2)), CAST(180.00 AS Decimal(10, 2)), CAST(1100.00 AS Decimal(10, 2)), CAST(80.00 AS Decimal(10, 2)), CAST(1000.00 AS Decimal(10, 2)), NULL, CAST(500.00 AS Decimal(10, 2)), 1, 1, 8, N'Demo', N'2', 1, 0, 14, CAST(0x51420B00 AS Date), NULL)
INSERT [dbo].[SalesInvoice] ([Id], [Date], [CustomerName], [InvoiceNo], [IncrementNo], [ModifiedOn], [ModifiedBy], [TotalCGST], [TotalSGST], [TotalIGST], [TotalTaxAmount], [Discount], [TotalAmount], [ExtraAmount], [FinalAmount], [FinalDiscount], [PaidAmount], [FinancialId], [StoreId], [CustomerId], [Description], [InvoiceType], [IsPosted], [IsDeleted], [CreatedBy], [CreatedOn], [NetAmount]) VALUES (2, CAST(0x52420B00 AS Date), N'Mukesh Kumar Garg', N'SIINV2002', 2, CAST(0x52420B00 AS Date), 14, CAST(22.50 AS Decimal(10, 2)), CAST(22.50 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(250.00 AS Decimal(10, 2)), CAST(100.00 AS Decimal(10, 2)), CAST(250.00 AS Decimal(10, 2)), CAST(50.00 AS Decimal(10, 2)), CAST(200.00 AS Decimal(10, 2)), NULL, CAST(100.00 AS Decimal(10, 2)), 1, 1, 7, N'Demo', N'2', 1, 0, 14, CAST(0x52420B00 AS Date), NULL)
SET IDENTITY_INSERT [dbo].[SalesInvoice] OFF
/****** Object:  Table [dbo].[PurchaserInvoiceHeader]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaserInvoiceHeader](
	[PurchaseInvHeadId] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[SupplierBillDate] [date] NOT NULL,
	[SupplierBillNo] [varchar](50) NOT NULL,
	[InvoiceNo] [varchar](50) NOT NULL,
	[IncrementNo] [int] NOT NULL,
	[ModifiedOn] [date] NULL,
	[ModifiedBy] [int] NULL,
	[TotalCGST] [decimal](10, 2) NULL,
	[TotalSGST] [decimal](10, 2) NULL,
	[TotalIGST] [decimal](10, 2) NULL,
	[TotalTaxAmount] [decimal](10, 2) NULL,
	[Discount] [decimal](10, 2) NULL,
	[TotalAmount] [decimal](10, 2) NULL,
	[ExtraAmount] [decimal](10, 2) NULL,
	[FinalAmount] [decimal](10, 2) NULL,
	[FinalDiscount] [decimal](10, 2) NULL,
	[PaidAmount] [decimal](10, 2) NULL,
	[FinancialId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[SupplierID] [int] NULL,
	[Description] [varchar](max) NULL,
	[InvoiceType] [varchar](7) NULL,
	[IsPosted] [int] NULL,
	[IsDeleted] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [date] NULL,
 CONSTRAINT [PK_PurchaserInvoiceHeader] PRIMARY KEY CLUSTERED 
(
	[PurchaseInvHeadId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaserInvoiceHeader] ON
INSERT [dbo].[PurchaserInvoiceHeader] ([PurchaseInvHeadId], [Date], [SupplierBillDate], [SupplierBillNo], [InvoiceNo], [IncrementNo], [ModifiedOn], [ModifiedBy], [TotalCGST], [TotalSGST], [TotalIGST], [TotalTaxAmount], [Discount], [TotalAmount], [ExtraAmount], [FinalAmount], [FinalDiscount], [PaidAmount], [FinancialId], [StoreId], [SupplierID], [Description], [InvoiceType], [IsPosted], [IsDeleted], [CreatedBy], [CreatedOn]) VALUES (1, CAST(0x50420B00 AS Date), CAST(0x4A420B00 AS Date), N'652145', N'PIINV2001', 1, CAST(0x50420B00 AS Date), 14, CAST(782.00 AS Decimal(10, 2)), CAST(782.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(10700.00 AS Decimal(10, 2)), CAST(64.00 AS Decimal(10, 2)), CAST(10700.00 AS Decimal(10, 2)), CAST(300.00 AS Decimal(10, 2)), CAST(12264.00 AS Decimal(10, 2)), NULL, CAST(5000.00 AS Decimal(10, 2)), 1, 1, 9, N'Demo', N'2', 1, 0, 14, CAST(0x50420B00 AS Date))
INSERT [dbo].[PurchaserInvoiceHeader] ([PurchaseInvHeadId], [Date], [SupplierBillDate], [SupplierBillNo], [InvoiceNo], [IncrementNo], [ModifiedOn], [ModifiedBy], [TotalCGST], [TotalSGST], [TotalIGST], [TotalTaxAmount], [Discount], [TotalAmount], [ExtraAmount], [FinalAmount], [FinalDiscount], [PaidAmount], [FinancialId], [StoreId], [SupplierID], [Description], [InvoiceType], [IsPosted], [IsDeleted], [CreatedBy], [CreatedOn]) VALUES (2, CAST(0x51420B00 AS Date), CAST(0x4D420B00 AS Date), N'4585569', N'PIINV2002', 2, CAST(0x50420B00 AS Date), 14, CAST(644.00 AS Decimal(10, 2)), CAST(644.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(7000.00 AS Decimal(10, 2)), CAST(288.00 AS Decimal(10, 2)), CAST(7000.00 AS Decimal(10, 2)), CAST(500.00 AS Decimal(10, 2)), CAST(8288.00 AS Decimal(10, 2)), NULL, CAST(4000.00 AS Decimal(10, 2)), 1, 1, 9, N'Demo', N'2', 1, 0, 14, CAST(0x50420B00 AS Date))
SET IDENTITY_INSERT [dbo].[PurchaserInvoiceHeader] OFF
/****** Object:  Table [dbo].[PurchaseReturnHeader]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseReturnHeader](
	[PurchaseReturnHeaderId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[ReturnNo] [varchar](50) NULL,
	[SupplierId] [bigint] NULL,
	[InvoiceNo] [varchar](50) NULL,
	[InvoiceDate] [date] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[ModifiedOn] [date] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ReturnReason] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[IncrementedNo] [int] NOT NULL,
	[IsDeleted] [int] NULL,
 CONSTRAINT [PK_PurchaseReturnHeader] PRIMARY KEY CLUSTERED 
(
	[PurchaseReturnHeaderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseInvReturnDetail]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseInvReturnDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseRerutnHeaderId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[BatchNo] [varchar](50) NULL,
	[ExpiryDate] [date] NULL,
	[Quantity] [int] NULL,
	[FreeQuantity] [int] NULL,
	[TotalQuantity] [int] NULL,
	[ReturnQuantity] [int] NULL,
 CONSTRAINT [PK_PurchaseInvReturnDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseInvoiceDetail]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseInvoiceDetail](
	[PurchaserInvDetId] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaserInvHeaderId] [bigint] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ChallanNo] [varchar](50) NOT NULL,
	[BatchNo] [varchar](50) NULL,
	[ExpiryDate] [date] NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[MPR] [decimal](10, 2) NOT NULL,
	[TotalAmount] [decimal](10, 2) NOT NULL,
	[Discount] [decimal](10, 2) NOT NULL,
	[TaxableAmount] [decimal](10, 2) NOT NULL,
	[IGSTAmount] [decimal](10, 2) NOT NULL,
	[CGSTAmount] [decimal](10, 2) NOT NULL,
	[SGSTAmount] [decimal](10, 2) NOT NULL,
	[IGSTPercentage] [decimal](10, 2) NOT NULL,
	[CGSTPercentage] [decimal](10, 2) NOT NULL,
	[SGSTPercent] [decimal](10, 2) NOT NULL,
	[GrossAmount] [decimal](10, 2) NOT NULL,
	[FreeQuantity] [int] NULL,
	[TotalQauntity] [int] NULL,
 CONSTRAINT [PK_PurchaseInvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[PurchaserInvDetId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseInvoiceDetail] ON
INSERT [dbo].[PurchaseInvoiceDetail] ([PurchaserInvDetId], [PurchaserInvHeaderId], [ProductId], [ChallanNo], [BatchNo], [ExpiryDate], [Quantity], [Price], [MPR], [TotalAmount], [Discount], [TaxableAmount], [IGSTAmount], [CGSTAmount], [SGSTAmount], [IGSTPercentage], [CGSTPercentage], [SGSTPercent], [GrossAmount], [FreeQuantity], [TotalQauntity]) VALUES (1, 1, 1, N'2145478', N'', NULL, 40, CAST(120.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(4800.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(4800.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(288.00 AS Decimal(10, 2)), CAST(288.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(6.00 AS Decimal(10, 2)), CAST(6.00 AS Decimal(10, 2)), CAST(5376.00 AS Decimal(10, 2)), 0, 40)
INSERT [dbo].[PurchaseInvoiceDetail] ([PurchaserInvDetId], [PurchaserInvHeaderId], [ProductId], [ChallanNo], [BatchNo], [ExpiryDate], [Quantity], [Price], [MPR], [TotalAmount], [Discount], [TaxableAmount], [IGSTAmount], [CGSTAmount], [SGSTAmount], [IGSTPercentage], [CGSTPercentage], [SGSTPercent], [GrossAmount], [FreeQuantity], [TotalQauntity]) VALUES (2, 1, 4, N'232514', N'', NULL, 20, CAST(80.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(1600.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(1600.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(224.00 AS Decimal(10, 2)), CAST(224.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(14.00 AS Decimal(10, 2)), CAST(14.00 AS Decimal(10, 2)), CAST(2048.00 AS Decimal(10, 2)), 0, 20)
INSERT [dbo].[PurchaseInvoiceDetail] ([PurchaserInvDetId], [PurchaserInvHeaderId], [ProductId], [ChallanNo], [BatchNo], [ExpiryDate], [Quantity], [Price], [MPR], [TotalAmount], [Discount], [TaxableAmount], [IGSTAmount], [CGSTAmount], [SGSTAmount], [IGSTPercentage], [CGSTPercentage], [SGSTPercent], [GrossAmount], [FreeQuantity], [TotalQauntity]) VALUES (3, 1, 3, N'1454447', N'', NULL, 30, CAST(130.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(3900.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(3900.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(234.00 AS Decimal(10, 2)), CAST(234.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(6.00 AS Decimal(10, 2)), CAST(6.00 AS Decimal(10, 2)), CAST(4368.00 AS Decimal(10, 2)), 0, 30)
INSERT [dbo].[PurchaseInvoiceDetail] ([PurchaserInvDetId], [PurchaserInvHeaderId], [ProductId], [ChallanNo], [BatchNo], [ExpiryDate], [Quantity], [Price], [MPR], [TotalAmount], [Discount], [TaxableAmount], [IGSTAmount], [CGSTAmount], [SGSTAmount], [IGSTPercentage], [CGSTPercentage], [SGSTPercent], [GrossAmount], [FreeQuantity], [TotalQauntity]) VALUES (4, 1, 2, N'23666987', N'', NULL, 10, CAST(40.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(400.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(400.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(36.00 AS Decimal(10, 2)), CAST(36.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(9.00 AS Decimal(10, 2)), CAST(9.00 AS Decimal(10, 2)), CAST(472.00 AS Decimal(10, 2)), 0, 10)
INSERT [dbo].[PurchaseInvoiceDetail] ([PurchaserInvDetId], [PurchaserInvHeaderId], [ProductId], [ChallanNo], [BatchNo], [ExpiryDate], [Quantity], [Price], [MPR], [TotalAmount], [Discount], [TaxableAmount], [IGSTAmount], [CGSTAmount], [SGSTAmount], [IGSTPercentage], [CGSTPercentage], [SGSTPercent], [GrossAmount], [FreeQuantity], [TotalQauntity]) VALUES (5, 2, 4, N'232544', N'', NULL, 20, CAST(140.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(2800.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(2800.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(392.00 AS Decimal(10, 2)), CAST(392.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(14.00 AS Decimal(10, 2)), CAST(14.00 AS Decimal(10, 2)), CAST(3584.00 AS Decimal(10, 2)), 0, 20)
INSERT [dbo].[PurchaseInvoiceDetail] ([PurchaserInvDetId], [PurchaserInvHeaderId], [ProductId], [ChallanNo], [BatchNo], [ExpiryDate], [Quantity], [Price], [MPR], [TotalAmount], [Discount], [TaxableAmount], [IGSTAmount], [CGSTAmount], [SGSTAmount], [IGSTPercentage], [CGSTPercentage], [SGSTPercent], [GrossAmount], [FreeQuantity], [TotalQauntity]) VALUES (6, 2, 3, N'325148', N'', NULL, 30, CAST(140.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(4200.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(4200.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(252.00 AS Decimal(10, 2)), CAST(252.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(6.00 AS Decimal(10, 2)), CAST(6.00 AS Decimal(10, 2)), CAST(4704.00 AS Decimal(10, 2)), 0, 30)
SET IDENTITY_INSERT [dbo].[PurchaseInvoiceDetail] OFF
/****** Object:  Table [dbo].[ProductMasterHeader]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductMasterHeader](
	[ProductId] [bigint] IDENTITY(1,1) NOT NULL,
	[StoreId] [bigint] NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[BrandId] [bigint] NOT NULL,
	[UnitId] [bigint] NOT NULL,
	[TaxId] [bigint] NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[ItemSkuCode] [nvarchar](max) NULL,
	[RecorderQuantity] [int] NOT NULL,
	[CessTax] [decimal](18, 2) NULL,
	[ItemType] [int] NOT NULL,
	[SalesPriceMRP] [decimal](18, 2) NOT NULL,
	[RackNo] [nvarchar](max) NULL,
	[GenericName] [nvarchar](max) NOT NULL,
	[HSNSACCode] [nvarchar](max) NULL,
	[IsActive] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[HasBatchNumber] [bit] NULL,
 CONSTRAINT [PK_dbo.ProductMasterHeader] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ProductMasterHeader] ON
INSERT [dbo].[ProductMasterHeader] ([ProductId], [StoreId], [CategoryId], [BrandId], [UnitId], [TaxId], [ProductName], [ItemSkuCode], [RecorderQuantity], [CessTax], [ItemType], [SalesPriceMRP], [RackNo], [GenericName], [HSNSACCode], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [HasBatchNumber]) VALUES (1, 1, 9, 15, 11, 7, N'Daiclofin ', N'YT233221', 10, NULL, 1, CAST(150.00 AS Decimal(18, 2)), N'I-87', N'Daiclo', N'YUT3423424', N'Y', NULL, CAST(0x0000ABA100000000 AS DateTime), 14, NULL, NULL, 1)
INSERT [dbo].[ProductMasterHeader] ([ProductId], [StoreId], [CategoryId], [BrandId], [UnitId], [TaxId], [ProductName], [ItemSkuCode], [RecorderQuantity], [CessTax], [ItemType], [SalesPriceMRP], [RackNo], [GenericName], [HSNSACCode], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [HasBatchNumber]) VALUES (2, 1, 13, 19, 15, 8, N'Vicks Vapo Rub', N'MNB4354354', 15, NULL, 1, CAST(80.00 AS Decimal(18, 2)), N'G-32', N'Vicks', N'LOI54546', N'Y', N'Vicks', CAST(0x0000ABA100000000 AS DateTime), 14, CAST(0x0000AC1200000000 AS DateTime), 14, 1)
INSERT [dbo].[ProductMasterHeader] ([ProductId], [StoreId], [CategoryId], [BrandId], [UnitId], [TaxId], [ProductName], [ItemSkuCode], [RecorderQuantity], [CessTax], [ItemType], [SalesPriceMRP], [RackNo], [GenericName], [HSNSACCode], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [HasBatchNumber]) VALUES (3, 1, 11, 21, 15, 7, N'Nebasulf', N'DVF232', 5, NULL, 1, CAST(40.00 AS Decimal(18, 2)), N'K-7', N'Neomycin', N'OPOI576576', N'Y', NULL, CAST(0x0000ABA100000000 AS DateTime), 14, NULL, NULL, 1)
INSERT [dbo].[ProductMasterHeader] ([ProductId], [StoreId], [CategoryId], [BrandId], [UnitId], [TaxId], [ProductName], [ItemSkuCode], [RecorderQuantity], [CessTax], [ItemType], [SalesPriceMRP], [RackNo], [GenericName], [HSNSACCode], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [HasBatchNumber]) VALUES (4, 1, 12, 22, 15, 9, N'Kayam Churn', N'HGTFF2587', 10, NULL, 1, CAST(150.00 AS Decimal(18, 2)), N'J-20', N'NA', N'MNJJHY251447', N'Y', N'Demo', CAST(0x0000ACF400000000 AS DateTime), 14, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[ProductMasterHeader] OFF
/****** Object:  Table [dbo].[ProductMasterDetail]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductMasterDetail](
	[ProductDetailId] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[AtrtributeValue] [nvarchar](max) NOT NULL,
	[AttributeId] [bigint] NOT NULL,
	[AttributeDetailId] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.ProductMasterDetail] PRIMARY KEY CLUSTERED 
(
	[ProductDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrefixMaster]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrefixMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PrefixName] [nvarchar](max) NULL,
	[PageNumber] [nvarchar](max) NULL,
	[StartingFrom] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
 CONSTRAINT [PK_dbo.PrefixMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PrefixMaster] ON
INSERT [dbo].[PrefixMaster] ([Id], [PrefixName], [PageNumber], [StartingFrom], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (2, N'STKIN', N'Stock In', N'1000', NULL, CAST(0x0000A97600000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[PrefixMaster] ([Id], [PrefixName], [PageNumber], [StartingFrom], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (4, N'PIINV', N'Purchase Invoice', N'2000', NULL, CAST(0x0000A99100000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[PrefixMaster] ([Id], [PrefixName], [PageNumber], [StartingFrom], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (5, N'PR', N'Purchase Return', N'1000', NULL, CAST(0x0000A9A700000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[PrefixMaster] ([Id], [PrefixName], [PageNumber], [StartingFrom], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (6, N'STKOUT', N'Stock Out', N'1000', NULL, CAST(0x0000A9A700000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[PrefixMaster] ([Id], [PrefixName], [PageNumber], [StartingFrom], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (7, N'SIINV', N'Sales Invoice', N'2000', NULL, CAST(0x0000A9A700000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[PrefixMaster] ([Id], [PrefixName], [PageNumber], [StartingFrom], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (8, N'SR', N'Sales Return', N'1000', NULL, CAST(0x0000A9A700000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[PrefixMaster] ([Id], [PrefixName], [PageNumber], [StartingFrom], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (9, N'STKIN', N'Stock In', N'1000', N'', CAST(0x0000AAB3012A4578 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[PrefixMaster] ([Id], [PrefixName], [PageNumber], [StartingFrom], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10, N'PIINV', N'Purchase Invoice', N'2000', N'', CAST(0x0000AAB3012A4578 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[PrefixMaster] ([Id], [PrefixName], [PageNumber], [StartingFrom], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (11, N'PR', N'Purchase Return', N'1000', N'', CAST(0x0000AAB3012A4578 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[PrefixMaster] ([Id], [PrefixName], [PageNumber], [StartingFrom], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (12, N'STKOUT', N'Stock Out', N'1000', N'', CAST(0x0000AAB3012A4578 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[PrefixMaster] ([Id], [PrefixName], [PageNumber], [StartingFrom], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (13, N'SIINV', N'Sales Invoice', N'2000', N'', CAST(0x0000AAB3012A4578 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[PrefixMaster] ([Id], [PrefixName], [PageNumber], [StartingFrom], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (14, N'SR', N'Sales Return', N'1000', N'', CAST(0x0000AAB3012A4578 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[PrefixMaster] ([Id], [PrefixName], [PageNumber], [StartingFrom], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (15, N'SPN', N'Supplier Payment Note', N'1000', NULL, CAST(0x0000ACEC00000000 AS DateTime), 14, CAST(0x0000ACEC00000000 AS DateTime), 14)
INSERT [dbo].[PrefixMaster] ([Id], [PrefixName], [PageNumber], [StartingFrom], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (16, N'CPN', N'Customer Payment Note', N'1000', NULL, CAST(0x0000ACED00000000 AS DateTime), 14, NULL, NULL)
SET IDENTITY_INSERT [dbo].[PrefixMaster] OFF
/****** Object:  Table [dbo].[LogTables]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTables](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Source] [nvarchar](max) NULL,
	[Helpline] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[UserId] [bigint] NULL,
	[UserName] [nvarchar](max) NULL,
	[InnerException] [nvarchar](max) NULL,
	[StackTrace] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.LogTables] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LogTables] ON
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (1, N'IMS', NULL, N'Nullable object must have a value.', 14, N'admin', N'', N'   at IMS.Controllers.PurchaseReturnController.PurchaseReturnReport(Int32 id) in D:\IMS\IMS\Controllers\PurchaseReturnController.cs:line 131
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (2, N'IMS', NULL, N'Nullable object must have a value.', 14, N'admin', N'', N'   at IMS.Controllers.PurchaseReturnController.PurchaseReturnReport(Int32 id)
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (3, N'System.Web.Mvc', NULL, N'The parameters dictionary contains a null entry for parameter ''detailId'' of non-nullable type ''System.Int64'' for method ''System.Web.Mvc.JsonResult GetTotalQuantity(Int64)'' in ''IMS.Controllers.SalesReturnController''. An optional parameter must be a reference type, a nullable type, or be declared as an optional parameter.
Parameter name: parameters', 14, N'admin', N'', N'   at System.Web.Mvc.ActionDescriptor.ExtractParameterFromDictionary(ParameterInfo parameterInfo, IDictionary`2 parameters, MethodInfo methodInfo)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (4, N'System.Web.Mvc', NULL, N'The parameters dictionary contains a null entry for parameter ''detailId'' of non-nullable type ''System.Int64'' for method ''System.Web.Mvc.JsonResult GetTotalQuantity(Int64)'' in ''IMS.Controllers.SalesReturnController''. An optional parameter must be a reference type, a nullable type, or be declared as an optional parameter.
Parameter name: parameters', 14, N'admin', N'', N'   at System.Web.Mvc.ActionDescriptor.ExtractParameterFromDictionary(ParameterInfo parameterInfo, IDictionary`2 parameters, MethodInfo methodInfo)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (5, N'System.Web.Mvc', NULL, N'The parameters dictionary contains a null entry for parameter ''invId'' of non-nullable type ''System.Int64'' for method ''System.Web.Mvc.JsonResult BindTempGrid(Int64)'' in ''IMS.Controllers.PurchaseReturnController''. An optional parameter must be a reference type, a nullable type, or be declared as an optional parameter.
Parameter name: parameters', 14, N'admin', N'', N'   at System.Web.Mvc.ActionDescriptor.ExtractParameterFromDictionary(ParameterInfo parameterInfo, IDictionary`2 parameters, MethodInfo methodInfo)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (6, N'System.Web.Mvc', NULL, N'The parameters dictionary contains a null entry for parameter ''invId'' of non-nullable type ''System.Int64'' for method ''System.Web.Mvc.JsonResult BindTempGrid(Int64)'' in ''IMS.Controllers.PurchaseReturnController''. An optional parameter must be a reference type, a nullable type, or be declared as an optional parameter.
Parameter name: parameters', 14, N'admin', N'', N'   at System.Web.Mvc.ActionDescriptor.ExtractParameterFromDictionary(ParameterInfo parameterInfo, IDictionary`2 parameters, MethodInfo methodInfo)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (7, N'IMS', NULL, N'Input string was not in a correct format.', 14, N'admin', N'', N'   at IMS.Controllers.PurchaseInvoiceController.AddEditPurchaseInvoice(PurchaseInvModel inv) in D:\IMS\IMS\Controllers\PurchaseInvoiceController.cs:line 93
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (8, N'IMS', NULL, N'Input string was not in a correct format.', 14, N'admin', N'', N'   at IMS.Controllers.PurchaseInvoiceController.AddEditPurchaseInvoice(PurchaseInvModel inv) in D:\IMS\IMS\Controllers\PurchaseInvoiceController.cs:line 93
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (9, N'mscorlib', NULL, N'Input string was not in a correct format.', 14, N'admin', N'', N'   at IMS.Controllers.PurchaseInvoiceController.AddEditPurchaseInvoice(PurchaseInvModel inv) in D:\IMS\IMS\Controllers\PurchaseInvoiceController.cs:line 93
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (10, N'IMS', NULL, N'Input string was not in a correct format.', 14, N'admin', N'', N'   at IMS.Controllers.PurchaseInvoiceController.AddEditPurchaseInvoice(PurchaseInvModel inv) in D:\IMS\IMS\Controllers\PurchaseInvoiceController.cs:line 93
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (11, N'IMS', NULL, N'String was not recognized as a valid DateTime.', 14, N'admin', N'', N'   at IMS.Controllers.PurchaseInvoiceController.AddEditPurchaseInvoice(PurchaseInvModel inv) in D:\IMS\IMS\Controllers\PurchaseInvoiceController.cs:line 93
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (12, N'System.Web.Mvc', NULL, N'The model item passed into the dictionary is of type ''System.Collections.Generic.List`1[IMS.DataContext.SupplierPayment]'', but this dictionary requires a model item of type ''System.Collections.Generic.IEnumerable`1[IMS.DataContext.CategoryMaster]''.', 14, N'admin', N'', N'   at System.Web.Mvc.ViewDataDictionary`1.SetModel(Object value)
   at System.Web.Mvc.ViewDataDictionary..ctor(ViewDataDictionary dictionary)
   at System.Web.Mvc.WebViewPage`1.SetViewData(ViewDataDictionary viewData)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (13, N'System.Web', NULL, N'Error executing child request for handler ''System.Web.Mvc.HttpHandlerUtil+ServerExecuteHttpHandlerAsyncWrapper''.', 14, N'admin', N'System.InvalidOperationException: Child actions are not allowed to perform redirect actions.
   at System.Web.Mvc.RedirectResult.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.<>c__DisplayClassa.<EndProcessRequest>b__9()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.<>c__DisplayClass4.<Wrap>b__3()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap[TResult](Func`1 func)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap(Action action)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)', N'   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.HttpServerUtilityWrapper.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.Mvc.Html.ChildActionExtensions.ActionHelper(HtmlHelper htmlHelper, String actionName, String controllerName, RouteValueDictionary routeValues, TextWriter textWriter)
   at System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper htmlHelper, String actionName, String controllerName)
   at ASP._Page_Views_SupplierPayment_Index_cshtml.Execute() in D:\IMS\IMS\Views\SupplierPayment\Index.cshtml:line 22
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (14, N'System.Web.Mvc', NULL, N'The model item passed into the dictionary is of type ''System.Collections.Generic.List`1[IMS.DataContext.SupplierPayment]'', but this dictionary requires a model item of type ''System.Collections.Generic.IEnumerable`1[IMS.DataContext.CategoryMaster]''.', 14, N'admin', N'', N'   at System.Web.Mvc.ViewDataDictionary`1.SetModel(Object value)
   at System.Web.Mvc.ViewDataDictionary..ctor(ViewDataDictionary dictionary)
   at System.Web.Mvc.WebViewPage`1.SetViewData(ViewDataDictionary viewData)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (15, N'System.Web', NULL, N'Error executing child request for handler ''System.Web.Mvc.HttpHandlerUtil+ServerExecuteHttpHandlerAsyncWrapper''.', 14, N'admin', N'System.InvalidOperationException: Child actions are not allowed to perform redirect actions.
   at System.Web.Mvc.RedirectResult.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.<>c__DisplayClassa.<EndProcessRequest>b__9()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.<>c__DisplayClass4.<Wrap>b__3()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap[TResult](Func`1 func)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap(Action action)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)', N'   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.HttpServerUtilityWrapper.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.Mvc.Html.ChildActionExtensions.ActionHelper(HtmlHelper htmlHelper, String actionName, String controllerName, RouteValueDictionary routeValues, TextWriter textWriter)
   at System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper htmlHelper, String actionName, String controllerName)
   at ASP._Page_Views_SupplierPayment_Index_cshtml.Execute() in D:\IMS\IMS\Views\SupplierPayment\Index.cshtml:line 22
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (16, N'System.Web.Mvc', NULL, N'The model item passed into the dictionary is of type ''System.Collections.Generic.List`1[IMS.DataContext.SupplierPayment]'', but this dictionary requires a model item of type ''System.Collections.Generic.IEnumerable`1[IMS.DataContext.CategoryMaster]''.', 14, N'admin', N'', N'   at System.Web.Mvc.ViewDataDictionary`1.SetModel(Object value)
   at System.Web.Mvc.ViewDataDictionary..ctor(ViewDataDictionary dictionary)
   at System.Web.Mvc.WebViewPage`1.SetViewData(ViewDataDictionary viewData)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (17, N'System.Web', NULL, N'Error executing child request for handler ''System.Web.Mvc.HttpHandlerUtil+ServerExecuteHttpHandlerAsyncWrapper''.', 14, N'admin', N'System.InvalidOperationException: Child actions are not allowed to perform redirect actions.
   at System.Web.Mvc.RedirectResult.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.<>c__DisplayClassa.<EndProcessRequest>b__9()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.<>c__DisplayClass4.<Wrap>b__3()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap[TResult](Func`1 func)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap(Action action)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)', N'   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.HttpServerUtilityWrapper.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.Mvc.Html.ChildActionExtensions.ActionHelper(HtmlHelper htmlHelper, String actionName, String controllerName, RouteValueDictionary routeValues, TextWriter textWriter)
   at System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper htmlHelper, String actionName, String controllerName)
   at ASP._Page_Views_SupplierPayment_Index_cshtml.Execute() in D:\IMS\IMS\Views\SupplierPayment\Index.cshtml:line 22
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (18, N'System.Web.Mvc', NULL, N'The model item passed into the dictionary is of type ''System.Collections.Generic.List`1[IMS.DataContext.SupplierPayment]'', but this dictionary requires a model item of type ''System.Collections.Generic.IEnumerable`1[IMS.DataContext.CategoryMaster]''.', 14, N'admin', N'', N'   at System.Web.Mvc.ViewDataDictionary`1.SetModel(Object value)
   at System.Web.Mvc.ViewDataDictionary..ctor(ViewDataDictionary dictionary)
   at System.Web.Mvc.WebViewPage`1.SetViewData(ViewDataDictionary viewData)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (19, N'System.Web', NULL, N'Error executing child request for handler ''System.Web.Mvc.HttpHandlerUtil+ServerExecuteHttpHandlerAsyncWrapper''.', 14, N'admin', N'System.InvalidOperationException: Child actions are not allowed to perform redirect actions.
   at System.Web.Mvc.RedirectResult.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.<>c__DisplayClassa.<EndProcessRequest>b__9()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.<>c__DisplayClass4.<Wrap>b__3()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap[TResult](Func`1 func)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap(Action action)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)', N'   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.HttpServerUtilityWrapper.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.Mvc.Html.ChildActionExtensions.ActionHelper(HtmlHelper htmlHelper, String actionName, String controllerName, RouteValueDictionary routeValues, TextWriter textWriter)
   at System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper htmlHelper, String actionName, String controllerName)
   at ASP._Page_Views_SupplierPayment_Index_cshtml.Execute() in D:\IMS\IMS\Views\SupplierPayment\Index.cshtml:line 22
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (20, N'System.Web.Mvc', NULL, N'The ViewData item that has the key ''SupplierName'' is of type ''System.Int32'' but must be of type ''IEnumerable<SelectListItem>''.', 14, N'admin', N'', N'   at System.Web.Mvc.Html.SelectExtensions.GetSelectData(HtmlHelper htmlHelper, String name)
   at System.Web.Mvc.Html.SelectExtensions.SelectInternal(HtmlHelper htmlHelper, ModelMetadata metadata, String optionLabel, String name, IEnumerable`1 selectList, Boolean allowMultiple, IDictionary`2 htmlAttributes)
   at System.Web.Mvc.Html.SelectExtensions.DropDownListFor[TModel,TProperty](HtmlHelper`1 htmlHelper, Expression`1 expression, IEnumerable`1 selectList, String optionLabel, IDictionary`2 htmlAttributes)
   at System.Web.Mvc.Html.SelectExtensions.DropDownListFor[TModel,TProperty](HtmlHelper`1 htmlHelper, Expression`1 expression, IEnumerable`1 selectList, String optionLabel, Object htmlAttributes)
   at ASP._Page_Views_SupplierPayment_AddEditSupplierPayment_cshtml.Execute() in D:\IMS\IMS\Views\SupplierPayment\AddEditSupplierPayment.cshtml:line 31
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (21, N'System.Web.Mvc', NULL, N'The ViewData item that has the key ''SupplierName'' is of type ''System.Int32'' but must be of type ''IEnumerable<SelectListItem>''.', 14, N'admin', N'', N'   at System.Web.Mvc.Html.SelectExtensions.GetSelectData(HtmlHelper htmlHelper, String name)
   at System.Web.Mvc.Html.SelectExtensions.SelectInternal(HtmlHelper htmlHelper, ModelMetadata metadata, String optionLabel, String name, IEnumerable`1 selectList, Boolean allowMultiple, IDictionary`2 htmlAttributes)
   at System.Web.Mvc.Html.SelectExtensions.DropDownListFor[TModel,TProperty](HtmlHelper`1 htmlHelper, Expression`1 expression, IEnumerable`1 selectList, String optionLabel, IDictionary`2 htmlAttributes)
   at System.Web.Mvc.Html.SelectExtensions.DropDownListFor[TModel,TProperty](HtmlHelper`1 htmlHelper, Expression`1 expression, IEnumerable`1 selectList, String optionLabel, Object htmlAttributes)
   at ASP._Page_Views_SupplierPayment_AddEditSupplierPayment_cshtml.Execute() in D:\IMS\IMS\Views\SupplierPayment\AddEditSupplierPayment.cshtml:line 31
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (22, N'IMS', NULL, N'An error occurred while executing the command definition. See the inner exception for details.', 14, N'admin', N'System.Data.SqlClient.SqlException (0x80131904): Invalid column name ''IsPosted''.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   at System.Data.SqlClient.SqlDataReader.get_MetaData()
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   at System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader(CommandBehavior behavior)
   at System.Data.Entity.Infrastructure.Interception.DbCommandDispatcher.<Reader>b__c(DbCommand t, DbCommandInterceptionContext`1 c)
   at System.Data.Entity.Infrastructure.Interception.InternalDispatcher`1.Dispatch[TTarget,TInterceptionContext,TResult](TTarget target, Func`3 operation, TInterceptionContext interceptionContext, Action`3 executing, Action`3 executed)
   at System.Data.Entity.Infrastructure.Interception.DbCommandDispatcher.Reader(DbCommand command, DbCommandInterceptionContext interceptionContext)
   at System.Data.Entity.Internal.InterceptableDbCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader(CommandBehavior behavior)
   at System.Data.Entity.Core.EntityClient.Internal.EntityCommandDefinition.ExecuteStoreCommands(EntityCommand entityCommand, CommandBehavior behavior)
ClientConnectionId:57e6046b-345b-4fa7-a258-af44989a004a
Error Number:207,State:1,Class:16', N'   at IMS.Controllers.SupplierPaymentController.SearchSupplierPayment() in D:\IMS\IMS\Controllers\SupplierPaymentController.cs:line 35
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (23, N'System.Web', NULL, N'Error executing child request for handler ''System.Web.Mvc.HttpHandlerUtil+ServerExecuteHttpHandlerAsyncWrapper''.', 14, N'admin', N'System.InvalidOperationException: Child actions are not allowed to perform redirect actions.
   at System.Web.Mvc.RedirectResult.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.<>c__DisplayClassa.<EndProcessRequest>b__9()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.<>c__DisplayClass4.<Wrap>b__3()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap[TResult](Func`1 func)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap(Action action)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)', N'   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.HttpServerUtilityWrapper.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.Mvc.Html.ChildActionExtensions.ActionHelper(HtmlHelper htmlHelper, String actionName, String controllerName, RouteValueDictionary routeValues, TextWriter textWriter)
   at System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper htmlHelper, String actionName, String controllerName)
   at ASP._Page_Views_SupplierPayment_Index_cshtml.Execute() in D:\IMS\IMS\Views\SupplierPayment\Index.cshtml:line 22
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (24, N'EntityFramework', NULL, N'An error occurred while executing the command definition. See the inner exception for details.', 14, N'admin', N'System.Data.SqlClient.SqlException (0x80131904): Invalid column name ''IsPosted''.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   at System.Data.SqlClient.SqlDataReader.get_MetaData()
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   at System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader(CommandBehavior behavior)
   at System.Data.Entity.Infrastructure.Interception.DbCommandDispatcher.<Reader>b__c(DbCommand t, DbCommandInterceptionContext`1 c)
   at System.Data.Entity.Infrastructure.Interception.InternalDispatcher`1.Dispatch[TTarget,TInterceptionContext,TResult](TTarget target, Func`3 operation, TInterceptionContext interceptionContext, Action`3 executing, Action`3 executed)
   at System.Data.Entity.Infrastructure.Interception.DbCommandDispatcher.Reader(DbCommand command, DbCommandInterceptionContext interceptionContext)
   at System.Data.Entity.Internal.InterceptableDbCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader(CommandBehavior behavior)
   at System.Data.Entity.Core.EntityClient.Internal.EntityCommandDefinition.ExecuteStoreCommands(EntityCommand entityCommand, CommandBehavior behavior)
ClientConnectionId:57e6046b-345b-4fa7-a258-af44989a004a
Error Number:207,State:1,Class:16', N'   at IMS.Controllers.SupplierPaymentController.SearchSupplierPayment() in D:\IMS\IMS\Controllers\SupplierPaymentController.cs:line 35
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (25, N'System.Web', NULL, N'Error executing child request for handler ''System.Web.Mvc.HttpHandlerUtil+ServerExecuteHttpHandlerAsyncWrapper''.', 14, N'admin', N'System.InvalidOperationException: Child actions are not allowed to perform redirect actions.
   at System.Web.Mvc.RedirectResult.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.<>c__DisplayClassa.<EndProcessRequest>b__9()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.<>c__DisplayClass4.<Wrap>b__3()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap[TResult](Func`1 func)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap(Action action)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)', N'   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.HttpServerUtilityWrapper.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.Mvc.Html.ChildActionExtensions.ActionHelper(HtmlHelper htmlHelper, String actionName, String controllerName, RouteValueDictionary routeValues, TextWriter textWriter)
   at System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper htmlHelper, String actionName, String controllerName)
   at ASP._Page_Views_SupplierPayment_Index_cshtml.Execute() in D:\IMS\IMS\Views\SupplierPayment\Index.cshtml:line 22
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (26, N'System.Web', NULL, N'D:\IMS\IMS\Views\SupplierPayment\_SearchSupplierPayment.cshtml(38): error CS0019: Operator ''=='' cannot be applied to operands of type ''string'' and ''int''', 14, N'admin', N'', N'   at System.Web.Compilation.AssemblyBuilder.Compile()
   at System.Web.Compilation.BuildProvidersCompiler.PerformBuild()
   at System.Web.Compilation.BuildManager.CompileWebFile(VirtualPath virtualPath)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultInternal(VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultWithNoAssert(HttpContext context, VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVirtualPathObjectFactory(VirtualPath virtualPath, HttpContext context, Boolean allowCrossApp, Boolean throwIfNotFound)
   at System.Web.Compilation.BuildManager.GetCompiledType(VirtualPath virtualPath)
   at System.Web.Compilation.BuildManager.GetCompiledType(String virtualPath)
   at System.Web.Mvc.BuildManagerWrapper.System.Web.Mvc.IBuildManager.GetCompiledType(String virtualPath)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (27, N'System.Web', NULL, N'Error executing child request for handler ''System.Web.Mvc.HttpHandlerUtil+ServerExecuteHttpHandlerAsyncWrapper''.', 14, N'admin', N'System.InvalidOperationException: Child actions are not allowed to perform redirect actions.
   at System.Web.Mvc.RedirectResult.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.<>c__DisplayClassa.<EndProcessRequest>b__9()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.<>c__DisplayClass4.<Wrap>b__3()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap[TResult](Func`1 func)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap(Action action)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)', N'   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.HttpServerUtilityWrapper.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.Mvc.Html.ChildActionExtensions.ActionHelper(HtmlHelper htmlHelper, String actionName, String controllerName, RouteValueDictionary routeValues, TextWriter textWriter)
   at System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper htmlHelper, String actionName, String controllerName)
   at ASP._Page_Views_SupplierPayment_Index_cshtml.Execute() in D:\IMS\IMS\Views\SupplierPayment\Index.cshtml:line 22
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (28, N'System.Web', NULL, N'D:\IMS\IMS\Views\SupplierPayment\_SearchSupplierPayment.cshtml(38): error CS0019: Operator ''=='' cannot be applied to operands of type ''string'' and ''int''', 14, N'admin', N'', N'   at System.Web.Compilation.AssemblyBuilder.Compile()
   at System.Web.Compilation.BuildProvidersCompiler.PerformBuild()
   at System.Web.Compilation.BuildManager.CompileWebFile(VirtualPath virtualPath)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultInternal(VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultWithNoAssert(HttpContext context, VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVirtualPathObjectFactory(VirtualPath virtualPath, HttpContext context, Boolean allowCrossApp, Boolean throwIfNotFound)
   at System.Web.Compilation.BuildManager.GetCompiledType(VirtualPath virtualPath)
   at System.Web.Compilation.BuildManager.GetCompiledType(String virtualPath)
   at System.Web.Mvc.BuildManagerWrapper.System.Web.Mvc.IBuildManager.GetCompiledType(String virtualPath)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (29, N'System.Web', NULL, N'Error executing child request for handler ''System.Web.Mvc.HttpHandlerUtil+ServerExecuteHttpHandlerAsyncWrapper''.', 14, N'admin', N'System.InvalidOperationException: Child actions are not allowed to perform redirect actions.
   at System.Web.Mvc.RedirectResult.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.<>c__DisplayClassa.<EndProcessRequest>b__9()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.<>c__DisplayClass4.<Wrap>b__3()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap[TResult](Func`1 func)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap(Action action)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)', N'   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.HttpServerUtilityWrapper.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.Mvc.Html.ChildActionExtensions.ActionHelper(HtmlHelper htmlHelper, String actionName, String controllerName, RouteValueDictionary routeValues, TextWriter textWriter)
   at System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper htmlHelper, String actionName, String controllerName)
   at ASP._Page_Views_SupplierPayment_Index_cshtml.Execute() in D:\IMS\IMS\Views\SupplierPayment\Index.cshtml:line 22
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (30, N'IMS', NULL, N'An error occurred while executing the command definition. See the inner exception for details.', 14, N'admin', N'System.Data.SqlClient.SqlException (0x80131904): Invalid object name ''dbo.CustomerPayments''.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   at System.Data.SqlClient.SqlDataReader.get_MetaData()
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   at System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader(CommandBehavior behavior)
   at System.Data.Entity.Infrastructure.Interception.DbCommandDispatcher.<Reader>b__c(DbCommand t, DbCommandInterceptionContext`1 c)
   at System.Data.Entity.Infrastructure.Interception.InternalDispatcher`1.Dispatch[TTarget,TInterceptionContext,TResult](TTarget target, Func`3 operation, TInterceptionContext interceptionContext, Action`3 executing, Action`3 executed)
   at System.Data.Entity.Infrastructure.Interception.DbCommandDispatcher.Reader(DbCommand command, DbCommandInterceptionContext interceptionContext)
   at System.Data.Entity.Internal.InterceptableDbCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader(CommandBehavior behavior)
   at System.Data.Entity.Core.EntityClient.Internal.EntityCommandDefinition.ExecuteStoreCommands(EntityCommand entityCommand, CommandBehavior behavior)
ClientConnectionId:33313607-cbf9-469e-bc07-07af2bff472f
Error Number:208,State:1,Class:16', N'   at IMS.Controllers.CustomerPaymentController.SearchCustomerPayment() in D:\IMS\IMS\Controllers\CustomerPaymentController.cs:line 36
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (31, N'System.Web', NULL, N'Error executing child request for handler ''System.Web.Mvc.HttpHandlerUtil+ServerExecuteHttpHandlerAsyncWrapper''.', 14, N'admin', N'System.InvalidOperationException: Child actions are not allowed to perform redirect actions.
   at System.Web.Mvc.RedirectResult.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.<>c__DisplayClassa.<EndProcessRequest>b__9()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.<>c__DisplayClass4.<Wrap>b__3()
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap[TResult](Func`1 func)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerWrapper.Wrap(Action action)
   at System.Web.Mvc.HttpHandlerUtil.ServerExecuteHttpHandlerAsyncWrapper.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)', N'   at System.Web.HttpServerUtility.ExecuteInternal(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage, VirtualPath path, VirtualPath filePath, String physPath, Exception error, String queryStringOverride)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm, Boolean setPreviousPage)
   at System.Web.HttpServerUtility.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.HttpServerUtilityWrapper.Execute(IHttpHandler handler, TextWriter writer, Boolean preserveForm)
   at System.Web.Mvc.Html.ChildActionExtensions.ActionHelper(HtmlHelper htmlHelper, String actionName, String controllerName, RouteValueDictionary routeValues, TextWriter textWriter)
   at System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper htmlHelper, String actionName, String controllerName)
   at ASP._Page_Views_CustomerPayment_Index_cshtml.Execute() in D:\IMS\IMS\Views\CustomerPayment\Index.cshtml:line 22
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (32, N'App_Web_m22w4yig', NULL, N'Object reference not set to an instance of an object.', 14, N'admin', N'', N'   at ASP._Page_Views_CustomerPayment_Index_cshtml.Execute() in D:\IMS\IMS\Views\CustomerPayment\Index.cshtml:line 32
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (33, N'App_Web_lrr3dt2z', NULL, N'Object reference not set to an instance of an object.', 14, N'admin', N'', N'   at ASP._Page_Views_SupplierPayment_Index_cshtml.Execute() in D:\IMS\IMS\Views\SupplierPayment\Index.cshtml:line 36
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (34, N'System.Web', NULL, N'D:\IMS\IMS\Views\SupplierPayment\PurchaseInvoiceReport.cshtml(59): error CS0103: The name ''PaidAmount'' does not exist in the current context', 14, N'admin', N'', N'   at System.Web.Compilation.AssemblyBuilder.Compile()
   at System.Web.Compilation.BuildProvidersCompiler.PerformBuild()
   at System.Web.Compilation.BuildManager.CompileWebFile(VirtualPath virtualPath)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultInternal(VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultWithNoAssert(HttpContext context, VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVirtualPathObjectFactory(VirtualPath virtualPath, HttpContext context, Boolean allowCrossApp, Boolean throwIfNotFound)
   at System.Web.Compilation.BuildManager.GetCompiledType(VirtualPath virtualPath)
   at System.Web.Compilation.BuildManager.GetCompiledType(String virtualPath)
   at System.Web.Mvc.BuildManagerWrapper.System.Web.Mvc.IBuildManager.GetCompiledType(String virtualPath)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (35, N'.Net SqlClient Data Provider', NULL, N'Invalid column name ''SuppilerId''.', 14, N'admin', N'', N'   at IMS.Controllers.SupplierPaymentController.PurchaseInvoiceReport(Int32 supplierId, String FromDate, String ToDate, String supplierName) in D:\IMS\IMS\Controllers\SupplierPaymentController.cs:line 197
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (36, N'.Net SqlClient Data Provider', NULL, N'Invalid column name ''SuppilerId''.', 14, N'admin', N'', N'   at IMS.Controllers.SupplierPaymentController.PurchaseInvoiceReport(Int32 supplierId, String FromDate, String ToDate, String supplierName)
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (37, N'System.Data', NULL, N'Column ''PaymentAmount'' does not belong to table Table.', 14, N'admin', N'', N'   at System.Data.DataRow.GetDataColumn(String columnName)
   at System.Data.DataRow.get_Item(String columnName)
   at CallSite.Target(Closure , CallSite , Object , String )
   at System.Dynamic.UpdateDelegates.UpdateAndExecute2[T0,T1,TRet](CallSite site, T0 arg0, T1 arg1)
   at ASP._Page_Views_CustomerPayment_SaleInvoiceReport_cshtml.Execute() in D:\IMS\IMS\Views\CustomerPayment\SaleInvoiceReport.cshtml:line 44
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (38, N'System.Web.Mvc', NULL, N'The ViewData item that has the key ''CategoryId'' is of type ''System.Int64'' but must be of type ''IEnumerable<SelectListItem>''.', 14, N'admin', N'', N'   at System.Web.Mvc.Html.SelectExtensions.GetSelectData(HtmlHelper htmlHelper, String name)
   at System.Web.Mvc.Html.SelectExtensions.SelectInternal(HtmlHelper htmlHelper, ModelMetadata metadata, String optionLabel, String name, IEnumerable`1 selectList, Boolean allowMultiple, IDictionary`2 htmlAttributes)
   at System.Web.Mvc.Html.SelectExtensions.DropDownListFor[TModel,TProperty](HtmlHelper`1 htmlHelper, Expression`1 expression, IEnumerable`1 selectList, String optionLabel, IDictionary`2 htmlAttributes)
   at System.Web.Mvc.Html.SelectExtensions.DropDownListFor[TModel,TProperty](HtmlHelper`1 htmlHelper, Expression`1 expression, IEnumerable`1 selectList, String optionLabel, Object htmlAttributes)
   at ASP._Page_Views_StockOut_AddEditStockOut_cshtml.Execute() in D:\IMS\IMS\Views\StockOut\AddEditStockOut.cshtml:line 69
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (39, N'System.Web.Mvc', NULL, N'The ViewData item that has the key ''CategoryId'' is of type ''System.Int64'' but must be of type ''IEnumerable<SelectListItem>''.', 14, N'admin', N'', N'   at System.Web.Mvc.Html.SelectExtensions.GetSelectData(HtmlHelper htmlHelper, String name)
   at System.Web.Mvc.Html.SelectExtensions.SelectInternal(HtmlHelper htmlHelper, ModelMetadata metadata, String optionLabel, String name, IEnumerable`1 selectList, Boolean allowMultiple, IDictionary`2 htmlAttributes)
   at System.Web.Mvc.Html.SelectExtensions.DropDownListFor[TModel,TProperty](HtmlHelper`1 htmlHelper, Expression`1 expression, IEnumerable`1 selectList, String optionLabel, IDictionary`2 htmlAttributes)
   at System.Web.Mvc.Html.SelectExtensions.DropDownListFor[TModel,TProperty](HtmlHelper`1 htmlHelper, Expression`1 expression, IEnumerable`1 selectList, String optionLabel, Object htmlAttributes)
   at ASP._Page_Views_StockOut_AddEditStockOut_cshtml.Execute() in D:\IMS\IMS\Views\StockOut\AddEditStockOut.cshtml:line 69
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (40, N'System.Web.Mvc', NULL, N'The ViewData item that has the key ''CategoryId'' is of type ''System.Int64'' but must be of type ''IEnumerable<SelectListItem>''.', 14, N'admin', N'', N'   at System.Web.Mvc.Html.SelectExtensions.GetSelectData(HtmlHelper htmlHelper, String name)
   at System.Web.Mvc.Html.SelectExtensions.SelectInternal(HtmlHelper htmlHelper, ModelMetadata metadata, String optionLabel, String name, IEnumerable`1 selectList, Boolean allowMultiple, IDictionary`2 htmlAttributes)
   at System.Web.Mvc.Html.SelectExtensions.DropDownListFor[TModel,TProperty](HtmlHelper`1 htmlHelper, Expression`1 expression, IEnumerable`1 selectList, String optionLabel, IDictionary`2 htmlAttributes)
   at System.Web.Mvc.Html.SelectExtensions.DropDownListFor[TModel,TProperty](HtmlHelper`1 htmlHelper, Expression`1 expression, IEnumerable`1 selectList, String optionLabel, Object htmlAttributes)
   at ASP._Page_Views_StockIn_AddEditStockInMaster_cshtml.Execute() in D:\IMS\IMS\Views\StockIn\AddEditStockInMaster.cshtml:line 70
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.RunPage()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (41, N'.Net SqlClient Data Provider', NULL, N'Invalid column name ''SuppilerId''.', 14, N'admin', N'', N'   at IMS.Business.SupplierPaymentManager.GetSupplierDetailById(Int64 id) in D:\IMS\IMS\Business\SupplierPaymentManager.cs:line 210
   at IMS.Controllers.SupplierPaymentController.GetSupplierDetail(Int64 id) in D:\IMS\IMS\Controllers\SupplierPaymentController.cs:line 122
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
INSERT [dbo].[LogTables] ([Id], [Source], [Helpline], [Message], [UserId], [UserName], [InnerException], [StackTrace]) VALUES (42, N'.Net SqlClient Data Provider', NULL, N'Invalid column name ''SuppilerId''.', 14, N'admin', N'', N'   at IMS.Controllers.CustomerPaymentController.PaymentSummaryReport(Int32 customerId, String FromDate, String ToDate, String customerName) in D:\IMS\IMS\Controllers\CustomerPaymentController.cs:line 278
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
SET IDENTITY_INSERT [dbo].[LogTables] OFF
/****** Object:  Table [dbo].[CustomerPayment]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerPayment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SaleInvoiceId] [int] NULL,
	[CustomerId] [int] NOT NULL,
	[PaymentAmount] [decimal](18, 2) NOT NULL,
	[Description] [varchar](50) NULL,
	[PaymentDate] [datetime] NOT NULL,
	[IsDeleted] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[IsPosted] [int] NULL,
	[IncrementNo] [int] NOT NULL,
	[PaymentNo] [varchar](50) NOT NULL,
	[TotalDue] [decimal](18, 2) NOT NULL,
	[TotalPaid] [decimal](18, 2) NOT NULL,
	[FinancialId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
 CONSTRAINT [PK_CustomerPayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerPayment] ON
INSERT [dbo].[CustomerPayment] ([Id], [SaleInvoiceId], [CustomerId], [PaymentAmount], [Description], [PaymentDate], [IsDeleted], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsPosted], [IncrementNo], [PaymentNo], [TotalDue], [TotalPaid], [FinancialId], [StoreId]) VALUES (1, NULL, 8, CAST(15000.00 AS Decimal(18, 2)), N'Demo', CAST(0x0000ACF700000000 AS DateTime), 0, CAST(0x0000ACF70005D6DA AS DateTime), 14, CAST(0x0000ACF700000000 AS DateTime), 14, 1, 1, N'CPN1001', CAST(60500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[CustomerPayment] ([Id], [SaleInvoiceId], [CustomerId], [PaymentAmount], [Description], [PaymentDate], [IsDeleted], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsPosted], [IncrementNo], [PaymentNo], [TotalDue], [TotalPaid], [FinancialId], [StoreId]) VALUES (2, NULL, 8, CAST(5500.00 AS Decimal(18, 2)), N'demo', CAST(0x0000ACF700000000 AS DateTime), 0, CAST(0x0000ACF7015A58F1 AS DateTime), 14, CAST(0x0000ACFA00000000 AS DateTime), 14, 1, 2, N'CPN1002', CAST(60500.00 AS Decimal(18, 2)), CAST(15000.00 AS Decimal(18, 2)), 1, 1)
SET IDENTITY_INSERT [dbo].[CustomerPayment] OFF
/****** Object:  Table [dbo].[CustomerMaster]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](max) NOT NULL,
	[ContactNumber] [nvarchar](max) NOT NULL,
	[EmailId] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[PanNumber] [nvarchar](max) NULL,
	[IsActive] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[OpeningBalance] [decimal](18, 2) NULL,
 CONSTRAINT [PK_dbo.CustomerMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CustomerMaster] ON
INSERT [dbo].[CustomerMaster] ([Id], [CustomerName], [ContactNumber], [EmailId], [Address], [PanNumber], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [OpeningBalance]) VALUES (3, N'Satya Narayan', N'6521411412', N'tihori@gmail.com', N'11 Demo Demo Test', NULL, N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL, CAST(5000.00 AS Decimal(18, 2)))
INSERT [dbo].[CustomerMaster] ([Id], [CustomerName], [ContactNumber], [EmailId], [Address], [PanNumber], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [OpeningBalance]) VALUES (4, N'Azimuddin Chippa', N'9554522145', N'Nama@yahoo.com', N'145, faruq e aazam, Mullatalai Udaipur(Raj)', NULL, N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL, CAST(6000.00 AS Decimal(18, 2)))
INSERT [dbo].[CustomerMaster] ([Id], [CustomerName], [ContactNumber], [EmailId], [Address], [PanNumber], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [OpeningBalance]) VALUES (5, N'Kamlesh Chauhan', N'7541411145', N'Pratap@yahoo.com', N'145 Solanki Bhawan katmandu Nepal', NULL, N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[CustomerMaster] ([Id], [CustomerName], [ContactNumber], [EmailId], [Address], [PanNumber], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [OpeningBalance]) VALUES (6, N'Hakim Khan', N'6588547458', N'Hakim@gmail.com', N'11 Demo Demo Test', NULL, N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL, CAST(4000.00 AS Decimal(18, 2)))
INSERT [dbo].[CustomerMaster] ([Id], [CustomerName], [ContactNumber], [EmailId], [Address], [PanNumber], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [OpeningBalance]) VALUES (7, N'Mukesh Kumar Garg', N'8555411121', N'Muku@gmail.com', N'11 Demo Demo Test', NULL, N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, CAST(0x0000AB9400000000 AS DateTime), 9, CAST(7000.00 AS Decimal(18, 2)))
INSERT [dbo].[CustomerMaster] ([Id], [CustomerName], [ContactNumber], [EmailId], [Address], [PanNumber], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [OpeningBalance]) VALUES (8, N'Snehalata Joshi', N'8521441257', N'Snehalata@yahoo.com', N'154, Kalaji goraji, udaipur (Raj.)', NULL, N'Y', N'Demo', CAST(0x0000ACF600000000 AS DateTime), 14, NULL, NULL, CAST(60000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[CustomerMaster] OFF
/****** Object:  Table [dbo].[CategoryMaster]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
	[IsActive] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
 CONSTRAINT [PK_dbo.CategoryMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CategoryMaster] ON
INSERT [dbo].[CategoryMaster] ([Id], [CategoryName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (8, N'Injection', N'Y', N'Inj', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[CategoryMaster] ([Id], [CategoryName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (9, N'Tablet', N'Y', N'Tbl', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[CategoryMaster] ([Id], [CategoryName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10, N'Syrup', N'Y', N'Syrup', CAST(0x0000AB9400000000 AS DateTime), 9, CAST(0x0000AB9400000000 AS DateTime), 9)
INSERT [dbo].[CategoryMaster] ([Id], [CategoryName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (11, N'Drop', N'Y', N'Drop', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[CategoryMaster] ([Id], [CategoryName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (12, N'Powder', N'Y', N'Powder', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[CategoryMaster] ([Id], [CategoryName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (13, N'Other', N'Y', N'Demo', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[CategoryMaster] ([Id], [CategoryName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (14, N'Sprit', N'Y', N'Strip', CAST(0x0000ACF400000000 AS DateTime), 14, NULL, NULL)
INSERT [dbo].[CategoryMaster] ([Id], [CategoryName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (15, N'Mask', N'Y', N'Mask', CAST(0x0000ACF600000000 AS DateTime), 14, NULL, NULL)
SET IDENTITY_INSERT [dbo].[CategoryMaster] OFF
/****** Object:  Table [dbo].[BrandMaster]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrandMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BranchName] [nvarchar](max) NOT NULL,
	[IsActive] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
 CONSTRAINT [PK_dbo.BrandMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BrandMaster] ON
INSERT [dbo].[BrandMaster] ([Id], [BranchName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (15, N'Cipla', N'Y', N'Cipla', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[BrandMaster] ([Id], [BranchName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (16, N'Mankind', N'Y', N'Mankind', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[BrandMaster] ([Id], [BranchName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (17, N'Nestle', N'Y', N'Nestle', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[BrandMaster] ([Id], [BranchName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (18, N'Bio Tech', N'Y', N'Bio', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[BrandMaster] ([Id], [BranchName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (19, N'Bio Cone', N'Y', N'Cone', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[BrandMaster] ([Id], [BranchName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (20, N'Miraj', N'Y', N'Miraj', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[BrandMaster] ([Id], [BranchName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (21, N'Uni Lever', N'Y', N'Uni Lever', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[BrandMaster] ([Id], [BranchName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (22, N'Dabur', N'Y', N'Dabur', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[BrandMaster] ([Id], [BranchName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (23, N'Patanjali', N'Y', N'Patanjali', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[BrandMaster] ([Id], [BranchName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (24, N'Lupihaler', N'Y', N'Lupihaler', CAST(0x0000AB9400000000 AS DateTime), 9, NULL, NULL)
INSERT [dbo].[BrandMaster] ([Id], [BranchName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (25, N'Contras', N'Y', N'Contras', CAST(0x0000AC1200000000 AS DateTime), 14, NULL, NULL)
INSERT [dbo].[BrandMaster] ([Id], [BranchName], [IsActive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (27, N'Hamdard', N'Y', N'Hamdard', CAST(0x0000ACF600000000 AS DateTime), 14, NULL, NULL)
SET IDENTITY_INSERT [dbo].[BrandMaster] OFF
/****** Object:  Table [dbo].[AttributeMaster]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AttributeName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
 CONSTRAINT [PK_dbo.AttributeMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AttributeMaster] ON
INSERT [dbo].[AttributeMaster] ([Id], [AttributeName], [Description], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1, N'Demo ', N'Demo', N'Y', CAST(0x0000ABA100000000 AS DateTime), 14, NULL, NULL)
INSERT [dbo].[AttributeMaster] ([Id], [AttributeName], [Description], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (2, N'Demo 1', N'Demo 1', N'Y', CAST(0x0000ABA100000000 AS DateTime), 14, NULL, NULL)
INSERT [dbo].[AttributeMaster] ([Id], [AttributeName], [Description], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (3, N'Demo 2', N'Demo 2', N'Y', CAST(0x0000ABA100000000 AS DateTime), 14, NULL, NULL)
INSERT [dbo].[AttributeMaster] ([Id], [AttributeName], [Description], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (4, N'D3', N'D3', N'Y', CAST(0x0000ACF600000000 AS DateTime), 14, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AttributeMaster] OFF
/****** Object:  Table [dbo].[AttributeDetailMaster]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeDetailMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DetailName] [nvarchar](max) NULL,
	[IsAcive] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[AttributeId] [bigint] NULL,
 CONSTRAINT [PK_dbo.AttributeDetailMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AttributeDetailMaster] ON
INSERT [dbo].[AttributeDetailMaster] ([Id], [DetailName], [IsAcive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [AttributeId]) VALUES (1, N'Demo', N'Y', N'Demo', CAST(0x0000ABA100000000 AS DateTime), 14, NULL, NULL, 1)
INSERT [dbo].[AttributeDetailMaster] ([Id], [DetailName], [IsAcive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [AttributeId]) VALUES (2, N'Demo 1', N'Y', N'Demo 1', CAST(0x0000ABA100000000 AS DateTime), 14, NULL, NULL, 2)
INSERT [dbo].[AttributeDetailMaster] ([Id], [DetailName], [IsAcive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [AttributeId]) VALUES (3, N'Demo 2', N'Y', N'Demo 2', CAST(0x0000ABA100000000 AS DateTime), 14, NULL, NULL, 3)
INSERT [dbo].[AttributeDetailMaster] ([Id], [DetailName], [IsAcive], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [AttributeId]) VALUES (4, N'D3', N'Y', N'Demo', CAST(0x0000ACF600000000 AS DateTime), 14, NULL, NULL, 4)
SET IDENTITY_INSERT [dbo].[AttributeDetailMaster] OFF
/****** Object:  Table [dbo].[Ac_Payment_Detail]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ac_Payment_Detail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Invoice_Id] [bigint] NOT NULL,
	[Amount] [decimal](10, 2) NULL,
	[Description] [nvarchar](max) NULL,
	[Voucher_Type] [nvarchar](50) NULL,
	[Invoice_Type] [nvarchar](50) NULL,
	[Created_On] [datetime] NULL,
	[Created_By] [bigint] NULL,
	[Modified_On] [datetime] NULL,
	[Modified_By] [bigint] NULL,
 CONSTRAINT [PK_Ac_Payment_Detail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ac_Account_Detail]    Script Date: 06/05/2021 18:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ac_Account_Detail](
	[Id] [bigint] NOT NULL,
	[Invoice_Id] [bigint] NOT NULL,
	[Invoice_Type] [nvarchar](50) NULL,
	[Return_Id] [bigint] NULL,
	[Created_On] [datetime] NULL,
	[Created_By] [bigint] NULL,
	[Modified_On] [datetime] NULL,
	[Modified_By] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Default [DF__ProductMa__HasBa__403A8C7D]    Script Date: 06/05/2021 18:27:20 ******/
ALTER TABLE [dbo].[ProductMasterHeader] ADD  DEFAULT ((0)) FOR [HasBatchNumber]
GO
