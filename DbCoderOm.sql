USE [master]
GO
/****** Object:  Database [DbCoderOm]    Script Date: 29-09-2023 14:21:38 ******/
CREATE DATABASE [DbCoderOm]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbCoderOm', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DbCoderOm.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DbCoderOm_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DbCoderOm_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DbCoderOm] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbCoderOm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbCoderOm] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbCoderOm] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbCoderOm] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbCoderOm] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbCoderOm] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbCoderOm] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DbCoderOm] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbCoderOm] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbCoderOm] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbCoderOm] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbCoderOm] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbCoderOm] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbCoderOm] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbCoderOm] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbCoderOm] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DbCoderOm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbCoderOm] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbCoderOm] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbCoderOm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbCoderOm] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbCoderOm] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DbCoderOm] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbCoderOm] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DbCoderOm] SET  MULTI_USER 
GO
ALTER DATABASE [DbCoderOm] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbCoderOm] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbCoderOm] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbCoderOm] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DbCoderOm] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DbCoderOm]
GO
/****** Object:  Table [dbo].[AboutDetailsTbl]    Script Date: 29-09-2023 14:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AboutDetailsTbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NickName] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
	[Logo] [nvarchar](max) NULL,
	[Image1] [nvarchar](max) NULL,
	[Image2] [nvarchar](max) NULL,
	[About] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[Instagram] [nvarchar](max) NULL,
	[Twitter] [nvarchar](max) NULL,
	[Youtube] [nvarchar](max) NULL,
	[Linkedin] [nvarchar](max) NULL,
	[Github] [nvarchar](max) NULL,
	[Resume] [nvarchar](max) NULL,
 CONSTRAINT [PK_AboutDetailsTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AdminTbl]    Script Date: 29-09-2023 14:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminTbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[uName] [nvarchar](max) NULL,
	[uPassword] [nvarchar](max) NULL,
 CONSTRAINT [PK_AdminTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectsTbl]    Script Date: 29-09-2023 14:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectsTbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Subtitle] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NULL,
	[Image1] [nvarchar](max) NULL,
	[Image2] [nvarchar](max) NULL,
	[Image3] [nvarchar](max) NULL,
	[Clientname] [nvarchar](max) NULL,
	[Year] [nvarchar](max) NULL,
	[Framework] [nvarchar](max) NULL,
	[LiveLink] [nvarchar](max) NULL,
	[status] [bit] NULL,
	[rts] [datetime] NULL,
 CONSTRAINT [PK_ProjectsTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AboutDetailsTbl] ON 

INSERT [dbo].[AboutDetailsTbl] ([Id], [Name], [NickName], [Role], [Logo], [Image1], [Image2], [About], [Address], [Email], [Mobile], [Instagram], [Twitter], [Youtube], [Linkedin], [Github], [Resume]) VALUES (1, N'Om Sharna', N'Coder Om', N'Coder', N'logo.png', N'Image1.jpg', N'Image2.jpg', N'As a highly dedicated .Net & Web developer with exceptional C# / MVC coding abilities, I bring all skills of programming to the table and am ready to leverage it to take your project to new heights. I deliver a hands-on approach to the entire creative process, ensuring that each project is curated with the utmost attention from inception to final delivery.', N'Sanjay Colony, Bhilwara, Rajasthan', N'mail.coderom@gmail.com', N'8999292525', N'https://www.instagram.com/coder.om/', N'https://twitter.com/1omsharma', N'https://www.youtube.com/@OmSharmaVlogss', N'https://www.linkedin.com/in/1omsharma/', NULL, N'Om Sharma Resume.pdf')
SET IDENTITY_INSERT [dbo].[AboutDetailsTbl] OFF
SET IDENTITY_INSERT [dbo].[AdminTbl] ON 

INSERT [dbo].[AdminTbl] ([Id], [uName], [uPassword]) VALUES (1, N'1', N'1')
SET IDENTITY_INSERT [dbo].[AdminTbl] OFF
SET IDENTITY_INSERT [dbo].[ProjectsTbl] ON 

INSERT [dbo].[ProjectsTbl] ([Id], [Title], [Subtitle], [Detail], [Image1], [Image2], [Image3], [Clientname], [Year], [Framework], [LiveLink], [status], [rts]) VALUES (1, N'Hotels To Stay', N'Experience the various exciting tour and travel packages and Make hotel reservations, find vacation packages, search cheap hotels and events', NULL, N'1.png', N'b_1.png', N'c_.png', N'SPMPL', N'2022', N'ASP.NET C#', N'http://placestogo.spmpltech.com/', 1, CAST(N'2023-09-29 12:43:36.027' AS DateTime))
INSERT [dbo].[ProjectsTbl] ([Id], [Title], [Subtitle], [Detail], [Image1], [Image2], [Image3], [Clientname], [Year], [Framework], [LiveLink], [status], [rts]) VALUES (2, N'Places To Go', N'Find The Right Place', NULL, N'2.png', N'b_2.png', N'c_.png', N'SPMPL', N'2022', N'ASP.NET C#', N'http://placestogoto.com/', 1, CAST(N'2023-09-29 12:43:54.527' AS DateTime))
INSERT [dbo].[ProjectsTbl] ([Id], [Title], [Subtitle], [Detail], [Image1], [Image2], [Image3], [Clientname], [Year], [Framework], [LiveLink], [status], [rts]) VALUES (3, N'Ananya Fashion', NULL, NULL, N'3.png', N'b_3.png', N'c_.png', N'Ananya Fashion', N'2023', N'ASP.NET C#', N'https://ananyafashionjaipur.com/', 1, CAST(N'2023-09-29 12:44:07.943' AS DateTime))
INSERT [dbo].[ProjectsTbl] ([Id], [Title], [Subtitle], [Detail], [Image1], [Image2], [Image3], [Clientname], [Year], [Framework], [LiveLink], [status], [rts]) VALUES (4, N'Study Rooms', N'FIND YOUR DREAM HOUSE. Find new & featured property located in your local city.', NULL, N'4.png', N'b_4.png', N'c_.png', N'CodXTech', N'2023', N'ASP.NET MVC', NULL, 1, CAST(N'2023-09-29 12:48:15.290' AS DateTime))
INSERT [dbo].[ProjectsTbl] ([Id], [Title], [Subtitle], [Detail], [Image1], [Image2], [Image3], [Clientname], [Year], [Framework], [LiveLink], [status], [rts]) VALUES (5, N'Temple Duniya', NULL, NULL, N'5.png', N'b_5.png', N'c_.png', N'SPMPL', N'2023', N'ASP.NET MVC Ajax', NULL, 1, CAST(N'2023-09-29 12:51:47.643' AS DateTime))
INSERT [dbo].[ProjectsTbl] ([Id], [Title], [Subtitle], [Detail], [Image1], [Image2], [Image3], [Clientname], [Year], [Framework], [LiveLink], [status], [rts]) VALUES (6, N'Shree Shanta Synfab LLP', NULL, NULL, N'6.png', N'b_6.png', N'c_.png', N'Shree Shanta Synfab LLP', N'2023', N'ASP.NET MVC Ajax', N'http://shreeshantasynfabllp.databoltahai.in/', 1, CAST(N'2023-09-29 12:57:34.423' AS DateTime))
INSERT [dbo].[ProjectsTbl] ([Id], [Title], [Subtitle], [Detail], [Image1], [Image2], [Image3], [Clientname], [Year], [Framework], [LiveLink], [status], [rts]) VALUES (7, N'Deepti Pencil Arts', NULL, NULL, N'7.png', N'b_7.png', N'c_.png', N'Data Bolta Hai', N'2022', N'ASP.NET MVC Ajax', N'http://deeptiarts.databoltahai.in/', 1, CAST(N'2023-09-29 13:00:10.877' AS DateTime))
SET IDENTITY_INSERT [dbo].[ProjectsTbl] OFF
USE [master]
GO
ALTER DATABASE [DbCoderOm] SET  READ_WRITE 
GO
