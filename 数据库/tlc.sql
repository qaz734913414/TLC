USE [master]
GO
/****** Object:  Database [TLC]    Script Date: 2017/11/12 23:57:37 ******/
CREATE DATABASE [TLC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TLC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER2\MSSQL\DATA\TLC.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TLC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER2\MSSQL\DATA\TLC_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TLC] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TLC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TLC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TLC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TLC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TLC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TLC] SET ARITHABORT OFF 
GO
ALTER DATABASE [TLC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TLC] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TLC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TLC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TLC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TLC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TLC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TLC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TLC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TLC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TLC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TLC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TLC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TLC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TLC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TLC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TLC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TLC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TLC] SET RECOVERY FULL 
GO
ALTER DATABASE [TLC] SET  MULTI_USER 
GO
ALTER DATABASE [TLC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TLC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TLC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TLC] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TLC', N'ON'
GO
USE [TLC]
GO
/****** Object:  Table [dbo].[Animal_Info]    Script Date: 2017/11/12 23:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animal_Info](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](2) NOT NULL,
	[Globe] [nvarchar](500) NOT NULL,
	[Operation_Year] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUID] [nvarchar](50) NOT NULL,
	[EditTime] [datetime] NULL,
	[EditUID] [nvarchar](50) NULL,
	[IsDelete] [tinyint] NOT NULL,
	[IsEnable] [tinyint] NOT NULL,
 CONSTRAINT [PK_Animal_Info] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Award_Public]    Script Date: 2017/11/12 23:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award_Public](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[PrizeContent] [nvarchar](50) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[CloseTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[IsCompleate] [tinyint] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUID] [nvarchar](50) NOT NULL,
	[EditTime] [datetime] NULL,
	[EditUID] [nvarchar](50) NULL,
	[IsDelete] [tinyint] NOT NULL,
	[IsEnable] [tinyint] NOT NULL,
 CONSTRAINT [PK_Prize_Public] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Detail]    Script Date: 2017/11/12 23:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Globe] [nvarchar](500) NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreateUID] [nvarchar](50) NOT NULL,
	[EditTime] [datetime] NULL,
	[EditUID] [nvarchar](50) NULL,
	[IsDelete] [tinyint] NOT NULL,
	[IsEnable] [tinyint] NOT NULL,
 CONSTRAINT [PK_Detail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Globe]    Script Date: 2017/11/12 23:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Globe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](10) NULL,
	[Color] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUID] [nvarchar](50) NOT NULL,
	[EditTime] [datetime] NULL,
	[EditUID] [nvarchar](50) NULL,
	[IsDelete] [tinyint] NOT NULL,
	[IsEnable] [tinyint] NOT NULL,
 CONSTRAINT [PK_Globe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Globe_Clue]    Script Date: 2017/11/12 23:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Globe_Clue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Clue] [nvarchar](500) NULL,
	[Pay] [nvarchar](500) NULL,
	[Clue2] [nvarchar](500) NULL,
	[Pay2] [nvarchar](500) NULL,
	[Limit_Max] [int] NOT NULL,
	[Limit_Min] [int] NOT NULL,
	[First_Type] [int] NOT NULL,
	[Second_Type] [int] NOT NULL,
	[First_Name] [nvarchar](200) NULL,
	[Second_Name] [nvarchar](200) NULL,
	[Return_Pay] [money] NOT NULL,
	[Return_Pay2] [money] NOT NULL,
	[Sort] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUID] [nvarchar](50) NOT NULL,
	[EditTime] [datetime] NULL,
	[EditUID] [nvarchar](50) NULL,
	[IsDelete] [tinyint] NOT NULL,
	[IsEnable] [tinyint] NOT NULL,
 CONSTRAINT [PK_Globe_Clue_1] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MoneyLog]    Script Date: 2017/11/12 23:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoneyLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[O_Content] [nvarchar](1000) NOT NULL,
	[O_Money] [money] NOT NULL,
	[UserID] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Type] [tinyint] NOT NULL,
	[OperationType] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUID] [nvarchar](50) NOT NULL,
	[EditTime] [datetime] NULL,
	[EditUID] [nvarchar](50) NULL,
	[IsDelete] [tinyint] NOT NULL,
	[IsEnable] [tinyint] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Operation_Record]    Script Date: 2017/11/12 23:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operation_Record](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AwardCode] [int] NULL,
	[ClueCode] [int] NULL,
	[UserID] [nvarchar](50) NOT NULL,
	[Buy_Content] [text] NULL,
	[Buy_Content2] [text] NULL,
	[UnitPrice] [int] NOT NULL,
	[BuyPayReturn] [text] NULL,
	[BuyPayReturn2] [text] NULL,
	[MinPayReturn] [money] NOT NULL,
	[MaxPayReturn] [money] NOT NULL,
	[Using_Money] [money] NOT NULL,
	[Get_Money] [money] NOT NULL,
	[Araw_ReturnMoney] [money] NOT NULL,
	[Araw_RetrunContent] [nvarchar](500) NOT NULL,
	[Return_Money] [money] NOT NULL,
	[IsWin] [int] NOT NULL,
	[Operation_Time] [datetime] NOT NULL,
	[PayUID] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUID] [nvarchar](50) NOT NULL,
	[EditTime] [datetime] NULL,
	[EditUID] [nvarchar](50) NULL,
	[IsDelete] [tinyint] NOT NULL,
	[IsEnable] [tinyint] NOT NULL,
 CONSTRAINT [PK_operation_record] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Size_Six]    Script Date: 2017/11/12 23:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size_Six](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Globe] [nvarchar](500) NOT NULL,
	[Award_Globe] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUID] [nvarchar](50) NOT NULL,
	[EditTime] [datetime] NULL,
	[EditUID] [nvarchar](50) NULL,
	[IsDelete] [tinyint] NOT NULL,
	[IsEnable] [tinyint] NOT NULL,
 CONSTRAINT [PK_Size6] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Size_Special]    Script Date: 2017/11/12 23:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size_Special](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Globe] [nvarchar](500) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUID] [nvarchar](50) NOT NULL,
	[EditTime] [datetime] NULL,
	[EditUID] [nvarchar](50) NULL,
	[IsDelete] [tinyint] NOT NULL,
	[IsEnable] [tinyint] NOT NULL,
 CONSTRAINT [PK_Size_Special] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Size_SpecialNormal]    Script Date: 2017/11/12 23:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size_SpecialNormal](
	[Id] [int] NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Globe] [nvarchar](500) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUID] [nvarchar](50) NOT NULL,
	[EditTime] [datetime] NULL,
	[EditUID] [nvarchar](50) NULL,
	[IsDelete] [tinyint] NOT NULL,
	[IsEnable] [tinyint] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Size_Sum]    Script Date: 2017/11/12 23:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size_Sum](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Globe] [nvarchar](500) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUID] [nvarchar](50) NOT NULL,
	[EditTime] [datetime] NULL,
	[EditUID] [nvarchar](50) NULL,
	[IsDelete] [tinyint] NOT NULL,
	[IsEnable] [tinyint] NOT NULL,
 CONSTRAINT [PK_Size_Sum] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2017/11/12 23:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Salt] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Money] [money] NOT NULL,
	[Role] [int] NOT NULL,
	[EnableTime] [datetime] NOT NULL,
	[Remarks] [nvarchar](500) NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUID] [nvarchar](50) NOT NULL,
	[EditTime] [datetime] NULL,
	[EditUID] [nvarchar](50) NULL,
	[IsDelete] [tinyint] NOT NULL,
	[IsEnable] [tinyint] NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wave]    Script Date: 2017/11/12 23:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wave](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Globe] [nvarchar](500) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUID] [nvarchar](50) NOT NULL,
	[EditTime] [datetime] NULL,
	[EditUID] [nvarchar](50) NULL,
	[IsDelete] [tinyint] NOT NULL,
	[IsEnable] [tinyint] NOT NULL,
 CONSTRAINT [PK_Wave] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Animal_Info] ON 

INSERT [dbo].[Animal_Info] ([Id], [Code], [Name], [Globe], [Operation_Year], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (1, 1, N'鼠', N'10,22,34,46', 2017, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Animal_Info] ([Id], [Code], [Name], [Globe], [Operation_Year], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (2, 2, N'牛', N'9,21,33,45', 2017, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Animal_Info] ([Id], [Code], [Name], [Globe], [Operation_Year], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (3, 3, N'虎', N'8,20,32,44', 2017, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Animal_Info] ([Id], [Code], [Name], [Globe], [Operation_Year], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (4, 4, N'兔', N'7,19,31,43', 2017, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Animal_Info] ([Id], [Code], [Name], [Globe], [Operation_Year], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (5, 5, N'龙', N'6,18,30,42', 2017, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Animal_Info] ([Id], [Code], [Name], [Globe], [Operation_Year], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (6, 6, N'蛇', N'5,17,29,41', 2017, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Animal_Info] ([Id], [Code], [Name], [Globe], [Operation_Year], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (7, 7, N'马', N'4,16,28,40', 2017, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Animal_Info] ([Id], [Code], [Name], [Globe], [Operation_Year], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (8, 8, N'羊', N'3,15,27,39', 2017, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Animal_Info] ([Id], [Code], [Name], [Globe], [Operation_Year], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (9, 9, N'猴', N'2,14,26,38', 2017, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Animal_Info] ([Id], [Code], [Name], [Globe], [Operation_Year], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (10, 10, N'鸡', N'1,13,25,37,49', 2017, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Animal_Info] ([Id], [Code], [Name], [Globe], [Operation_Year], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (11, 11, N'狗', N'12,24,36,48', 2017, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Animal_Info] ([Id], [Code], [Name], [Globe], [Operation_Year], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (12, 12, N'猪', N'11,23,35,47', 2017, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Animal_Info] OFF
SET IDENTITY_INSERT [dbo].[Award_Public] ON 

INSERT [dbo].[Award_Public] ([Id], [Code], [Name], [Year], [PrizeContent], [StartTime], [CloseTime], [EndTime], [IsCompleate], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (3, 10, 1, 2017, N'1,7,13,36,25,8,49', CAST(0x0000A81E0181E510 AS DateTime), CAST(0x0000A82300000000 AS DateTime), CAST(0x0000A82401557C0D AS DateTime), 0, CAST(0x0000A81E01816F12 AS DateTime), N'admin', NULL, N'admin', 0, 0)
SET IDENTITY_INSERT [dbo].[Award_Public] OFF
SET IDENTITY_INSERT [dbo].[Detail] ON 

INSERT [dbo].[Detail] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (1, 1, N'1尾', N'1,11,21,31,41', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Detail] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (2, 2, N'2尾', N'2,12,22,32,42', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Detail] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (3, 3, N'3尾', N'3,13,23,33,43', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Detail] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (4, 4, N'4尾', N'4,14,24,34,44', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Detail] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (5, 5, N'5尾', N'5,15,25,35,45', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Detail] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (6, 6, N'6尾', N'6,16,26,36,46', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Detail] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (7, 7, N'7尾', N'7,17,27,37,47', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Detail] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (8, 8, N'8尾', N'8,18,28,38,48', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Detail] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (10, 9, N'9尾', N'9,19,29,39,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Detail] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (11, 0, N'0尾', N'10,20,30,40', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Detail] OFF
SET IDENTITY_INSERT [dbo].[Globe] ON 

INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (1, 1, N'01', N'red', CAST(0x0000A7F7017AED49 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (2, 2, N'02', N'red', CAST(0x0000A7F7017AED8D AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (3, 3, N'03', N'blue', CAST(0x0000A7F7017AED8F AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (4, 4, N'04', N'blue', CAST(0x0000A7F7017AED91 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (5, 5, N'05', N'green', CAST(0x0000A7F7017AED92 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (6, 6, N'06', N'green', CAST(0x0000A7F7017AED95 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (7, 7, N'07', N'red', CAST(0x0000A7F7017AED97 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (8, 8, N'08', N'red', CAST(0x0000A7F7017AED99 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (9, 9, N'09', N'blue', CAST(0x0000A7F7017AED9B AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (10, 10, N'10', N'blue', CAST(0x0000A7F7017AED9C AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (11, 11, N'11', N'green', CAST(0x0000A7F7017AED9E AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (12, 12, N'12', N'red', CAST(0x0000A7F7017AEDA1 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (13, 13, N'13', N'red', CAST(0x0000A7F7017AEDA2 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (14, 14, N'14', N'blue', CAST(0x0000A7F7017AEDA4 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (15, 15, N'15', N'blue', CAST(0x0000A7F7017AEDA6 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (16, 16, N'16', N'green', CAST(0x0000A7F7017AEDA8 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (17, 17, N'17', N'green', CAST(0x0000A7F7017AEDAA AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (18, 18, N'18', N'red', CAST(0x0000A7F7017AEDAC AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (19, 19, N'19', N'red', CAST(0x0000A7F7017AEDB5 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (20, 20, N'20', N'blue', CAST(0x0000A7F7017AEDB7 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (21, 21, N'21', N'green', CAST(0x0000A7F7017AEDBA AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (22, 22, N'22', N'green', CAST(0x0000A7F7017AEDBC AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (23, 23, N'23', N'red', CAST(0x0000A7F7017AEDBE AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (24, 24, N'24', N'red', CAST(0x0000A7F7017AEDBF AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (25, 25, N'25', N'blue', CAST(0x0000A7F7017AEDC1 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (26, 26, N'26', N'blue', CAST(0x0000A7F7017AEDC3 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (27, 27, N'27', N'green', CAST(0x0000A7F7017AEDC4 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (28, 28, N'28', N'green', CAST(0x0000A7F7017AEDC6 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (29, 29, N'29', N'red', CAST(0x0000A7F7017AEDC8 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (30, 30, N'30', N'red', CAST(0x0000A7F7017AEDC9 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (31, 31, N'31', N'blue', CAST(0x0000A7F7017AEDCB AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (32, 32, N'32', N'green', CAST(0x0000A7F7017AEDCD AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (33, 33, N'33', N'green', CAST(0x0000A7F7017AEDCE AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (34, 34, N'34', N'red', CAST(0x0000A7F7017AEDD0 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (35, 35, N'35', N'red', CAST(0x0000A7F7017AEDD1 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (36, 36, N'36', N'blue', CAST(0x0000A7F7017AEDD3 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (37, 37, N'37', N'blue', CAST(0x0000A7F7017AEDD5 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (38, 38, N'38', N'green', CAST(0x0000A7F7017AEDD7 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (39, 39, N'39', N'green', CAST(0x0000A7F7017AEDD8 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (40, 40, N'40', N'red', CAST(0x0000A7F7017AEDDA AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (41, 41, N'41', N'blue', CAST(0x0000A7F7017AEDDB AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (42, 42, N'42', N'blue', CAST(0x0000A7F7017AEDDD AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (43, 43, N'43', N'green', CAST(0x0000A7F7017AEDDF AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (44, 44, N'44', N'green', CAST(0x0000A7F7017AEDE0 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (45, 45, N'45', N'red', CAST(0x0000A7F7017AEDE2 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (46, 46, N'46', N'red', CAST(0x0000A7F7017AEDE4 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (47, 47, N'47', N'blue', CAST(0x0000A7F7017AEDE6 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (48, 48, N'48', N'blue', CAST(0x0000A7F7017AEDE7 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe] ([Id], [Code], [Name], [Color], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (49, 49, N'49', N'green', CAST(0x0000A7F7017AEDE9 AS DateTime), N'admin', NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Globe] OFF
SET IDENTITY_INSERT [dbo].[Globe_Clue] ON 

INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (1, 1, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11,2.11', N'', N'', 12, 5, 12, 1, N'全不中', N'5不中', 0.0500, 0.0000, 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (3, 3, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51,2.51', N'', N'', 12, 6, 12, 2, N'全不中', N'6不中', 0.0000, 0.0000, 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (4, 4, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01,3.01', N'', N'', 12, 7, 12, 3, N'全不中', N'7不中', 0.0000, 0.0000, 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (5, 5, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65,3.65', N'', N'', 12, 8, 12, 4, N'全不中', N'8不中', 0.0000, 0.0000, 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (6, 6, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31,4.31', N'', N'', 12, 9, 12, 5, N'全不中', N'9不中', 0.0000, 0.0000, 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (7, 7, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21,5.21', N'', N'', 12, 10, 12, 6, N'全不中', N'10不中', 0.0000, 0.0000, 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (8, 8, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36,6.36', N'', N'', 12, 11, 12, 7, N'全不中', N'11不中', 0.0000, 0.0000, 7, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (9, 9, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82,7.82', N'', N'', 12, 12, 12, 8, N'全不中', N'12不中', 0.0000, 0.0000, 8, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (11, 11, N'', N'', N'1,2,3,4,5,6,7,8,9,0', N'3.20,3.20,3.20,3.20,3.20,3.20,3.20,3.20,3.20,3.20', 999999, 2, 11, 1, N'尾数连', N'二尾连中', 0.0000, 0.0000, 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (13, 13, N'', N'', N'1,2,3,4,5,6,7,8,9,0', N'7.10,7.10,7.10,7.10,7.10,7.10,7.10,7.10,7.10,7.10', 999999, 3, 11, 2, N'尾数连', N'三尾连中', 0.0000, 0.0000, 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (15, 15, N'', N'', N'1,2,3,4,5,6,7,8,9,0', N'16.16,16.16,16.16,16.16,16.16,16.16,16.16,16.16,16.16,16.16', 999999, 4, 11, 3, N'尾数连', N'四尾连中', 0.0000, 0.0000, 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (16, 16, N'', N'', N'1,2,3,4,5,6,7,8,9,0', N'4.80,4.80,4.80,4.80,4.80,4.80,4.80,4.80,4.80,4.80', 999999, 2, 11, 4, N'尾数连', N'二尾连不中', 0.0000, 0.0000, 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (17, 17, N'', N'', N'1,2,3,4,5,6,7,8,9,0', N'13.80,13.80,13.80,13.80,13.80,13.80,13.80,13.80,13.80,13.80', 999999, 3, 11, 5, N'尾数连', N'三尾连不中', 0.0000, 0.0000, 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (18, 18, N'', N'', N'1,2,3,4,5,6,7,8,9,0', N'45.10,45.10,45.10,45.10,45.10,45.10,45.10,45.10,45.10,45.10', 999999, 4, 11, 6, N'尾数连', N'四尾连不中', 0.0000, 0.0000, 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (19, 19, N'1,2,3,4,5,6,7,8,9,10,11,12', N'4.20,4.20,4.20,4.20,4.20,4.20,4.20,4.20,4.20,5,4.20,4.20', N'', N'', 999999, 2, 10, 1, N'连肖', N'二肖连中', 0.0000, 0.0000, 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (22, 22, N'1,2,3,4,5,6,7,8,9,10,11,12', N'11.00,11.00,11.00,11.00,11.00,11.00,11.00,11.00,11.00,11.00,11.00,11.00', N'', N'', 999999, 3, 10, 2, N'连肖', N'三肖连中', 0.0000, 0.0000, 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (23, 23, N'1,2,3,4,5,6,7,8,9,10,11,12', N'32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00', N'', N'', 999999, 4, 10, 3, N'连肖', N'四肖连中', 0.0000, 0.0000, 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (24, 24, N'1,2,3,4,5,6,7,8,9,10,11,12', N'100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00', N'', N'', 999999, 5, 10, 4, N'连肖', N'五肖连中', 0.0000, 0.0000, 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (26, 26, N'1,2,3,4,5,6,7,8,9,10,11,12', N'3.90,3.90,3.90,3.90,3.90,3.90,3.90,3.90,3.90,3.90,3.90,3.90', N'', N'', 999999, 2, 10, 5, N'连肖', N'二肖连不中', 0.0000, 0.0000, 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (27, 27, N'1,2,3,4,5,6,7,8,9,10,11,12', N'7.90,7.90,7.90,7.90,7.90,7.90,7.90,7.90,7.90,7.90,7.90,7.90', N'', N'', 999999, 3, 10, 6, N'连肖', N'三肖连不中', 0.0000, 0.0000, 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (29, 29, N'1,2,3,4,5,6,7,8,9,10,11,12', N'21.10,21.10,21.10,21.10,21.10,21.10,21.10,21.10,21.10,21.10,21.10,21.10', N'', N'', 999999, 4, 10, 7, N'连肖', N'四肖连不中', 0.0000, 0.0000, 7, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (30, 30, N'1,2,3,4,5,6,7,8,9,10,11,12', N'5.82,5.82,5.82,5.82,5.82,5.82,5.82,5.82,5.82,5.82,5.82,5.82', N'', N'', 999999, 2, 9, 1, N'合肖', N'二肖', 0.0000, 0.0000, 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (31, 31, N'1,2,3,4,5,6,7,8,9,10,11,12', N'3.88,3.88,3.88,3.88,3.88,3.88,3.88,3.88,3.88,3.88,3.88,3.88', N'', N'', 999999, 3, 9, 2, N'合肖', N'三肖', 0.0000, 0.0000, 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (32, 32, N'1,2,3,4,5,6,7,8,9,10,11,12', N'2.90,2.90,2.90,2.90,2.90,2.90,2.90,2.90,2.90,2.90,2.90,2.90', N'', N'', 999999, 4, 9, 3, N'合肖', N'四肖', 0.0000, 0.0000, 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (33, 33, N'1,2,3,4,5,6,7,8,9,10,11,12', N'2.33,2.33,2.33,2.33,2.33,2.33,2.33,2.33,2.33,2.33,2.33,2.33', N'', N'', 999999, 5, 9, 4, N'合肖', N'五肖', 0.0000, 0.0000, 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (34, 34, N'1,2,3,4,5,6,7,8,9,10,11,12', N'1.94,1.94,1.94,1.94,1.94,1.94,1.94,1.94,1.94,1.94,1.94,1.94', N'', N'', 999999, 6, 9, 5, N'合肖', N'六肖', 0.0000, 0.0000, 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (35, 35, N'1,2,3,4,5,6,7,8,9,10,11,12', N'1.67,1.67,1.67,1.67,1.67,1.67,1.67,1.67,1.67,1.67,1.67,1.67', N'', N'', 999999, 7, 9, 6, N'合肖', N'七肖', 0.0000, 0.0000, 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (36, 36, N'1,2,3,4,5,6,7,8,9,10,11,12', N'1.46,1.46,1.46,1.46,1.46,1.46,1.46,1.46,1.46,1.46,1.46,1.46', N'', N'', 999999, 8, 9, 7, N'合肖', N'八肖', 0.0000, 0.0000, 7, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (38, 38, N'1,2,3,4,5,6,7,8,9,10,11,12', N'1.29,1.29,1.29,1.29,1.29,1.29,1.29,1.29,1.29,1.29,1.29,1.29', N'', N'', 999999, 9, 9, 8, N'合肖', N'九肖', 0.0000, 0.0000, 8, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (39, 39, N'1,2,3,4,5,6,7,8,9,10,11,12', N'1.17,1.17,1.17,1.17,1.17,1.17,1.17,1.17,1.17,1.17,1.17,1.17', N'', N'', 999999, 10, 9, 9, N'合肖', N'十肖', 0.0000, 0.0000, 9, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (41, 41, N'1,2,3,4,5,6,7,8,9,10,11,12', N'1.06,1.06,1.06,1.06,1.06,1.06,1.06,1.06,1.06,1.06,1.06,1.06', N'', N'', 999999, 11, 9, 10, N'合肖', N'十一肖', 0.0000, 0.0000, 10, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (42, 42, N'1,2,3,4,5,6,7,8,9,10,11,12', N'11.00,11.00,11.00,11.00,11.00,11.00,11.00,11.00,11.00,9.00,11.00,11.00', N'', N'', 999999, 0, 8, 1, N'特码生肖', N'特码生肖', 0.0000, 0.0000, 0, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (45, 45, N'1,2,3,4,5,6,7,8,9,10,11,12', N'2.00,2.00,2.00,2.00,2.00,2.00,2.00,2.00,2.00,2.00,2.00,2.00', N'0,1,2,3,4,5,6,7,8,9', N'2.00,1.80,1.80,1.80,1.80,1.80,1.80,1.80,1.80,1.80,1.80,1.80', 999999, 0, 7, 1, N'一肖/尾数', N'正特肖/正特尾', 0.0000, 0.0000, 0, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (46, 46, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18', N'5.611,5.06,6.51,4.51,5.61,6.51,5.61,6.61,5.61,5.61,5.06,6.51,5.61,5.30,5.30,5.30,5.30,5.30', N'', N'', 999999, 0, 6, 1, N'特码半波', N'半波', 0.0000, 0.0000, 0, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (47, 47, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'701.04,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00,710.00', N'', N'', 999999, 3, 5, 1, N'连码', N'三全中', 0.0000, 0.0000, 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (48, 48, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00,20.00', N'', N'', 999999, 3, 5, 2, N'连码', N'三中二', 0.0000, 0.0000, 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (49, 49, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00,66.00', N'', N'', 999999, 2, 5, 3, N'连码', N'二全中', 0.0000, 0.0000, 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (50, 50, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00,32.00', N'', N'', 999999, 2, 5, 4, N'连码', N'二中特之中特', 0.0000, 0.0000, 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (51, 51, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'', N'', 999999, 2, 5, 5, N'连码', N'二中特之中二', 0.0000, 0.0000, 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (52, 52, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00,156.00', N'', N'', 999999, 2, 5, 6, N'连码', N'特串', 0.0000, 0.0000, 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (54, 54, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81,1.81', N'', N'', 999999, 4, 5, 7, N'连码', N'四中一', 0.0000, 0.0000, 7, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 2)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (55, 55, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78', N'1.00,2.00,3.00,4.00,5.00,6.00,7.00,8.00,9.00,10.00,11.00,12.00,13.00,14.00,15.00,16.00,17.00,18.00,19.00,20.00,21.00,22.00,23.00,24.00,25.00,26.00,27.00,28.00,29.00,30.00,31.00,32.00,33.00,34.00,35.00,36.00,37.00,38.00,39.00,40.00,41.00,42.00,43.00,44.00,45.00,46.00,47.00,48.00,49.00,50.00,51.00,52.00,53.00,54.00,55.00,56.00,57.00,58.00,59.00,60.00,61.00,62.00,63.00,64.00,65.00,66.00,67.00,68.00,69.00,70.00,71.00,72.00,73.00,74.00,75.00,76.00,77.00,78.00', N'', N'', 999999, 0, 4, 1, N'正码1-6', N'正码1-6', 0.0000, 0.0000, 0, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (56, 56, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20', N'1,2,3,4,5,6,7,8,9,10,11,12,13', N'1.95,1.95,1.95,1.95,1.95,1.95,2.65,2.75,2.75,1.95,1.95,1.95,1.95', 999999, 0, 3, 1, N'正码特', N'正一特', 0.0500, 0.1200, 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (58, 58, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00', N'1,2,3,4,5,6,7,8,9,10,11,12,13', N'1.95,1.95,1.95,1.95,1.95,1.95,2.65,2.75,2.75,1.95,1.95,1.95,1.95', 999999, 0, 3, 2, N'正码特', N'正二特', 0.0000, 0.0000, 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (62, 62, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00', N'1,2,3,4,5,6,7,8,9,10,11,12,13', N'1.95,1.95,1.95,1.95,1.95,1.95,2.65,2.75,2.75,1.95,1.95,1.95,1.95', 999999, 0, 3, 3, N'正码特', N'正三特', 0.0000, 0.0000, 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (64, 64, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00', N'1,2,3,4,5,6,7,8,9,10,11,12,13', N'1.95,1.95,1.95,1.95,1.95,1.95,2.65,2.75,2.75,1.95,1.95,1.95,1.95', 999999, 0, 3, 4, N'正码特', N'正四特', 0.0000, 0.0000, 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (65, 65, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00', N'1,2,3,4,5,6,7,8,9,10,11,12,13', N'1.95,1.95,1.95,1.95,1.95,1.95,2.65,2.75,2.75,1.95,1.95,1.95,1.95', 999999, 0, 3, 5, N'正码特', N'正五特', 0.0000, 0.0000, 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (67, 67, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00,48.00', N'1,2,3,4,5,6,7,8,9,10,11,12,13', N'1.95,1.95,1.95,1.95,1.95,1.95,2.65,2.75,2.75,1.95,1.95,1.95,1.95', 999999, 0, 3, 6, N'正码特', N'正六特', 0.0000, 0.0000, 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (70, 70, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.40,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00,3.00', N'1,2,3,4', N'', 999999, 0, 2, 1, N'正码', N'正码A', 0.0400, 0.0000, 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (72, 72, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16,7.16', N'1,2,3,4', N'1.91,1.91,1.91,1.91', 999999, 0, 2, 2, N'正码', N'正码B', 0.0000, 0.0000, 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (74, 74, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'47.81,48.80,48.80,48.80,48.80,48.80,48.80,48.83,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80', N'1,3,5,7,10,2,4,6,8,11,13,12,9', N'1.00,2.00,1.00,1.00,1.00,1.00,1.00,1.00,1.00,1.00,1.00,1.00,1.00', 999999, 0, 1, 1, N'特码', N'特码A', 0.1100, 0.0500, 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Globe_Clue] ([Id], [Code], [Clue], [Pay], [Clue2], [Pay2], [Limit_Max], [Limit_Min], [First_Type], [Second_Type], [First_Name], [Second_Name], [Return_Pay], [Return_Pay2], [Sort], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (76, 76, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', N'48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20,48.20', N'1,3,5,7,10,2,4,6,8,11,13,12,9', N'1.91,2.04,1.95,2.65,1.95,1.95,1.95,1.95,1.95,2.75,1.95,1.95,2.75', 999999, 0, 1, 2, N'特码', N'特码B', 0.0000, 0.0000, 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Globe_Clue] OFF
SET IDENTITY_INSERT [dbo].[MoneyLog] ON 

INSERT [dbo].[MoneyLog] ([Id], [O_Content], [O_Money], [UserID], [UserName], [Type], [OperationType], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (1, N'操作内容：中奖->年号->2017期号->1特码半波->半波->下注内容(绿单,红小,绿双,)->下注单价(10))->派奖内容【中奖：(绿单)】;金额：56.1', 56.1000, N'lilin', N'李玲', 0, 4, CAST(0x0000A82401557C06 AS DateTime), N'lilin', NULL, N'', 0, 0)
INSERT [dbo].[MoneyLog] ([Id], [O_Content], [O_Money], [UserID], [UserName], [Type], [OperationType], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (2, N'操作内容：中奖->年号->2017期号->1特码->特码A->下注内容(特码大,特码双,绿波,特码单,合数双,合数单,蓝波,红波,合数小,合数大,尾数小,尾数大,特码小,)->下注单价(10))->派奖内容【中奖：(特码大,绿波,特码单,合数单,合数大,尾数大)】;金额：70', 70.0000, N'lilin', N'李玲', 0, 4, CAST(0x0000A82401557C08 AS DateTime), N'lilin', NULL, N'', 0, 0)
INSERT [dbo].[MoneyLog] ([Id], [O_Content], [O_Money], [UserID], [UserName], [Type], [OperationType], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (3, N'操作内容：返水->年号->2017期号->1特码->特码A->下注内容(特码大,特码双,绿波,特码单,合数双,合数单,蓝波,红波,合数小,合数大,尾数小,尾数大,特码小,)->下注单价(10);金额：3.90000000', 3.9000, N'lilin', N'李玲', 0, 5, CAST(0x0000A82401557C09 AS DateTime), N'lilin', NULL, N'', 0, 0)
INSERT [dbo].[MoneyLog] ([Id], [O_Content], [O_Money], [UserID], [UserName], [Type], [OperationType], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (4, N'操作内容：中奖->年号->2017期号->1特码->特码A->下注内容(01,07,13,19,25,31,37,43,49,)->下注单价(10))->派奖内容【中奖：(49)】;金额：488', 488.0000, N'lilin', N'李玲', 0, 4, CAST(0x0000A82401557C0B AS DateTime), N'lilin', NULL, N'', 0, 0)
INSERT [dbo].[MoneyLog] ([Id], [O_Content], [O_Money], [UserID], [UserName], [Type], [OperationType], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (5, N'操作内容：返水->年号->2017期号->1特码->特码A->下注内容(01,07,13,19,25,31,37,43,49,)->下注单价(10);金额：2.70000000', 2.7000, N'lilin', N'李玲', 0, 5, CAST(0x0000A82401557C0B AS DateTime), N'lilin', NULL, N'', 0, 0)
INSERT [dbo].[MoneyLog] ([Id], [O_Content], [O_Money], [UserID], [UserName], [Type], [OperationType], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (6, N'操作内容：中奖->年号->2017期号->1合肖->六肖->下注内容(猪,狗,鸡,猴,羊,马,)->下注单价(10))->派奖内容【中奖：(鸡)】;金额：19.4', 19.4000, N'lilin', N'李玲', 0, 4, CAST(0x0000A82401557C0D AS DateTime), N'lilin', NULL, N'', 0, 0)
SET IDENTITY_INSERT [dbo].[MoneyLog] OFF
SET IDENTITY_INSERT [dbo].[Operation_Record] ON 

INSERT [dbo].[Operation_Record] ([Id], [AwardCode], [ClueCode], [UserID], [Buy_Content], [Buy_Content2], [UnitPrice], [BuyPayReturn], [BuyPayReturn2], [MinPayReturn], [MaxPayReturn], [Using_Money], [Get_Money], [Araw_ReturnMoney], [Araw_RetrunContent], [Return_Money], [IsWin], [Operation_Time], [PayUID], [Type], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (1, 10, 34, N'lilin', N'12,11,10,9,8,7', N'', 10, N'1.94,1.94,1.94,1.94,1.94,1.94', N'', 1.9400, 1.9400, 10.0000, 19.4000, 0.0000, N'中奖：(鸡)', 0.0000, 0, CAST(0x0000A824014E6E91 AS DateTime), N'', 1, CAST(0x0000A824014E6E91 AS DateTime), N'lilin', NULL, N'', 0, 0)
INSERT [dbo].[Operation_Record] ([Id], [AwardCode], [ClueCode], [UserID], [Buy_Content], [Buy_Content2], [UnitPrice], [BuyPayReturn], [BuyPayReturn2], [MinPayReturn], [MaxPayReturn], [Using_Money], [Get_Money], [Araw_ReturnMoney], [Araw_RetrunContent], [Return_Money], [IsWin], [Operation_Time], [PayUID], [Type], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (2, 10, 74, N'lilin', N'1,7,13,19,25,31,37,43,49', N'', 10, N'47.81,48.80,48.80,48.80,48.80,48.80,48.80,48.80,48.80', N'', 0.0000, 0.0000, 90.0000, 488.0000, 0.0000, N'中奖：(49)', 2.7000, 0, CAST(0x0000A82401505F1E AS DateTime), N'', 0, CAST(0x0000A82401505F1E AS DateTime), N'lilin', NULL, N'', 0, 0)
INSERT [dbo].[Operation_Record] ([Id], [AwardCode], [ClueCode], [UserID], [Buy_Content], [Buy_Content2], [UnitPrice], [BuyPayReturn], [BuyPayReturn2], [MinPayReturn], [MaxPayReturn], [Using_Money], [Get_Money], [Araw_ReturnMoney], [Araw_RetrunContent], [Return_Money], [IsWin], [Operation_Time], [PayUID], [Type], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (3, 10, 74, N'lilin', N'', N'1,4,9,3,6,5,8,7,11,10,13,12,2', 10, N'', N'1.00,1.00,1.00,2.00,1.00,1.00,1.00,1.00,1.00,1.00,1.00,1.00,1.00', 0.0000, 0.0000, 130.0000, 70.0000, 0.0000, N'中奖：(特码大,绿波,特码单,合数单,合数大,尾数大)', 3.9000, 0, CAST(0x0000A82401505F22 AS DateTime), N'', 0, CAST(0x0000A82401505F22 AS DateTime), N'lilin', NULL, N'', 0, 0)
INSERT [dbo].[Operation_Record] ([Id], [AwardCode], [ClueCode], [UserID], [Buy_Content], [Buy_Content2], [UnitPrice], [BuyPayReturn], [BuyPayReturn2], [MinPayReturn], [MaxPayReturn], [Using_Money], [Get_Money], [Araw_ReturnMoney], [Araw_RetrunContent], [Return_Money], [IsWin], [Operation_Time], [PayUID], [Type], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (4, 10, 46, N'lilin', N'5,4,6', N'', 10, N'5.61,4.51,6.51', N'', 0.0000, 0.0000, 30.0000, 56.1000, 0.0000, N'中奖：(绿单)', 0.0000, 0, CAST(0x0000A8240150C510 AS DateTime), N'', 0, CAST(0x0000A8240150C510 AS DateTime), N'lilin', NULL, N'', 0, 0)
SET IDENTITY_INSERT [dbo].[Operation_Record] OFF
SET IDENTITY_INSERT [dbo].[Size_Six] ON 

INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (1, 1, N'正码一单', N'1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49', 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (3, 2, N'正码二单', N'1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49', 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (4, 3, N'正码三单', N'1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49', 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (5, 4, N'正码四单', N'1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49', 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (6, 5, N'正码五单', N'1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49', 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (7, 6, N'正码六单', N'1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49', 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (8, 7, N'正码一双', N'2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48', 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (10, 8, N'正码二双', N'2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48', 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (11, 9, N'正码三双', N'2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48', 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (12, 10, N'正码四双', N'2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48', 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (13, 11, N'正码五双', N'2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48', 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (14, 12, N'正码六双', N'2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48', 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (15, 13, N'正码一大', N'25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (18, 14, N'正码二大', N'25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (19, 15, N'正码三大', N'25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (20, 16, N'正码四大', N'25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (22, 17, N'正码五大', N'25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (24, 18, N'正码六大', N'25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (25, 19, N'正码一小', N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24', 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (27, 20, N'正码二小', N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24', 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (28, 21, N'正码三小', N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24', 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (29, 22, N'正码四小', N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24', 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (30, 23, N'正码五小', N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24', 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (31, 24, N'正码六小', N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24', 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (32, 25, N'正码一红波', N'1,2,7,8,12,13,18,19,23,24,29,30,34,35,40,45,46', 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (33, 26, N'正码二红波', N'1,2,7,8,12,13,18,19,23,24,29,30,34,35,40,45,46', 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (35, 27, N'正码三红波', N'1,2,7,8,12,13,18,19,23,24,29,30,34,35,40,45,46', 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (37, 28, N'正码四红波', N'1,2,7,8,12,13,18,19,23,24,29,30,34,35,40,45,46', 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (38, 29, N'正码五红波', N'1,2,7,8,12,13,18,19,23,24,29,30,34,35,40,45,46', 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (39, 30, N'正码六红波', N'1,2,7,8,12,13,18,19,23,24,29,30,34,35,40,45,46', 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (40, 31, N'正码一蓝波', N'3,4,9,10,14,15,20,25,26,31,36,37,41,42,47,48', 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (41, 32, N'正码二蓝波', N'3,4,9,10,14,15,20,25,26,31,36,37,41,42,47,48', 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (42, 33, N'正码三蓝波', N'3,4,9,10,14,15,20,25,26,31,36,37,41,42,47,48', 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (43, 34, N'正码四蓝波', N'3,4,9,10,14,15,20,25,26,31,36,37,41,42,47,48', 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (44, 35, N'正码五蓝波', N'3,4,9,10,14,15,20,25,26,31,36,37,41,42,47,48', 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (45, 36, N'正码六蓝波', N'3,4,9,10,14,15,20,25,26,31,36,37,41,42,47,48', 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (47, 37, N'正码一绿波', N'5,6,11,16,17,21,22,27,28,32,33,38,39,43,44,49', 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (49, 38, N'正码二绿波', N'5,6,11,16,17,21,22,27,28,32,33,38,39,43,44,49', 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (50, 39, N'正码三绿波', N'5,6,11,16,17,21,22,27,28,32,33,38,39,43,44,49', 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (51, 40, N'正码四绿波', N'5,6,11,16,17,21,22,27,28,32,33,38,39,43,44,49', 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (52, 41, N'正码五绿波', N'5,6,11,16,17,21,22,27,28,32,33,38,39,43,44,49', 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (53, 42, N'正码六绿波', N'5,6,11,16,17,21,22,27,28,32,33,38,39,43,44,49', 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (55, 43, N'正码一合大', N'7,8,9,16,17,18,19,25,26,27,28,29,34,35,36,37,38,39,43,44,45,46,47,48,49', 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (56, 44, N'正码二合大', N'7,8,9,16,17,18,19,25,26,27,28,29,34,35,36,37,38,39,43,44,45,46,47,48,49', 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (57, 45, N'正码三合大', N'7,8,9,16,17,18,19,25,26,27,28,29,34,35,36,37,38,39,43,44,45,46,47,48,49', 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (58, 46, N'正码四合大', N'7,8,9,16,17,18,19,25,26,27,28,29,34,35,36,37,38,39,43,44,45,46,47,48,49', 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (59, 47, N'正码五合大', N'7,8,9,16,17,18,19,25,26,27,28,29,34,35,36,37,38,39,43,44,45,46,47,48,49', 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (60, 48, N'正码六合大', N'7,8,9,16,17,18,19,25,26,27,28,29,34,35,36,37,38,39,43,44,45,46,47,48,49', 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (61, 49, N'正码一合小', N'1,2,3,4,5,6,10,11,12,13,14,15,20,21,22,23,24,30,31,32,33,40,41,42', 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (62, 50, N'正码二合小', N'1,2,3,4,5,6,10,11,12,13,14,15,20,21,22,23,24,30,31,32,33,40,41,42', 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (63, 51, N'正码三合小', N'1,2,3,4,5,6,10,11,12,13,14,15,20,21,22,23,24,30,31,32,33,40,41,42', 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (64, 52, N'正码四合小', N'1,2,3,4,5,6,10,11,12,13,14,15,20,21,22,23,24,30,31,32,33,40,41,42', 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (65, 53, N'正码五合小', N'1,2,3,4,5,6,10,11,12,13,14,15,20,21,22,23,24,30,31,32,33,40,41,42', 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (66, 54, N'正码六合小', N'1,2,3,4,5,6,10,11,12,13,14,15,20,21,22,23,24,30,31,32,33,40,41,42', 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (67, 55, N'正码一合单', N'1,3,5,7,9,10,12,14,16,18,21,23,25,27,29,30,32,34,36,38,41,43,45,47,49', 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (68, 56, N'正码二合单', N'1,3,5,7,9,10,12,14,16,18,21,23,25,27,29,30,32,34,36,38,41,43,45,47,49', 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (69, 57, N'正码三合单', N'1,3,5,7,9,10,12,14,16,18,21,23,25,27,29,30,32,34,36,38,41,43,45,47,49', 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (70, 58, N'正码四合单', N'1,3,5,7,9,10,12,14,16,18,21,23,25,27,29,30,32,34,36,38,41,43,45,47,49', 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (72, 59, N'正码五合单', N'1,3,5,7,9,10,12,14,16,18,21,23,25,27,29,30,32,34,36,38,41,43,45,47,49', 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (73, 60, N'正码六合单', N'1,3,5,7,9,10,12,14,16,18,21,23,25,27,29,30,32,34,36,38,41,43,45,47,49', 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (76, 61, N'正码一合双', N'2,4,6,8,11,13,15,17,19,20,22,24,26,28,31,33,35,37,39,40,42,44,46,48', 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (78, 62, N'正码二合双', N'2,4,6,8,11,13,15,17,19,20,22,24,26,28,31,33,35,37,39,40,42,44,46,48', 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (79, 63, N'正码三合双', N'2,4,6,8,11,13,15,17,19,20,22,24,26,28,31,33,35,37,39,40,42,44,46,48', 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (81, 64, N'正码四合双', N'2,4,6,8,11,13,15,17,19,20,22,24,26,28,31,33,35,37,39,40,42,44,46,48', 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (82, 65, N'正码五合双', N'2,4,6,8,11,13,15,17,19,20,22,24,26,28,31,33,35,37,39,40,42,44,46,48', 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (83, 66, N'正码六合双', N'2,4,6,8,11,13,15,17,19,20,22,24,26,28,31,33,35,37,39,40,42,44,46,48', 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (84, 67, N'正码一尾大', N'5,6,7,8,9,15,16,17,18,19,25,26,27,28,29,35,36,37,38,39,45,46,47,48,49', 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (85, 68, N'正码二尾大', N'5,6,7,8,9,15,16,17,18,19,25,26,27,28,29,35,36,37,38,39,45,46,47,48,49', 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (86, 69, N'正码三尾大', N'5,6,7,8,9,15,16,17,18,19,25,26,27,28,29,35,36,37,38,39,45,46,47,48,49', 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (87, 70, N'正码四尾大', N'5,6,7,8,9,15,16,17,18,19,25,26,27,28,29,35,36,37,38,39,45,46,47,48,49', 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (88, 71, N'正码五尾大', N'5,6,7,8,9,15,16,17,18,19,25,26,27,28,29,35,36,37,38,39,45,46,47,48,49', 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (89, 72, N'正码六尾大', N'5,6,7,8,9,15,16,17,18,19,25,26,27,28,29,35,36,37,38,39,45,46,47,48,49', 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (90, 73, N'正码一尾小', N'
1,2,3,4,10,11,12,13,14,20,21,22,23,24,30,31,32,33,34,40,41,42,43,44', 1, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (91, 74, N'正码二尾小', N'
1,2,3,4,10,11,12,13,14,20,21,22,23,24,30,31,32,33,34,40,41,42,43,44', 2, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (92, 75, N'正码三尾小', N'
1,2,3,4,10,11,12,13,14,20,21,22,23,24,30,31,32,33,34,40,41,42,43,44', 3, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (93, 76, N'正码四尾小', N'
1,2,3,4,10,11,12,13,14,20,21,22,23,24,30,31,32,33,34,40,41,42,43,44', 4, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (94, 77, N'正码五尾小', N'
1,2,3,4,10,11,12,13,14,20,21,22,23,24,30,31,32,33,34,40,41,42,43,44', 5, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Six] ([Id], [Code], [Name], [Globe], [Award_Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (95, 78, N'正码六尾小', N'
1,2,3,4,10,11,12,13,14,20,21,22,23,24,30,31,32,33,34,40,41,42,43,44', 6, CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
SET IDENTITY_INSERT [dbo].[Size_Six] OFF
SET IDENTITY_INSERT [dbo].[Size_Special] ON 

INSERT [dbo].[Size_Special] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (1, 1, N'特码大', N'25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Special] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (2, 2, N'特码小', N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Special] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (3, 3, N'特码单', N'1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Special] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (4, 4, N'特码双', N'2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Special] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (5, 5, N'合数单', N'1,3,5,7,9,10,12,14,16,18,21,23,25,27,29,30,32,34,36,38,41,43,45,47,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Special] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (6, 6, N'合数双', N'2,4,6,8,11,13,15,17,19,20,22,24,26,28,31,33,35,37,39,40,42,44,46,48', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Special] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (7, 7, N'红波', N'1,2,7,8,12,13,18,19,23,24,29,30,34,35,40,45,46', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Special] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (8, 8, N'蓝波', N'3,4,9,10,14,15,20,25,26,31,36,37,41,42,47,48', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Special] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (9, 9, N'绿波', N'5,6,11,16,17,21,22,27,28,32,33,38,39,43,44,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_Special] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (10, 10, N'合数大', N'7,8,9,16,17,18,19,25,26,27,28,29,34,35,36,37,38,39,43,44,45,46,47,48,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Special] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (11, 11, N'合数小', N'1,2,3,4,5,6,10,11,12,13,14,15,20,21,22,23,24,30,31,32,33,40,41,42', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Special] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (12, 12, N'尾数大', N'5,6,7,8,9,15,16,17,18,19,25,26,27,28,29,35,36,37,38,39,45,46,47,48,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_Special] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (13, 13, N'尾数小', N'1,2,3,4,10,11,12,13,14,20,21,22,23,24,30,31,32,33,34,40,41,42,43,44', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
SET IDENTITY_INSERT [dbo].[Size_Special] OFF
INSERT [dbo].[Size_SpecialNormal] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (2, 1, N'大', N'25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_SpecialNormal] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (3, 2, N'小', N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_SpecialNormal] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (4, 3, N'单', N'1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_SpecialNormal] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (5, 4, N'双', N'2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_SpecialNormal] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (6, 5, N'合数单', N'1,3,5,7,9,10,12,14,16,18,21,23,25,27,29,30,32,34,36,38,41,43,45,47,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_SpecialNormal] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (7, 6, N'合数双', N'2,4,6,8,11,13,15,17,19,20,22,24,26,28,31,33,35,37,39,40,42,44,46,48', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_SpecialNormal] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (8, 7, N'红波', N'1,2,7,8,12,13,18,19,23,24,29,30,34,35,40,45,46', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_SpecialNormal] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (9, 8, N'蓝波', N'3,4,9,10,14,15,20,25,26,31,36,37,41,42,47,48', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_SpecialNormal] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (10, 9, N'绿波', N'5,6,11,16,17,21,22,27,28,32,33,38,39,43,44,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 2)
INSERT [dbo].[Size_SpecialNormal] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (11, 10, N'合数大', N'7,8,9,16,17,18,19,25,26,27,28,29,34,35,36,37,38,39,43,44,45,46,47,48,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_SpecialNormal] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (12, 11, N'合数小', N'1,2,3,4,5,6,10,11,12,13,14,15,20,21,22,23,24,30,31,32,33,40,41,42', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_SpecialNormal] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (13, 12, N'尾数大', N'5,6,7,8,9,15,16,17,18,19,25,26,27,28,29,35,36,37,38,39,45,46,47,48,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[Size_SpecialNormal] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (14, 13, N'尾数小', N'1,2,3,4,10,11,12,13,14,20,21,22,23,24,30,31,32,33,34,40,41,42,43,44', CAST(0x0000A813010D6396 AS DateTime), N'admin', NULL, N'', 0, 0)
SET IDENTITY_INSERT [dbo].[Size_Sum] ON 

INSERT [dbo].[Size_Sum] ([Id], [Code], [Globe], [Name], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (1, 1, NULL, N'总合大', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Size_Sum] ([Id], [Code], [Globe], [Name], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (2, 2, NULL, N'总合小', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Size_Sum] ([Id], [Code], [Globe], [Name], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (3, 3, NULL, N'总合单', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Size_Sum] ([Id], [Code], [Globe], [Name], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (4, 4, NULL, N'总合双', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Size_Sum] OFF
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([Id], [LoginName], [Password], [Salt], [Name], [Money], [Role], [EnableTime], [Remarks], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (1, N'admin', N'7B878AF28F1A208B', N'ZRJ820', N'超级管理员', 0.0000, 1, CAST(0x0000A7FD00000000 AS DateTime), N'', CAST(0x0000A7FD0008FA37 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[UserInfo] ([Id], [LoginName], [Password], [Salt], [Name], [Money], [Role], [EnableTime], [Remarks], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (2, N'lilin', N'184F456216DA0087', N'0P04N0', N'李玲', 11695.3000, 2, CAST(0x0000A82800000000 AS DateTime), N'', CAST(0x0000A81600851ED1 AS DateTime), N'admin', NULL, N'', 0, 0)
INSERT [dbo].[UserInfo] ([Id], [LoginName], [Password], [Salt], [Name], [Money], [Role], [EnableTime], [Remarks], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (3, N'lyq9867', N'B02B809C771EF1FB', N'0TF222', N'lyq9867', 6630.2000, 2, CAST(0x000118CD009450C0 AS DateTime), N'10000', CAST(0x0000A81601074EDB AS DateTime), N'admin', NULL, N'', 0, 0)
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
SET IDENTITY_INSERT [dbo].[Wave] ON 

INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (1, 1, N'红单', N'1,7,13,19,23,29,35,45', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (2, 2, N'红双', N'2,8,12,18,24,30,34,40,46', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (3, 3, N'红大', N'29,30,34,35,40,45,46', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (4, 4, N'红小', N'1,2,7,8,12,13,18,19,23,24', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (6, 5, N'绿单', N'5,11,17,21,27,33,39,43,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (8, 6, N'绿双', N'6,16,22,28,32,38,44', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (9, 7, N'绿大', N'27,28,32,33,38,39,43,44,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (10, 8, N'绿小', N'5,6,11,16,17,21,22', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (11, 9, N'蓝单', N'3,9,15,25,31,37,41,47', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (12, 10, N'蓝双', N'4,10,14,20,26,36,42,48', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (14, 11, N'蓝大', N'25,26,31,36,37,41,42,47,48', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (15, 12, N'蓝小', N'3,4,9,10,14,15,20', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (16, 13, N'红合单', N'1,7,23,29,12,18,30,34,45', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (17, 14, N'红合双', N'13,19,35,02,08,24,40,46', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (18, 15, N'绿合单', N'5,16,21,27,32,38,43,49', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (19, 16, N'绿合双', N'6,11,17,22,28,33,39,44', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (20, 17, N'蓝合单', N'3,9,25,41,47,10,14,36', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Wave] ([Id], [Code], [Name], [Globe], [CreateTime], [CreateUID], [EditTime], [EditUID], [IsDelete], [IsEnable]) VALUES (21, 18, N'蓝合双', N'15,31,37,4,20,26,42,48', CAST(0x0000A7F700000000 AS DateTime), N'admin', NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Wave] OFF
ALTER TABLE [dbo].[Animal_Info] ADD  CONSTRAINT [DF_Animal_Info_Code]  DEFAULT ((0)) FOR [Code]
GO
ALTER TABLE [dbo].[Animal_Info] ADD  CONSTRAINT [DF_Animal_Info_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Animal_Info] ADD  CONSTRAINT [DF_Animal_Info_Globe]  DEFAULT ('') FOR [Globe]
GO
ALTER TABLE [dbo].[Animal_Info] ADD  CONSTRAINT [DF_Animal_Info_Operation_Year]  DEFAULT ((0)) FOR [Operation_Year]
GO
ALTER TABLE [dbo].[Animal_Info] ADD  CONSTRAINT [DF__Animal_In__Creat__6FE99F9F]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Animal_Info] ADD  CONSTRAINT [DF__Animal_In__Creat__70DDC3D8]  DEFAULT ('admin') FOR [CreateUID]
GO
ALTER TABLE [dbo].[Animal_Info] ADD  CONSTRAINT [DF_Animal_Info_EditUID]  DEFAULT ('') FOR [EditUID]
GO
ALTER TABLE [dbo].[Animal_Info] ADD  CONSTRAINT [DF__Animal_In__IsDel__71D1E811]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Animal_Info] ADD  CONSTRAINT [DF__Animal_In__IsEna__72C60C4A]  DEFAULT ((0)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[Award_Public] ADD  CONSTRAINT [DF_Award_Public_Code]  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[Award_Public] ADD  CONSTRAINT [DF_Award_Public_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Award_Public] ADD  CONSTRAINT [DF_Award_Public_Year]  DEFAULT ((0)) FOR [Year]
GO
ALTER TABLE [dbo].[Award_Public] ADD  CONSTRAINT [DF_Prize_Public_PrizeContent]  DEFAULT ('') FOR [PrizeContent]
GO
ALTER TABLE [dbo].[Award_Public] ADD  CONSTRAINT [DF_Award_Public_IsCompleate]  DEFAULT ((1)) FOR [IsCompleate]
GO
ALTER TABLE [dbo].[Award_Public] ADD  CONSTRAINT [DF__Prize_Pub__Creat__0E391C95]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Award_Public] ADD  CONSTRAINT [DF__Prize_Pub__Creat__0F2D40CE]  DEFAULT ('admin') FOR [CreateUID]
GO
ALTER TABLE [dbo].[Award_Public] ADD  CONSTRAINT [DF_Award_Public_EditUID]  DEFAULT ('') FOR [EditUID]
GO
ALTER TABLE [dbo].[Award_Public] ADD  CONSTRAINT [DF__Prize_Pub__IsDel__10216507]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Award_Public] ADD  CONSTRAINT [DF__Prize_Pub__IsEna__11158940]  DEFAULT ((0)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[Detail] ADD  CONSTRAINT [DF_Detail_Code]  DEFAULT ((0)) FOR [Code]
GO
ALTER TABLE [dbo].[Detail] ADD  CONSTRAINT [DF_Detail_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Detail] ADD  CONSTRAINT [DF_Detail_Globe]  DEFAULT (N'’‘') FOR [Globe]
GO
ALTER TABLE [dbo].[Detail] ADD  CONSTRAINT [DF__Detail__CreateTi__6A30C649]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Detail] ADD  CONSTRAINT [DF__Detail__CreateUI__6B24EA82]  DEFAULT ('admin') FOR [CreateUID]
GO
ALTER TABLE [dbo].[Detail] ADD  CONSTRAINT [DF_Detail_EditUID]  DEFAULT (N'’‘') FOR [EditUID]
GO
ALTER TABLE [dbo].[Detail] ADD  CONSTRAINT [DF__Detail__IsDelete__6C190EBB]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Detail] ADD  CONSTRAINT [DF__Detail__IsEnable__6D0D32F4]  DEFAULT ((0)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[Globe] ADD  CONSTRAINT [DF_Globe_Code]  DEFAULT ((0)) FOR [Code]
GO
ALTER TABLE [dbo].[Globe] ADD  CONSTRAINT [DF_Globe_Name]  DEFAULT (N'’‘') FOR [Name]
GO
ALTER TABLE [dbo].[Globe] ADD  CONSTRAINT [DF_Globe_Color]  DEFAULT (N'’‘') FOR [Color]
GO
ALTER TABLE [dbo].[Globe] ADD  CONSTRAINT [DF__Globe__CreateTim__1FCDBCEB]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Globe] ADD  CONSTRAINT [DF__Globe__CreateUII__20C1E124]  DEFAULT ('admin') FOR [CreateUID]
GO
ALTER TABLE [dbo].[Globe] ADD  CONSTRAINT [DF_Globe_EditUID]  DEFAULT (N'’‘') FOR [EditUID]
GO
ALTER TABLE [dbo].[Globe] ADD  CONSTRAINT [DF_Globe_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Globe] ADD  CONSTRAINT [DF_Globe_IsEnable]  DEFAULT ((0)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_Code]  DEFAULT ((0)) FOR [Code]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_Clue]  DEFAULT (N'’‘') FOR [Clue]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_Pay]  DEFAULT (N'’‘') FOR [Pay]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_Clue2]  DEFAULT ('') FOR [Clue2]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_Pay2]  DEFAULT ('') FOR [Pay2]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_Limit_Max]  DEFAULT ((999999)) FOR [Limit_Max]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_Limit_Min]  DEFAULT ((0)) FOR [Limit_Min]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_First_Type]  DEFAULT ((0)) FOR [First_Type]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_Second_Type]  DEFAULT ((0)) FOR [Second_Type]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_First_Name]  DEFAULT (N'’‘') FOR [First_Name]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_Second_Name]  DEFAULT (N'’‘') FOR [Second_Name]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_Return_Pay]  DEFAULT ((0.00)) FOR [Return_Pay]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_Return_Pay1]  DEFAULT ((0.00)) FOR [Return_Pay2]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_Sort]  DEFAULT ((0)) FOR [Sort]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF__Globe_clu__Creat__21B6055D]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF__Globe_clu__Creat__22AA2996]  DEFAULT ('admin') FOR [CreateUID]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_Clue_EditUID]  DEFAULT (N'’‘') FOR [EditUID]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_clue_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Globe_Clue] ADD  CONSTRAINT [DF_Globe_clue_IsEnable]  DEFAULT ((0)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[MoneyLog] ADD  CONSTRAINT [DF_MoneyLog_O_Content]  DEFAULT ('') FOR [O_Content]
GO
ALTER TABLE [dbo].[MoneyLog] ADD  CONSTRAINT [DF_MoneyLog_O_Money]  DEFAULT ((0)) FOR [O_Money]
GO
ALTER TABLE [dbo].[MoneyLog] ADD  CONSTRAINT [DF_MoneyLog_UserID]  DEFAULT ('') FOR [UserID]
GO
ALTER TABLE [dbo].[MoneyLog] ADD  CONSTRAINT [DF_MoneyLog_UserName]  DEFAULT ('') FOR [UserName]
GO
ALTER TABLE [dbo].[MoneyLog] ADD  CONSTRAINT [DF_MoneyLog_Type]  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[MoneyLog] ADD  CONSTRAINT [DF_MoneyLog_OperationType]  DEFAULT ((0)) FOR [OperationType]
GO
ALTER TABLE [dbo].[MoneyLog] ADD  CONSTRAINT [DF_MoneyLog_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[MoneyLog] ADD  CONSTRAINT [DF_MoneyLog_CreateUID]  DEFAULT ('admin') FOR [CreateUID]
GO
ALTER TABLE [dbo].[MoneyLog] ADD  CONSTRAINT [DF_MoneyLog_EditUID]  DEFAULT ('') FOR [EditUID]
GO
ALTER TABLE [dbo].[MoneyLog] ADD  CONSTRAINT [DF_MoneyLog_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[MoneyLog] ADD  CONSTRAINT [DF_MoneyLog_IsEnable]  DEFAULT ((0)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_PrizeCode]  DEFAULT ((0)) FOR [AwardCode]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_ClueCode]  DEFAULT ((0)) FOR [ClueCode]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_UserID]  DEFAULT ('') FOR [UserID]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_Buy_Content]  DEFAULT ('') FOR [Buy_Content]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_BuyPayReturn]  DEFAULT ('') FOR [BuyPayReturn]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_BuyPayReturn2]  DEFAULT ('') FOR [BuyPayReturn2]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_MinPayReturn]  DEFAULT ((0.0)) FOR [MinPayReturn]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_MaxPayReturn]  DEFAULT ((0)) FOR [MaxPayReturn]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_Using_Money]  DEFAULT ((0)) FOR [Using_Money]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_Get_Money]  DEFAULT ((0)) FOR [Get_Money]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_Araw_ReturnMoney]  DEFAULT ((0)) FOR [Araw_ReturnMoney]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_Araw_RetrunContent]  DEFAULT ('') FOR [Araw_RetrunContent]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_Return_Money]  DEFAULT ((0)) FOR [Return_Money]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_IsWin]  DEFAULT ((3)) FOR [IsWin]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_Operation_Time]  DEFAULT (getdate()) FOR [Operation_Time]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_PayUID]  DEFAULT ('') FOR [PayUID]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_Type]  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF__Operation__Creat__239E4DCF]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF__Operation__Creat__24927208]  DEFAULT ('admin') FOR [CreateUID]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_Record_EditUID]  DEFAULT ('') FOR [EditUID]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_record_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Operation_Record] ADD  CONSTRAINT [DF_Operation_record_IsEnable]  DEFAULT ((0)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[Size_Six] ADD  CONSTRAINT [DF_Size_Six_Code]  DEFAULT ((0)) FOR [Code]
GO
ALTER TABLE [dbo].[Size_Six] ADD  CONSTRAINT [DF_Size_Six_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Size_Six] ADD  CONSTRAINT [DF_Size_Six_Globe]  DEFAULT ('') FOR [Globe]
GO
ALTER TABLE [dbo].[Size_Six] ADD  CONSTRAINT [DF_Size_Six_Award_Globe]  DEFAULT ((0)) FOR [Award_Globe]
GO
ALTER TABLE [dbo].[Size_Six] ADD  CONSTRAINT [DF__Size_Six__Create__34C8D9D1]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Size_Six] ADD  CONSTRAINT [DF__Size_Six__Create__35BCFE0A]  DEFAULT ('admin') FOR [CreateUID]
GO
ALTER TABLE [dbo].[Size_Six] ADD  CONSTRAINT [DF_Size_Six_EditUID]  DEFAULT ('') FOR [EditUID]
GO
ALTER TABLE [dbo].[Size_Six] ADD  CONSTRAINT [DF__Size_Six__IsDele__36B12243]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Size_Six] ADD  CONSTRAINT [DF__Size_Six__IsEnab__37A5467C]  DEFAULT ((0)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[Size_Special] ADD  CONSTRAINT [DF_Size_Special_Code]  DEFAULT ((0)) FOR [Code]
GO
ALTER TABLE [dbo].[Size_Special] ADD  CONSTRAINT [DF_Size_Special_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Size_Special] ADD  CONSTRAINT [DF_Size_Special_Globe]  DEFAULT ('') FOR [Globe]
GO
ALTER TABLE [dbo].[Size_Special] ADD  CONSTRAINT [DF__Size_Spec__Creat__3B75D760]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Size_Special] ADD  CONSTRAINT [DF__Size_Spec__Creat__3C69FB99]  DEFAULT ('admin') FOR [CreateUID]
GO
ALTER TABLE [dbo].[Size_Special] ADD  CONSTRAINT [DF_Size_Special_EditUID]  DEFAULT ('') FOR [EditUID]
GO
ALTER TABLE [dbo].[Size_Special] ADD  CONSTRAINT [DF__Size_Spec__IsDel__3D5E1FD2]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Size_Special] ADD  CONSTRAINT [DF__Size_Spec__IsEna__3E52440B]  DEFAULT ((0)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[Size_SpecialNormal] ADD  CONSTRAINT [DF_Size_SpecialNormal_Code]  DEFAULT ((0)) FOR [Code]
GO
ALTER TABLE [dbo].[Size_SpecialNormal] ADD  CONSTRAINT [DF_Size_SpecialNormal_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Size_SpecialNormal] ADD  CONSTRAINT [DF_Size_SpecialNormal_Globe]  DEFAULT ('') FOR [Globe]
GO
ALTER TABLE [dbo].[Size_SpecialNormal] ADD  CONSTRAINT [DF_Size_SpecialNormal_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Size_SpecialNormal] ADD  CONSTRAINT [DF_Size_SpecialNormal_CreateUIID]  DEFAULT ('admin') FOR [CreateUID]
GO
ALTER TABLE [dbo].[Size_SpecialNormal] ADD  CONSTRAINT [DF_Size_SpecialNormal_EditUID]  DEFAULT ('') FOR [EditUID]
GO
ALTER TABLE [dbo].[Size_SpecialNormal] ADD  CONSTRAINT [DF_Size_SpecialNormal_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Size_SpecialNormal] ADD  CONSTRAINT [DF_Size_SpecialNormal_IsEnable]  DEFAULT ((0)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[Size_Sum] ADD  CONSTRAINT [DF_Size_Sum_Code]  DEFAULT ((0)) FOR [Code]
GO
ALTER TABLE [dbo].[Size_Sum] ADD  CONSTRAINT [DF_Size_Sum_Globe]  DEFAULT ('') FOR [Globe]
GO
ALTER TABLE [dbo].[Size_Sum] ADD  CONSTRAINT [DF_Size_Sum_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Size_Sum] ADD  CONSTRAINT [DF__Size_Sum__Create__7D0E9093]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Size_Sum] ADD  CONSTRAINT [DF__Size_Sum__Create__7E02B4CC]  DEFAULT ('admin') FOR [CreateUID]
GO
ALTER TABLE [dbo].[Size_Sum] ADD  CONSTRAINT [DF_Size_Sum_EditUID]  DEFAULT ('') FOR [EditUID]
GO
ALTER TABLE [dbo].[Size_Sum] ADD  CONSTRAINT [DF__Size_Sum__IsDele__7EF6D905]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Size_Sum] ADD  CONSTRAINT [DF__Size_Sum__IsEnab__7FEAFD3E]  DEFAULT ((0)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_LoginName]  DEFAULT ('') FOR [LoginName]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_Password]  DEFAULT ('') FOR [Password]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_Salt]  DEFAULT ('') FOR [Salt]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_Money]  DEFAULT ((0)) FOR [Money]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_Role]  DEFAULT ((1)) FOR [Role]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_EnableTime]  DEFAULT ('3000-01-01 00:00:00.000') FOR [EnableTime]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_Remarks]  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF__UserInfo__Create__1A14E395]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF__UserInfo__Create__1B0907CE]  DEFAULT ('admin') FOR [CreateUID]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_EditUID]  DEFAULT ('') FOR [EditUID]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_IsEnable]  DEFAULT ((0)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[Wave] ADD  CONSTRAINT [DF_Wave_Code]  DEFAULT ((0)) FOR [Code]
GO
ALTER TABLE [dbo].[Wave] ADD  CONSTRAINT [DF_Wave_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Wave] ADD  CONSTRAINT [DF__Wave__CreateTime__4E88ABD4]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Wave] ADD  CONSTRAINT [DF__Wave__CreateUIID__4F7CD00D]  DEFAULT ('admin') FOR [CreateUID]
GO
ALTER TABLE [dbo].[Wave] ADD  CONSTRAINT [DF_Wave_EditUID]  DEFAULT ('') FOR [EditUID]
GO
ALTER TABLE [dbo].[Wave] ADD  CONSTRAINT [DF__Wave__IsDelete__5070F446]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Wave] ADD  CONSTRAINT [DF__Wave__IsEnable__5165187F]  DEFAULT ((0)) FOR [IsEnable]
GO
USE [master]
GO
ALTER DATABASE [TLC] SET  READ_WRITE 
GO
