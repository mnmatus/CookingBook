USE [master]
GO
/****** Object:  Database [CookingBook]    Script Date: 11/28/2018 6:27:08 PM ******/
CREATE DATABASE [CookingBook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CookingBook', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\CookingBook.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CookingBook_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\CookingBook_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CookingBook] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CookingBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CookingBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CookingBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CookingBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CookingBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CookingBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [CookingBook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CookingBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CookingBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CookingBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CookingBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CookingBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CookingBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CookingBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CookingBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CookingBook] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CookingBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CookingBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CookingBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CookingBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CookingBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CookingBook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CookingBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CookingBook] SET RECOVERY FULL 
GO
ALTER DATABASE [CookingBook] SET  MULTI_USER 
GO
ALTER DATABASE [CookingBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CookingBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CookingBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CookingBook] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CookingBook] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CookingBook', N'ON'
GO
ALTER DATABASE [CookingBook] SET QUERY_STORE = OFF
GO
USE [CookingBook]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CookingBook]
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 11/28/2018 6:27:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](1000) NOT NULL,
	[IsChecked] [bit] NULL,
	[RecipeId] [int] NOT NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipe]    Script Date: 11/28/2018 6:27:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/28/2018 6:27:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ingredient] ON 
GO
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (17, N'aaaaa', 1, 2)
GO
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (18, N'bbbbb', 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Ingredient] OFF
GO
SET IDENTITY_INSERT [dbo].[Recipe] ON 
GO
INSERT [dbo].[Recipe] ([Id], [Name], [UserId]) VALUES (1, N'sasaw', 1)
GO
INSERT [dbo].[Recipe] ([Id], [Name], [UserId]) VALUES (2, N'chickenx', 1)
GO
SET IDENTITY_INSERT [dbo].[Recipe] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [UserName], [Password], [Guid]) VALUES (1, N'mnmatus', N'aaaaaa', N'4698cffa-2d21-4e08-80fb-c1fc08ecdef7')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Ingredient]  WITH CHECK ADD  CONSTRAINT [FK_Ingredient_Recipe] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipe] ([Id])
GO
ALTER TABLE [dbo].[Ingredient] CHECK CONSTRAINT [FK_Ingredient_Recipe]
GO
ALTER TABLE [dbo].[Recipe]  WITH CHECK ADD  CONSTRAINT [FK_Recipe_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Recipe] CHECK CONSTRAINT [FK_Recipe_User]
GO
USE [master]
GO
ALTER DATABASE [CookingBook] SET  READ_WRITE 
GO
