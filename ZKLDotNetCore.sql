USE [master]
GO
/****** Object:  Database [ZKLDotNetCore]    Script Date: 4/24/2024 8:08:40 AM ******/
CREATE DATABASE [ZKLDotNetCore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ZKLDotNetCore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ZKLDotNetCore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ZKLDotNetCore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ZKLDotNetCore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ZKLDotNetCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ZKLDotNetCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ZKLDotNetCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ZKLDotNetCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ZKLDotNetCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ZKLDotNetCore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ZKLDotNetCore] SET  MULTI_USER 
GO
ALTER DATABASE [ZKLDotNetCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ZKLDotNetCore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ZKLDotNetCore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ZKLDotNetCore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ZKLDotNetCore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ZKLDotNetCore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ZKLDotNetCore] SET QUERY_STORE = ON
GO
ALTER DATABASE [ZKLDotNetCore] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ZKLDotNetCore]
GO
/****** Object:  Table [dbo].[tbl_blog]    Script Date: 4/24/2024 8:08:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [varchar](50) NOT NULL,
	[BlogAuthor] [varchar](50) NOT NULL,
	[BlogContent] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_blog] ON 

INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1, N'test title1', N'test author1', N'test content1')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (3, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (4, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (5, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (6, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (7, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (8, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (9, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (10, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (11, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (12, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (13, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (14, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (15, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (16, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (17, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (18, N'title', N'author', N'content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (19, N'title', N'author', N'content')
INSERT [dbo].[tbl_blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (23, N'new title', N'new author', N'new content')
SET IDENTITY_INSERT [dbo].[tbl_blog] OFF
GO
USE [master]
GO
ALTER DATABASE [ZKLDotNetCore] SET  READ_WRITE 
GO
