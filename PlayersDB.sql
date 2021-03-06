USE [master]
GO
/****** Object:  Database [PlayersDB]    Script Date: 09/06/2022 15:12:01 ******/
CREATE DATABASE [PlayersDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PlayersDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PlayersDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PlayersDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PlayersDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PlayersDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PlayersDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PlayersDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PlayersDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PlayersDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PlayersDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PlayersDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PlayersDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PlayersDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PlayersDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PlayersDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PlayersDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PlayersDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PlayersDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PlayersDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PlayersDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PlayersDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PlayersDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PlayersDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PlayersDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PlayersDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PlayersDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PlayersDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PlayersDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PlayersDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PlayersDB] SET  MULTI_USER 
GO
ALTER DATABASE [PlayersDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PlayersDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PlayersDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PlayersDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PlayersDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PlayersDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PlayersDB] SET QUERY_STORE = OFF
GO
USE [PlayersDB]
GO
/****** Object:  Table [dbo].[characters]    Script Date: 09/06/2022 15:12:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[characters](
	[character_id] [int] IDENTITY(1,1) NOT NULL,
	[character_name] [varchar](20) NOT NULL,
	[character_level] [tinyint] NULL,
	[creation_date] [date] NULL,
	[player_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[character_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[characters_equipment]    Script Date: 09/06/2022 15:12:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[characters_equipment](
	[character_id] [int] NOT NULL,
	[equipment_id] [int] NOT NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[character_id] ASC,
	[equipment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[equipment]    Script Date: 09/06/2022 15:12:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[equipment](
	[equipment_id] [int] IDENTITY(1,1) NOT NULL,
	[equipment_name] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[equipment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[players]    Script Date: 09/06/2022 15:12:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[players](
	[player_id] [int] IDENTITY(1,1) NOT NULL,
	[player_name] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[player_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[characters] ON 

INSERT [dbo].[characters] ([character_id], [character_name], [character_level], [creation_date], [player_id]) VALUES (1, N'character 1 a', 1, CAST(N'2022-06-01' AS Date), 1)
INSERT [dbo].[characters] ([character_id], [character_name], [character_level], [creation_date], [player_id]) VALUES (3, N'character 2 b', 3, CAST(N'2022-06-01' AS Date), 2)
INSERT [dbo].[characters] ([character_id], [character_name], [character_level], [creation_date], [player_id]) VALUES (22, N'char 4 a', 1, CAST(N'2022-06-06' AS Date), 4)
INSERT [dbo].[characters] ([character_id], [character_name], [character_level], [creation_date], [player_id]) VALUES (23, N'char 5 a', 1, CAST(N'2022-06-06' AS Date), 9)
INSERT [dbo].[characters] ([character_id], [character_name], [character_level], [creation_date], [player_id]) VALUES (24, N'char 5 b', 2, CAST(N'2022-06-06' AS Date), 9)
INSERT [dbo].[characters] ([character_id], [character_name], [character_level], [creation_date], [player_id]) VALUES (25, N'char 5 c', 3, CAST(N'2022-06-06' AS Date), 9)
INSERT [dbo].[characters] ([character_id], [character_name], [character_level], [creation_date], [player_id]) VALUES (26, N'character 1 b', 1, CAST(N'2022-06-06' AS Date), 1)
INSERT [dbo].[characters] ([character_id], [character_name], [character_level], [creation_date], [player_id]) VALUES (27, N'character 1 c', 3, CAST(N'2022-06-07' AS Date), 1)
INSERT [dbo].[characters] ([character_id], [character_name], [character_level], [creation_date], [player_id]) VALUES (28, N'char 4 b', 10, CAST(N'2022-06-09' AS Date), 4)
INSERT [dbo].[characters] ([character_id], [character_name], [character_level], [creation_date], [player_id]) VALUES (30, N'character AAAA', 7, CAST(N'2022-06-09' AS Date), 23)
INSERT [dbo].[characters] ([character_id], [character_name], [character_level], [creation_date], [player_id]) VALUES (31, N'character', 3, CAST(N'2022-06-09' AS Date), 10)
SET IDENTITY_INSERT [dbo].[characters] OFF
GO
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (1, 1, 100)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (1, 2, 2)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (1, 3, 1)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (1, 4, 1)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (1, 5, 1)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (1, 6, 1)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (3, 1, 1)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (3, 2, 1)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (3, 4, 3)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (25, 6, 1)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (26, 1, 10)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (26, 2, 1)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (27, 2, 1)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (27, 3, 1)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (28, 1, 800)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (30, 1, 10000)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (31, 1, 1)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (31, 2, 1)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (31, 3, 1)
INSERT [dbo].[characters_equipment] ([character_id], [equipment_id], [quantity]) VALUES (31, 5, 10)
GO
SET IDENTITY_INSERT [dbo].[equipment] ON 

INSERT [dbo].[equipment] ([equipment_id], [equipment_name]) VALUES (4, N'book')
INSERT [dbo].[equipment] ([equipment_id], [equipment_name]) VALUES (1, N'coins')
INSERT [dbo].[equipment] ([equipment_id], [equipment_name]) VALUES (5, N'hat')
INSERT [dbo].[equipment] ([equipment_id], [equipment_name]) VALUES (6, N'iron')
INSERT [dbo].[equipment] ([equipment_id], [equipment_name]) VALUES (3, N'shield')
INSERT [dbo].[equipment] ([equipment_id], [equipment_name]) VALUES (2, N'sword')
SET IDENTITY_INSERT [dbo].[equipment] OFF
GO
SET IDENTITY_INSERT [dbo].[players] ON 

INSERT [dbo].[players] ([player_id], [player_name]) VALUES (1, N'player 1')
INSERT [dbo].[players] ([player_id], [player_name]) VALUES (2, N'player 2')
INSERT [dbo].[players] ([player_id], [player_name]) VALUES (4, N'player 4')
INSERT [dbo].[players] ([player_id], [player_name]) VALUES (9, N'player 5')
INSERT [dbo].[players] ([player_id], [player_name]) VALUES (10, N'player 6')
INSERT [dbo].[players] ([player_id], [player_name]) VALUES (11, N'player 7')
INSERT [dbo].[players] ([player_id], [player_name]) VALUES (12, N'player 8')
INSERT [dbo].[players] ([player_id], [player_name]) VALUES (22, N'player 9')
INSERT [dbo].[players] ([player_id], [player_name]) VALUES (23, N'player AAA')
SET IDENTITY_INSERT [dbo].[players] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__equipmen__FEECD80AC5C3C8A0]    Script Date: 09/06/2022 15:12:01 ******/
ALTER TABLE [dbo].[equipment] ADD UNIQUE NONCLUSTERED 
(
	[equipment_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__players__05B1D6A28FE053FF]    Script Date: 09/06/2022 15:12:01 ******/
ALTER TABLE [dbo].[players] ADD UNIQUE NONCLUSTERED 
(
	[player_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[characters] ADD  DEFAULT ((1)) FOR [character_level]
GO
ALTER TABLE [dbo].[characters] ADD  DEFAULT (getdate()) FOR [creation_date]
GO
ALTER TABLE [dbo].[characters_equipment] ADD  DEFAULT ((1)) FOR [quantity]
GO
ALTER TABLE [dbo].[characters]  WITH CHECK ADD FOREIGN KEY([player_id])
REFERENCES [dbo].[players] ([player_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[characters_equipment]  WITH CHECK ADD FOREIGN KEY([character_id])
REFERENCES [dbo].[characters] ([character_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[characters_equipment]  WITH CHECK ADD FOREIGN KEY([equipment_id])
REFERENCES [dbo].[equipment] ([equipment_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[characters]  WITH CHECK ADD CHECK  (([character_level]>=(1) AND [character_level]<=(100)))
GO
ALTER TABLE [dbo].[characters_equipment]  WITH CHECK ADD CHECK  (([quantity]>(0)))
GO
USE [master]
GO
ALTER DATABASE [PlayersDB] SET  READ_WRITE 
GO
