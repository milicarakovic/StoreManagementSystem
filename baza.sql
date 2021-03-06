USE [master]
GO
/****** Object:  Database [baza]    Script Date: 1/24/2020 3:30:54 PM ******/
CREATE DATABASE [baza]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'baza', FILENAME = N'C:\Users\milic\baza.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'baza_log', FILENAME = N'C:\Users\milic\baza_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [baza] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [baza].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [baza] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [baza] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [baza] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [baza] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [baza] SET ARITHABORT OFF 
GO
ALTER DATABASE [baza] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [baza] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [baza] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [baza] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [baza] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [baza] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [baza] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [baza] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [baza] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [baza] SET  DISABLE_BROKER 
GO
ALTER DATABASE [baza] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [baza] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [baza] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [baza] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [baza] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [baza] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [baza] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [baza] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [baza] SET  MULTI_USER 
GO
ALTER DATABASE [baza] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [baza] SET DB_CHAINING OFF 
GO
ALTER DATABASE [baza] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [baza] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [baza] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [baza] SET QUERY_STORE = OFF
GO
USE [baza]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [baza]
GO
/****** Object:  Table [dbo].[Korisnici]    Script Date: 1/24/2020 3:30:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnici](
	[IDKorisnika] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nchar](15) NULL,
	[Prezime] [nchar](15) NULL,
	[Telefon] [nchar](15) NULL,
	[Email] [nchar](20) NULL,
	[KorisnickoIme] [nchar](20) NOT NULL,
	[Lozinka] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Korisnici] PRIMARY KEY CLUSTERED 
(
	[IDKorisnika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Porudzbina]    Script Date: 1/24/2020 3:30:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Porudzbina](
	[SifraPorudzbine] [int] IDENTITY(1,1) NOT NULL,
	[DatumPorudzbine] [datetime] NULL,
	[RokPrispeca] [datetime] NULL,
	[UkupanIznos] [float] NULL,
	[KorisnikID] [int] NOT NULL,
 CONSTRAINT [PK_Porudzbina] PRIMARY KEY CLUSTERED 
(
	[SifraPorudzbine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proizvodi]    Script Date: 1/24/2020 3:30:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proizvodi](
	[IDProizvoda] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [varchar](50) NULL,
	[Cena] [float] NULL,
	[Proizvodjac] [int] NULL,
 CONSTRAINT [PK_Proizvodi] PRIMARY KEY CLUSTERED 
(
	[IDProizvoda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proizvodjaci]    Script Date: 1/24/2020 3:30:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proizvodjaci](
	[IDProizvodjaca] [int] NOT NULL,
	[Naziv] [varchar](50) NOT NULL,
	[Adresa] [varchar](50) NULL,
	[Kontakt] [varchar](50) NULL,
	[Mejl] [varchar](50) NULL,
	[MaticniBroj] [int] NOT NULL,
	[PIB] [int] NOT NULL,
 CONSTRAINT [PK_Proizvodjaci] PRIMARY KEY CLUSTERED 
(
	[IDProizvodjaca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkaPorudzbine]    Script Date: 1/24/2020 3:30:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkaPorudzbine](
	[RedniBroj] [int] IDENTITY(1,1) NOT NULL,
	[Kolicina] [int] NULL,
	[Cena] [float] NULL,
	[IznosStavke] [float] NULL,
	[SifraPorudzbine] [int] NOT NULL,
	[ProizvodID] [int] NULL,
 CONSTRAINT [PK_StavkaPorudzbine] PRIMARY KEY CLUSTERED 
(
	[RedniBroj] ASC,
	[SifraPorudzbine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Korisnici] ON 

INSERT [dbo].[Korisnici] ([IDKorisnika], [Ime], [Prezime], [Telefon], [Email], [KorisnickoIme], [Lozinka]) VALUES (1, N'Pera           ', N'Peric          ', N'+011123234     ', N'js@                 ', N'aaa                 ', N'aaa                 ')
INSERT [dbo].[Korisnici] ([IDKorisnika], [Ime], [Prezime], [Telefon], [Email], [KorisnickoIme], [Lozinka]) VALUES (3, N'Korisnik       ', N'Korisnik       ', N'+381456123     ', N'korisnik@gmail.com  ', N'korisnik1           ', N'korisnik1           ')
INSERT [dbo].[Korisnici] ([IDKorisnika], [Ime], [Prezime], [Telefon], [Email], [KorisnickoIme], [Lozinka]) VALUES (5005, N'Luka           ', N'Petrovic       ', N'+38164111122   ', N'petrovic@email.com  ', N'petrovic            ', N'petrovic            ')
SET IDENTITY_INSERT [dbo].[Korisnici] OFF
SET IDENTITY_INSERT [dbo].[Porudzbina] ON 

INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (1, CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 4, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (2, CAST(N'2020-01-13T19:16:17.000' AS DateTime), CAST(N'2020-01-16T19:16:17.000' AS DateTime), 6, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (3, CAST(N'2020-01-13T19:18:03.000' AS DateTime), CAST(N'2020-01-18T19:18:03.000' AS DateTime), 1302, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (1002, CAST(N'2020-01-14T22:37:27.000' AS DateTime), CAST(N'2020-01-20T22:37:27.000' AS DateTime), 34940, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (2002, CAST(N'2020-01-15T22:42:48.000' AS DateTime), CAST(N'2020-01-19T22:42:48.000' AS DateTime), 10, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (2003, CAST(N'2020-01-15T22:43:56.000' AS DateTime), CAST(N'2020-01-18T22:43:56.000' AS DateTime), 6, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (2004, CAST(N'2020-01-15T22:44:32.000' AS DateTime), CAST(N'2020-01-18T22:44:32.000' AS DateTime), 6, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (2005, CAST(N'2020-01-15T22:45:37.000' AS DateTime), CAST(N'2020-01-18T22:45:37.000' AS DateTime), 6, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (2006, CAST(N'2020-01-16T00:01:54.000' AS DateTime), CAST(N'2020-01-19T00:01:54.000' AS DateTime), 4, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (3002, CAST(N'2020-01-16T00:51:29.000' AS DateTime), CAST(N'2020-01-21T00:51:29.000' AS DateTime), 8, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (3003, CAST(N'2020-01-16T00:52:27.000' AS DateTime), CAST(N'2020-01-19T00:52:27.000' AS DateTime), 102.6, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (3004, CAST(N'2020-01-16T00:55:15.000' AS DateTime), CAST(N'2020-01-19T00:55:15.000' AS DateTime), 6, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (3005, CAST(N'2020-01-16T01:00:21.000' AS DateTime), CAST(N'2020-01-20T01:00:21.000' AS DateTime), 8, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (3006, CAST(N'2020-01-16T01:00:51.000' AS DateTime), CAST(N'2020-01-19T01:00:51.000' AS DateTime), 6, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (3007, CAST(N'2020-01-16T01:02:10.000' AS DateTime), CAST(N'2020-01-19T01:02:10.000' AS DateTime), 6, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (3008, CAST(N'2020-01-16T01:02:36.000' AS DateTime), CAST(N'2020-01-20T01:02:36.000' AS DateTime), 8, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (3009, CAST(N'2020-01-16T01:12:33.000' AS DateTime), CAST(N'2020-01-19T01:12:33.000' AS DateTime), 6, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (4002, CAST(N'2020-01-16T17:28:18.000' AS DateTime), CAST(N'2020-01-18T17:28:18.000' AS DateTime), 193.2, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (5002, CAST(N'2020-01-18T14:21:45.000' AS DateTime), CAST(N'2020-01-21T14:21:45.000' AS DateTime), 377, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (5003, CAST(N'2020-01-18T14:22:59.000' AS DateTime), CAST(N'2020-01-21T14:22:59.000' AS DateTime), 377, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (5004, CAST(N'2020-01-18T14:25:10.000' AS DateTime), CAST(N'2020-01-21T14:25:10.000' AS DateTime), 1673, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (5005, CAST(N'2020-01-18T14:26:43.000' AS DateTime), CAST(N'2020-01-20T14:26:43.000' AS DateTime), 492, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (5006, CAST(N'2020-01-18T14:26:59.000' AS DateTime), CAST(N'2020-01-20T14:26:59.000' AS DateTime), 492, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (5007, CAST(N'2020-01-18T14:27:49.000' AS DateTime), CAST(N'2020-01-20T14:27:49.000' AS DateTime), 492, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (5008, CAST(N'2020-01-18T14:32:29.000' AS DateTime), CAST(N'2020-01-21T14:32:29.000' AS DateTime), 10, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (6002, CAST(N'2020-01-20T11:28:20.000' AS DateTime), CAST(N'2020-01-23T11:28:20.000' AS DateTime), 6, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (7002, CAST(N'2020-01-20T14:39:32.000' AS DateTime), CAST(N'2020-01-23T14:39:32.000' AS DateTime), 167, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (8002, CAST(N'2020-01-20T16:23:03.000' AS DateTime), CAST(N'2020-01-24T16:23:03.000' AS DateTime), 53342, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (9002, CAST(N'2020-01-22T15:40:43.000' AS DateTime), CAST(N'2020-01-26T15:40:43.000' AS DateTime), 666, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (10002, CAST(N'2020-01-23T16:35:14.000' AS DateTime), CAST(N'2020-01-27T16:35:14.000' AS DateTime), 1428.6, 1)
INSERT [dbo].[Porudzbina] ([SifraPorudzbine], [DatumPorudzbine], [RokPrispeca], [UkupanIznos], [KorisnikID]) VALUES (10003, CAST(N'2020-01-23T16:37:05.000' AS DateTime), CAST(N'2020-01-25T16:37:05.000' AS DateTime), 4333.36, 1)
SET IDENTITY_INSERT [dbo].[Porudzbina] OFF
SET IDENTITY_INSERT [dbo].[Proizvodi] ON 

INSERT [dbo].[Proizvodi] ([IDProizvoda], [Naziv], [Cena], [Proizvodjac]) VALUES (1, N'Izmena1', 111, 1)
INSERT [dbo].[Proizvodi] ([IDProizvoda], [Naziv], [Cena], [Proizvodjac]) VALUES (2, N'Proizvod1', 8734, 1)
INSERT [dbo].[Proizvodi] ([IDProizvoda], [Naziv], [Cena], [Proizvodjac]) VALUES (3, N'proizvod2', 32.2, 2)
INSERT [dbo].[Proizvodi] ([IDProizvoda], [Naziv], [Cena], [Proizvodjac]) VALUES (4, N'Proizvod3', 432, 1)
INSERT [dbo].[Proizvodi] ([IDProizvoda], [Naziv], [Cena], [Proizvodjac]) VALUES (1001, N'Proizvod4', 1000.09, 1)
SET IDENTITY_INSERT [dbo].[Proizvodi] OFF
INSERT [dbo].[Proizvodjaci] ([IDProizvodjaca], [Naziv], [Adresa], [Kontakt], [Mejl], [MaticniBroj], [PIB]) VALUES (1, N'Proizvodjac1', N'Cerski venac 10,', N'+38164888888', N'proizvodjac@gmail.com', 23123, 4232123)
INSERT [dbo].[Proizvodjaci] ([IDProizvodjaca], [Naziv], [Adresa], [Kontakt], [Mejl], [MaticniBroj], [PIB]) VALUES (2, N'Proizvodjac2', N'Ulica Pere Perica', N'+3815656', N'pr@gmail.com', 5465, 531651)
SET IDENTITY_INSERT [dbo].[StavkaPorudzbine] ON 

INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (4, 4, 2, 8, 3008, 1)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (5, 3, 2, 6, 3009, 1)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (1002, 6, 32.2, 193.2, 4002, 3)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (2002, 4, 2, 8, 5002, 1)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (2003, 3, 123, 369, 5002, 1001)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (2004, 4, 2, 8, 5003, 1)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (2005, 3, 123, 369, 5003, 1001)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (2006, 4, 2, 8, 5004, 1)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (2007, 3, 123, 369, 5004, 1001)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (2008, 3, 432, 1296, 5004, 4)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (2009, 4, 123, 492, 5005, 1001)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (2010, 4, 123, 492, 5006, 1001)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (2011, 4, 123, 492, 5007, 1001)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (2012, 5, 2, 10, 5008, 1)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (3002, 3, 2, 6, 6002, 1)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (4002, 3, 2, 6, 7002, 1)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (4003, 5, 32.2, 161, 7002, 3)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (5002, 3, 8734, 26202, 8002, 2)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (5003, 5, 32.2, 161, 8002, 3)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (6002, 6, 111, 666, 9002, 1)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (7002, 12, 111, 1332, 10002, 1)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (7003, 3, 32.2, 96.6, 10002, 3)
INSERT [dbo].[StavkaPorudzbine] ([RedniBroj], [Kolicina], [Cena], [IznosStavke], [SifraPorudzbine], [ProizvodID]) VALUES (7004, 4, 1000.09, 4000.36, 10003, 1001)
SET IDENTITY_INSERT [dbo].[StavkaPorudzbine] OFF
ALTER TABLE [dbo].[Porudzbina]  WITH CHECK ADD  CONSTRAINT [FK_Porudzbina_Korisnici] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnici] ([IDKorisnika])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Porudzbina] CHECK CONSTRAINT [FK_Porudzbina_Korisnici]
GO
ALTER TABLE [dbo].[Proizvodi]  WITH CHECK ADD  CONSTRAINT [FK_Proizvodi_Proizvodjaci1] FOREIGN KEY([Proizvodjac])
REFERENCES [dbo].[Proizvodjaci] ([IDProizvodjaca])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Proizvodi] CHECK CONSTRAINT [FK_Proizvodi_Proizvodjaci1]
GO
ALTER TABLE [dbo].[StavkaPorudzbine]  WITH CHECK ADD  CONSTRAINT [FK_StavkaPorudzbine_Porudzbina] FOREIGN KEY([SifraPorudzbine])
REFERENCES [dbo].[Porudzbina] ([SifraPorudzbine])
GO
ALTER TABLE [dbo].[StavkaPorudzbine] CHECK CONSTRAINT [FK_StavkaPorudzbine_Porudzbina]
GO
ALTER TABLE [dbo].[StavkaPorudzbine]  WITH CHECK ADD  CONSTRAINT [FK_StavkaPorudzbine_Proizvodi] FOREIGN KEY([ProizvodID])
REFERENCES [dbo].[Proizvodi] ([IDProizvoda])
GO
ALTER TABLE [dbo].[StavkaPorudzbine] CHECK CONSTRAINT [FK_StavkaPorudzbine_Proizvodi]
GO
USE [master]
GO
ALTER DATABASE [baza] SET  READ_WRITE 
GO
