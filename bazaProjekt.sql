USE [master]
GO
/****** Object:  Database [ATM]    Script Date: 16.02.2024 01:35:54 ******/
CREATE DATABASE [ATM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ATM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ATM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ATM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ATM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ATM] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ATM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ATM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ATM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ATM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ATM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ATM] SET ARITHABORT OFF 
GO
ALTER DATABASE [ATM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ATM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ATM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ATM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ATM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ATM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ATM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ATM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ATM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ATM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ATM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ATM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ATM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ATM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ATM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ATM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ATM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ATM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ATM] SET  MULTI_USER 
GO
ALTER DATABASE [ATM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ATM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ATM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ATM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ATM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ATM] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ATM] SET QUERY_STORE = ON
GO
ALTER DATABASE [ATM] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ATM]
GO
/****** Object:  Table [dbo].[Banki]    Script Date: 16.02.2024 01:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banki](
	[id_bank] [int] IDENTITY(1,1) NOT NULL,
	[nazwa_banku] [varchar](30) NULL,
	[typ_banku] [varchar](30) NULL,
	[rok_powstania] [date] NULL,
	[krs] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_bank] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banknoty]    Script Date: 16.02.2024 01:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banknoty](
	[id_banknot] [int] IDENTITY(1,1) NOT NULL,
	[nominał] [varchar](10) NULL,
	[ilość] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_banknot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Klienci]    Script Date: 16.02.2024 01:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klienci](
	[id_klient] [int] IDENTITY(1,1) NOT NULL,
	[imię] [varchar](20) NULL,
	[nazwisko] [varchar](30) NULL,
	[stan_konta] [int] NULL,
	[PIN] [int] NULL,
	[nr_karty] [bigint] NULL,
	[typ_karty] [varchar](20) NULL,
	[id_bank] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_klient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[szczegóły_transakcji]    Script Date: 16.02.2024 01:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[szczegóły_transakcji](
	[id_szczegóły_transakcji] [int] IDENTITY(1,1) NOT NULL,
	[id_transakcja] [int] NULL,
	[id_banknot] [int] NULL,
	[ilość] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_szczegóły_transakcji] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transakcje]    Script Date: 16.02.2024 01:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transakcje](
	[id_transakcja] [int] IDENTITY(1,1) NOT NULL,
	[id_klient] [int] NULL,
	[kwota] [int] NULL,
	[typ_transakcji] [varchar](30) NULL,
	[data_transakcji] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_transakcja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Banki] ON 

INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1, N'mbank3', N'komercyjny3', CAST(N'2001-06-13' AS Date), 8723)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (2, N'mbank5', N'komercyjny2', CAST(N'1986-02-11' AS Date), 8723)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1004, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1005, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1006, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1007, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1008, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1009, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1010, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1011, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1012, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1013, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1014, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1015, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1016, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1017, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1018, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1019, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1020, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1021, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1022, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1023, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1024, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1025, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1026, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1027, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1028, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1029, N'mbank5', N'komercyjny', NULL, 1234)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1030, N'Nowy B', N'Komercyjny3', NULL, 0)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1031, N'Nowy B', N'Komercyjny3', NULL, 0)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1032, N'Nowy Ba', N'Komercyjny3', NULL, 0)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1033, N'Nowy Ba', N'Komercyjny3', NULL, 0)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1034, N'Nowy Bas', N'Komercyjny3', NULL, 0)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1035, N'Nowy Bas', N'Komercyjny3', NULL, 0)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1036, N'Nowy Bas', N'Komercyjny3', NULL, 0)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1037, N'Nowy Bas', N'Komercyjny3', NULL, 0)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1038, N'Nowy Bas', N'Komercyjny3', NULL, 0)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1039, N'Nowy Michas', N'Komercyjny40', NULL, 0)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1040, N'Nowy Adas', N'Komercyjny45', NULL, 0)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1041, N'Nowy Adas', N'Komercyjny45', NULL, 0)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1042, N'Nowy Adas', N'Komercyjny45', NULL, 0)
INSERT [dbo].[Banki] ([id_bank], [nazwa_banku], [typ_banku], [rok_powstania], [krs]) VALUES (1043, N'Nowy Adas', N'Komercyjny45', NULL, 0)
SET IDENTITY_INSERT [dbo].[Banki] OFF
GO
SET IDENTITY_INSERT [dbo].[Banknoty] ON 

INSERT [dbo].[Banknoty] ([id_banknot], [nominał], [ilość]) VALUES (1, N'20', 110)
INSERT [dbo].[Banknoty] ([id_banknot], [nominał], [ilość]) VALUES (2, N'50', 77)
INSERT [dbo].[Banknoty] ([id_banknot], [nominał], [ilość]) VALUES (3, N'100', 149)
INSERT [dbo].[Banknoty] ([id_banknot], [nominał], [ilość]) VALUES (4, N'200', 100)
INSERT [dbo].[Banknoty] ([id_banknot], [nominał], [ilość]) VALUES (5, N'500', 50)
SET IDENTITY_INSERT [dbo].[Banknoty] OFF
GO
SET IDENTITY_INSERT [dbo].[Klienci] ON 

INSERT [dbo].[Klienci] ([id_klient], [imię], [nazwisko], [stan_konta], [PIN], [nr_karty], [typ_karty], [id_bank]) VALUES (1, N'Agnieszka', N'Jankowska', 800, 1248, 3712904567890123, N'Mastercard', 2)
INSERT [dbo].[Klienci] ([id_klient], [imię], [nazwisko], [stan_konta], [PIN], [nr_karty], [typ_karty], [id_bank]) VALUES (2, N'Michał', N'Wojciechowski', 150, 8205, 2813456789012345, N'Discover', 1)
INSERT [dbo].[Klienci] ([id_klient], [imię], [nazwisko], [stan_konta], [PIN], [nr_karty], [typ_karty], [id_bank]) VALUES (3, N'Anna', N'Kowalska', 2500, 4821, 4123456789012345, N'Visa', 1)
INSERT [dbo].[Klienci] ([id_klient], [imię], [nazwisko], [stan_konta], [PIN], [nr_karty], [typ_karty], [id_bank]) VALUES (4, N'Jan', N'Nowak', 1200, 7382, 5210345678901234, N'Mastercard', 2)
INSERT [dbo].[Klienci] ([id_klient], [imię], [nazwisko], [stan_konta], [PIN], [nr_karty], [typ_karty], [id_bank]) VALUES (5, N'Marta', N'Wiśniewska', 500, 9614, 6012783456789012, N'AmericanExpress', 1)
INSERT [dbo].[Klienci] ([id_klient], [imię], [nazwisko], [stan_konta], [PIN], [nr_karty], [typ_karty], [id_bank]) VALUES (6, N'Paweł', N'Lewandowski', 3200, 5738, 4910567823456789, N'Visa', 2)
SET IDENTITY_INSERT [dbo].[Klienci] OFF
GO
ALTER TABLE [dbo].[Banki] ADD  DEFAULT (NULL) FOR [nazwa_banku]
GO
ALTER TABLE [dbo].[Banki] ADD  DEFAULT (NULL) FOR [typ_banku]
GO
ALTER TABLE [dbo].[Banki] ADD  DEFAULT ((0)) FOR [krs]
GO
ALTER TABLE [dbo].[Banknoty] ADD  DEFAULT (NULL) FOR [nominał]
GO
ALTER TABLE [dbo].[Banknoty] ADD  DEFAULT (NULL) FOR [ilość]
GO
ALTER TABLE [dbo].[Klienci] ADD  DEFAULT (NULL) FOR [imię]
GO
ALTER TABLE [dbo].[Klienci] ADD  DEFAULT (NULL) FOR [nazwisko]
GO
ALTER TABLE [dbo].[Klienci] ADD  DEFAULT (NULL) FOR [stan_konta]
GO
ALTER TABLE [dbo].[Klienci] ADD  DEFAULT (NULL) FOR [PIN]
GO
ALTER TABLE [dbo].[Klienci] ADD  DEFAULT ((0)) FOR [nr_karty]
GO
ALTER TABLE [dbo].[Klienci] ADD  DEFAULT (NULL) FOR [typ_karty]
GO
ALTER TABLE [dbo].[szczegóły_transakcji] ADD  DEFAULT ((0)) FOR [ilość]
GO
ALTER TABLE [dbo].[Transakcje] ADD  DEFAULT (NULL) FOR [kwota]
GO
ALTER TABLE [dbo].[Transakcje] ADD  DEFAULT (NULL) FOR [typ_transakcji]
GO
ALTER TABLE [dbo].[Klienci]  WITH CHECK ADD FOREIGN KEY([id_bank])
REFERENCES [dbo].[Banki] ([id_bank])
GO
ALTER TABLE [dbo].[szczegóły_transakcji]  WITH CHECK ADD FOREIGN KEY([id_banknot])
REFERENCES [dbo].[Banknoty] ([id_banknot])
GO
ALTER TABLE [dbo].[szczegóły_transakcji]  WITH CHECK ADD FOREIGN KEY([id_transakcja])
REFERENCES [dbo].[Transakcje] ([id_transakcja])
GO
ALTER TABLE [dbo].[Transakcje]  WITH CHECK ADD FOREIGN KEY([id_klient])
REFERENCES [dbo].[Klienci] ([id_klient])
GO
USE [master]
GO
ALTER DATABASE [ATM] SET  READ_WRITE 
GO
