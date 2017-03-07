USE [master]
GO
/****** Object:  Database [EmployeesDb]    Script Date: 07.03.2017 г. 15:37:46 ******/
CREATE DATABASE [EmployeesDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeesDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MYSQLEXPRESSDB\MSSQL\DATA\EmployeesDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeesDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MYSQLEXPRESSDB\MSSQL\DATA\EmployeesDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EmployeesDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeesDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeesDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeesDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeesDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeesDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeesDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeesDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeesDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeesDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeesDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeesDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeesDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeesDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeesDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeesDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeesDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeesDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeesDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeesDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeesDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeesDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeesDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeesDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeesDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmployeesDb] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeesDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeesDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeesDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeesDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeesDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeesDb] SET QUERY_STORE = OFF
GO
USE [EmployeesDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [EmployeesDb]
GO
/****** Object:  Table [dbo].[CEOs]    Script Date: 07.03.2017 г. 15:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CEOs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Salary] [float] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CEO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeliveryDirectors]    Script Date: 07.03.2017 г. 15:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryDirectors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Salary] [float] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[ManagerId] [int] NOT NULL,
 CONSTRAINT [PK_DeliveryDirectors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Intermediates]    Script Date: 07.03.2017 г. 15:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Intermediates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Salary] [float] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ManagerId] [int] NULL,
 CONSTRAINT [PK_Intermediates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Juniors]    Script Date: 07.03.2017 г. 15:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Juniors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Salary] [float] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ManagerId] [int] NULL,
 CONSTRAINT [PK_Juniors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectManagers]    Script Date: 07.03.2017 г. 15:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectManagers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Salary] [float] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[ManagerId] [int] NOT NULL,
 CONSTRAINT [PK_ProjectManagers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 07.03.2017 г. 15:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](50) NOT NULL,
	[ManagerId] [int] NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Seniors]    Script Date: 07.03.2017 г. 15:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seniors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Salary] [float] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ManagerId] [int] NULL,
 CONSTRAINT [PK_Seniors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TeamLeaders]    Script Date: 07.03.2017 г. 15:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamLeaders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Salary] [float] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ManagerId] [int] NULL,
 CONSTRAINT [PK_TeamLeaders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Trainees]    Script Date: 07.03.2017 г. 15:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Salary] [float] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ManagerId] [int] NULL,
 CONSTRAINT [PK_Trainee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CEOs] ON 

INSERT [dbo].[CEOs] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone]) VALUES (1, N'Bill Gates', N'CEO', 1000000, N'Washington', N'unclebill@microsoft.com', N'0555656565')
SET IDENTITY_INSERT [dbo].[CEOs] OFF
SET IDENTITY_INSERT [dbo].[DeliveryDirectors] ON 

INSERT [dbo].[DeliveryDirectors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ManagerId]) VALUES (1, N'Steve Jobs', N'Delivery Director', 850000, N'San Francisco', N'stevejobs@apple.com', N'0555230320', 1)
INSERT [dbo].[DeliveryDirectors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ManagerId]) VALUES (2, N'Mark Zuckerberg', N'Delivery Director', 750000, N'Palo Alto', N'zuckerberg@facebook.com', N'0555650650', 1)
SET IDENTITY_INSERT [dbo].[DeliveryDirectors] OFF
SET IDENTITY_INSERT [dbo].[Intermediates] ON 

INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (1, N'Ivan Petrov', N'Intermediate', 3500, N'Sofia', N'ivanpetrov@soft.bg', N'0898469888', 1, 1)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (2, N'Venera Petkova', N'Intermediate', 3500, N'Sofia', N'petkova@soft.bg', N'0898114966', 2, 2)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (3, N'Vladimir Vladimirov', N'Intermediate', 2500, N'Plovdiv', N'vladivladimirov@soft.bg', N'0898123344', 2, 2)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (4, N'Ivanka Dimitrova', N'Intermediate', 2500, N'Plovdiv', N'idimitrova@soft.bg', N'0898137796', 3, 3)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (5, N'David Marshal', N'Intermediate', 3500, N'London', N'davidm@soft.com', N'0420521336', 1, 1)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (6, N'Dimitar Genadiev', N'Intermediate', 2500, N'Sofia', N'dimgenadiev@soft.bg', N'0898010305', 1, 1)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (7, N'Lidia Tsvetkova', N'Intermediate', 3000, N'Plovdiv', N'tsvetkova@soft.bg', N'0898644478', 2, 2)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (8, N'David Green', N'Intermediate', 3500, N'London', N'dgreen@soft.com', N'0420521334', 3, 3)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (9, N'Asen Zlatarov', N'Intermediate', 3000, N'Sofia', N'zlatarov@soft.bg', N'0898998788', 4, 4)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (10, N'Andrei Petrov', N'Intermediate', 3000, N'Varna', N'andreipetrov@soft.bg', N'0898468993', 3, 3)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (11, N'Conor Lee', N'Intermediate', 3000, N'New York', N'conorlee@soft.com', N'0555151218', 4, 4)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (12, N'Rumen Atanasov', N'Intermediate', 3000, N'Sofia', N'ratanasov@soft.bg', N'0898346999', 5, 5)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (13, N'Atanas Georgiev', N'Intermediate', 3000, N'Sofia', N'atanasgeorgiev@soft.bg', N'0898196664', 6, 6)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (14, N'Ivan Ivanov', N'Intermediate', 3000, N'Sofia', N'ivan_ivanov@soft.bg', N'0898346991', 7, 7)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (15, N'Naiden Naidenov', N'Intermediate', 2500, N'Varna', N'naidenov@soft.bg', N'0898001330', 4, 4)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (16, N'Kornelia Tsoneva', N'Intermediate', 2500, N'Plovdiv', N'tsoneva@soft.bg', N'0898466001', 5, 5)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (17, N'Kremena Ivanova', N'Intermediate', 2500, N'Sofia', N'kremena@soft.bg', N'0898443000', 5, 5)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (18, N'Lilian Stoyanov', N'Intermediate', 2500, N'Sofia', N'lilian@soft.bg', N'0898166640', 6, 6)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (19, N'Stefan Georgiev', N'Intermediate', 3000, N'Sofia', N'stef@soft.bg', N'0898970089', 8, 8)
INSERT [dbo].[Intermediates] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (20, N'Milen Radukanov', N'Intermediate', 2500, N'Vidin', N'radukanov@soft.bg', N'0898001977', 9, NULL)
SET IDENTITY_INSERT [dbo].[Intermediates] OFF
SET IDENTITY_INSERT [dbo].[Juniors] ON 

INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (1, N'Grigor Dimitrov', N'Junior', 1500, N'Plovdiv', N'grigo@soft.bg', N'0898469001', 1, 1)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (2, N'Veselin Minev', N'Junior', 1500, N'Sofia', N'vsminev@soft.bg', N'0898023344', 1, 1)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (3, N'Yordan Minev', N'Junior', 1500, N'Sofia', N'ydminev@soft.bg', N'0898101136', 2, 2)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (4, N'Violeta Dimitrova', N'Junior', 1500, N'Sofia', N'villy@soft.bg', N'0898799964', 2, 2)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (5, N'Adam Vokes', N'Junior', 1500, N'New York', N'adamv@soft.com', N'0555151210', 3, 3)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (6, N'Asen Georgiev', N'Junior', 1500, N'Varna', N'asgeorg@soft.bg', N'0899130023', 4, 4)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (7, N'Ivan Georgiev', N'Junior', 1000, N'Plovdiv', N'ivangeorgiev@soft.bg', N'0899151612', 5, 5)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (8, N'Milena Angelova', N'Junior', 1000, N'Plovdiv', N'milena@soft.bg', N'0899056331', 1, 1)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (9, N'Jake Kennedy', N'Junior', 1500, N'New York', N'jake@soft.com', N'0555151211', 1, 1)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (10, N'Milena Petrova', N'Junior', 1500, N'Sofia', N'mangelova@soft.bg', N'0899977899', 2, 2)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (11, N'Ivaylo Kalenderov', N'Junior', 1500, N'Sofia', N'kalenderov@soft.bg', N'0899997633', 3, 3)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (12, N'Jake Ledger', N'Junior', 1000, N'London', N'jkledger@soft.com', N'0420521338', 4, 4)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (13, N'Samuil Ivanov', N'Junior', 1000, N'Plovdiv', N'sam@soft.bg', N'0899013369', 6, 6)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (14, N'Todor Todorov', N'Junior', 1000, N'Sofia', N'todor@soft.bg', N'0899130021', 1, 1)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (15, N'Freddy Julious', N'Junior', 1000, N'London', N'freddy@soft.com', N'0420521339', 3, 3)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (16, N'Valeri Tsvetkov', N'Junior', 1500, N'Sofia', N'vtsvetkov@soft.bg', N'0899798861', 3, 3)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (17, N'Tsvetan Krastev', N'Junior', 1500, N'Vidin', N'krastev@soft.bg', N'0899346614', 4, 4)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (18, N'Kaloyan Kaloyanov', N'Junior', 1500, N'Varna', N'kaloynov@soft.bg', N'0899986311', 5, 5)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (19, N'Ivelina Ivanova', N'Junior', 1200, N'Sofia', N'ivelina@soft.bg', N'0899466449', 5, 5)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (20, N'Iveta Milusheva', N'Junior', 1200, N'Sofia', N'milusheva@soft.bg', N'0899010300', 7, 7)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (21, N'Kostadin Kostadinov', N'Junior', 1200, N'Sofia', N'kosta@soft.bg', N'0899023113', 2, 2)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (22, N'Svilen Naidenov', N'Junior', 1200, N'Sofia', N'naidenovsv@soft.bg', N'0899964344', 2, 2)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (23, N'Valentin Sashkov', N'Junior', 1200, N'Burgas', N'vsashkov@soft.bg', N'0897446622', 9, NULL)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (24, N'Nikolai Parvanov', N'Junior', 1200, N'Plovdiv', N'parvanov@soft.bg', N'0897344662', 8, 8)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (25, N'Petar Petrov', N'Junior', 1200, N'Sofia', N'ppetrov@soft.bg', N'0897010101', 8, 8)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (26, N'Simeon Simeonov', N'Junior', 1300, N'Varna', N'ssimeonov@soft.bg', N'0897997766', 1, 1)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (27, N'Hristo Hristov', N'Junior', 1300, N'Sofia', N'hhristov@soft.bg', N'0897164589', 2, 2)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (28, N'Yordan Milanov', N'Junior', 1300, N'Plovdiv', N'ymilanov@soft.bg', N'0897031456', 9, NULL)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (29, N'Trifon Popov', N'Junior', 1300, N'Sofia', N'trifon@soft.bg', N'0897967322', 6, 6)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (30, N'Teodor Stoyanov', N'Junior', 1000, N'Sofia', N'stoyanov@soft.bg', N'0897101033', 7, 7)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (31, N'Valeria Angelova', N'Junior', 1000, N'Sofia', N'valang@soft.bg', N'0897974466', 4, 4)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (32, N'Victoria Portman', N'Junior', 1000, N'New York', N'vportman@soft.com', N'0555151213', 5, 5)
INSERT [dbo].[Juniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (33, N'Ivan Grigoriev', N'Junior', 1000, N'Sofia', N'grigoriev@soft.bg', N'0897668991', 9, NULL)
SET IDENTITY_INSERT [dbo].[Juniors] OFF
SET IDENTITY_INSERT [dbo].[ProjectManagers] ON 

INSERT [dbo].[ProjectManagers] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ManagerId]) VALUES (1, N'Linus Torvalds', N'Project Manager', 50000, N'Helsinki', N'torvlads@linux.com', N'0650333221', 1)
INSERT [dbo].[ProjectManagers] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ManagerId]) VALUES (2, N'Richard Stallman', N'Project Manager', 35000, N'New York', N'stallman@microsoft.com', N'0555668954', 2)
INSERT [dbo].[ProjectManagers] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ManagerId]) VALUES (3, N'Martin Fowler', N'Project Manager', 25000, N'London', N'martin@martinfowler.com', N'0420899955', 2)
INSERT [dbo].[ProjectManagers] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ManagerId]) VALUES (4, N'Steve Wozniak', N'Project Manager', 35000, N'San Jose', N'woz@apple.com', N'0555122112', 1)
SET IDENTITY_INSERT [dbo].[ProjectManagers] OFF
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([Id], [ProjectName], [ManagerId]) VALUES (1, N'Windows OS', 2)
INSERT [dbo].[Projects] ([Id], [ProjectName], [ManagerId]) VALUES (2, N'iOS Development', 4)
INSERT [dbo].[Projects] ([Id], [ProjectName], [ManagerId]) VALUES (3, N'Facebook Technologies', 2)
INSERT [dbo].[Projects] ([Id], [ProjectName], [ManagerId]) VALUES (4, N'Git Technologies', 1)
INSERT [dbo].[Projects] ([Id], [ProjectName], [ManagerId]) VALUES (5, N'Visual Studio', 2)
INSERT [dbo].[Projects] ([Id], [ProjectName], [ManagerId]) VALUES (6, N'Cyberdyne Systems', 4)
INSERT [dbo].[Projects] ([Id], [ProjectName], [ManagerId]) VALUES (7, N'Skyfall', 1)
INSERT [dbo].[Projects] ([Id], [ProjectName], [ManagerId]) VALUES (8, N'Spectre 007', 3)
INSERT [dbo].[Projects] ([Id], [ProjectName], [ManagerId]) VALUES (9, N'without project', NULL)
SET IDENTITY_INSERT [dbo].[Projects] OFF
SET IDENTITY_INSERT [dbo].[Seniors] ON 

INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (1, N'Emil Angelov', N'Senior', 5000, N'Sofia', N'emoangelov@soft.bg', N'0897163331', 1, 1)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (2, N'Emanuela Ivanova', N'Senior', 5000, N'Varna', N'emanuela@soft.bg', N'0897789963', 2, 2)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (3, N'George Martin', N'Senior', 5000, N'New York', N'gmartin@soft.com', N'0897100036', 1, 1)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (4, N'Orlin Pavlov', N'Senior', 4500, N'Sofia', N'orlinpavlov@soft.bg', N'0897966644', 3, 3)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (5, N'Evelin Lesev', N'Senior', 4500, N'Sofia', N'evlesev@soft.bg', N'0896449330', 4, 4)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (6, N'Martin Lesev', N'Senior', 4000, N'Sofia', N'marto@soft.bg', N'0896101311', 2, 2)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (7, N'Fred Flint', N'Senior', 4500, N'London', N'flint@soft.com', N'0420521333', 5, 5)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (8, N'Pavel Pavlinov', N'Senior', 4000, N'Varna', N'pavlinov@soft.bg', N'0896977763', 3, 3)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (9, N'Andrei Arnaudov', N'Senior', 4000, N'Plovdiv', N'arnaudov@soft.bg', N'0896311005', 6, 6)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (10, N'Hristo Koilov', N'Senior', 5000, N'Plovdiv', N'hr.koilov@soft.bg', N'0896796313', 1, 1)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (11, N'Kosta Tsonev', N'Senior', 3500, N'Plovdiv', N'kostatsonev@soft.bg', N'0896100100', 2, 2)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (12, N'Sasho Tsvetkov', N'Senior', 3500, N'Sofia', N'sasho@soft.bg', N'0896979797', 7, 7)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (13, N'Vladislav Cvetanov', N'Senior', 4500, N'Sofia', N'cvetanov@soft.bg', N'0896463311', 1, 1)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (14, N'Benjamin Button', N'Senior', 5000, N'New York', N'button@soft.com', N'0896986986', 1, 1)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (15, N'Bradley Madley', N'Senior', 5000, N'New York', N'madley@soft.com', N'0896346622', 8, 8)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (16, N'Ivaylo Petkov', N'Senior', 4500, N'Sofia', N'ivaylopetkov@soft.bg', N'0896943012', 2, 2)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (17, N'Petko Petkov', N'Senior', 4000, N'Varna', N'ppetkov@soft.bg', N'0896171917', 2, 2)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (18, N'Trevor Sinclair', N'Senior', 5000, N'London', N'trevor@soft.com', N'0420521335', 4, 4)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (19, N'Nikolai Nikolov', N'Senior', 3500, N'Burgas', N'nnikolov@soft.bg', N'0895335353', 5, 5)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (20, N'Nikolai Varbanov', N'Senior', 4000, N'Sofia', N'nvarbanov@soft.bg', N'0895535311', 6, 6)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (21, N'Varban Varbanov', N'Senior', 4000, N'Sofia', N'vvarbanov@soft.bg', N'0895305566', 6, 6)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (22, N'Dimitar Stoyanov', N'Senior', 4500, N'Plovdiv', N'dimsto@soft.bg', N'0895978899', 3, 3)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (23, N'Violeta Kostadinova', N'Senior', 3500, N'Burgas', N'violeta@soft.bg', N'0895643331', 4, 4)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (24, N'Boris Angelov', N'Senior', 3500, N'Varna', N'borisangelov@soft.bg', N'0895798979', 5, 5)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (25, N'Chris Martin', N'Senior', 5000, N'New York', N'chamartin@soft.com', N'0895103020', 7, 7)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (26, N'Yanko Yankov', N'Senior', 3500, N'Sofia', N'yankov@soft.bg', N'0895649655', 8, 8)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (27, N'Milen Marianov', N'Senior', 3500, N'Plovdiv', N'mmarianov@soft.bg', N'0895106499', 3, 3)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (28, N'Lachezar Hristov', N'Senior', 3500, N'Sofia', N'lhristov@soft.bg', N'0895769483', 7, 7)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (29, N'Ivan Borisov', N'Senior', 3500, N'Varna', N'iborisov@soft.bg', N'0895349652', 9, NULL)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (30, N'Ivan Dimitrov', N'Senior', 3500, N'Plovdiv', N'dimitrovv@soft.bg', N'0895441244', 4, 4)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (31, N'Nikoleta Lozanova', N'Senior', 3500, N'Sofia', N'lozanova@soft.bg', N'0895397566', 5, 5)
INSERT [dbo].[Seniors] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (32, N'Ognian Georgiev', N'Senior', 3500, N'Plovdiv', N'ogi@soft.bg', N'0895119664', 8, 8)
SET IDENTITY_INSERT [dbo].[Seniors] OFF
SET IDENTITY_INSERT [dbo].[TeamLeaders] ON 

INSERT [dbo].[TeamLeaders] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (1, N'Georgi Ivanov', N'Team Leader', 8000, N'Sofia', N'ivanov@soft.bg', N'0898152265', 1, 2)
INSERT [dbo].[TeamLeaders] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (2, N'Milen Tsvetkov', N'Team Leader', 8000, N'Sofia', N'm.tsvetkov@soft.bg', N'0898556899', 2, 4)
INSERT [dbo].[TeamLeaders] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (3, N'Rumen Tomov', N'Team Leader', 6500, N'Plovdiv', N'tomov@soft.bg', N'0898556832', 3, 2)
INSERT [dbo].[TeamLeaders] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (4, N'Kalin Malinov', N'Team Leader', 8000, N'Sofia', N'malinov@soft.bg', N'0898152266', 4, 1)
INSERT [dbo].[TeamLeaders] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (5, N'Richard Finch', N'Team Leader', 15000, N'New York', N'richardfinch@microsoft.com', N'0555443544', 5, 2)
INSERT [dbo].[TeamLeaders] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (6, N'John Terry', N'Team Leader', 10000, N'London', N'terry@chelsea.com', N'0420150150', 6, 4)
INSERT [dbo].[TeamLeaders] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (7, N'Bryan Dean', N'Team Leader', 12000, N'New York', N'mrdean@microsoft.com', N'0555443545', 7, 1)
INSERT [dbo].[TeamLeaders] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (8, N'Nikolay Mitov', N'Team Leader', 7000, N'Sofia', N'nikimitov@soft.bg', N'0898152268', 8, 3)
SET IDENTITY_INSERT [dbo].[TeamLeaders] OFF
SET IDENTITY_INSERT [dbo].[Trainees] ON 

INSERT [dbo].[Trainees] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (1, N'Ivaylo Tsvetkov', N'Trainee', 1000, N'Vidin', N'ivaylo@abv.bg', N'0898918575', 6, 6)
INSERT [dbo].[Trainees] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (2, N'Pavel Penkov', N'Trainee', 1000, N'Pleven', N'pavel@abv.bg', N'0898556692', 7, 7)
INSERT [dbo].[Trainees] ([Id], [Name], [Position], [Salary], [City], [Email], [Phone], [ProjectId], [ManagerId]) VALUES (3, N'Vladimir Lukanov', N'Trainee', 1000, N'Sofia', N'vlado@abv.bg', N'0898141918', 8, 8)
SET IDENTITY_INSERT [dbo].[Trainees] OFF
ALTER TABLE [dbo].[DeliveryDirectors]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryDirectors_CEOs] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[CEOs] ([Id])
GO
ALTER TABLE [dbo].[DeliveryDirectors] CHECK CONSTRAINT [FK_DeliveryDirectors_CEOs]
GO
ALTER TABLE [dbo].[Intermediates]  WITH CHECK ADD  CONSTRAINT [FK_Intermediates_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[Intermediates] CHECK CONSTRAINT [FK_Intermediates_Projects]
GO
ALTER TABLE [dbo].[Intermediates]  WITH CHECK ADD  CONSTRAINT [FK_Intermediates_TeamLeaders] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[TeamLeaders] ([Id])
GO
ALTER TABLE [dbo].[Intermediates] CHECK CONSTRAINT [FK_Intermediates_TeamLeaders]
GO
ALTER TABLE [dbo].[Juniors]  WITH CHECK ADD  CONSTRAINT [FK_Juniors_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[Juniors] CHECK CONSTRAINT [FK_Juniors_Projects]
GO
ALTER TABLE [dbo].[Juniors]  WITH CHECK ADD  CONSTRAINT [FK_Juniors_TeamLeaders] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[TeamLeaders] ([Id])
GO
ALTER TABLE [dbo].[Juniors] CHECK CONSTRAINT [FK_Juniors_TeamLeaders]
GO
ALTER TABLE [dbo].[ProjectManagers]  WITH CHECK ADD  CONSTRAINT [FK_ProjectManagers_DeliveryDirectors] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[DeliveryDirectors] ([Id])
GO
ALTER TABLE [dbo].[ProjectManagers] CHECK CONSTRAINT [FK_ProjectManagers_DeliveryDirectors]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ProjectManagers] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[ProjectManagers] ([Id])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ProjectManagers]
GO
ALTER TABLE [dbo].[Seniors]  WITH CHECK ADD  CONSTRAINT [FK_Seniors_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[Seniors] CHECK CONSTRAINT [FK_Seniors_Projects]
GO
ALTER TABLE [dbo].[Seniors]  WITH CHECK ADD  CONSTRAINT [FK_Seniors_TeamLeaders] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[TeamLeaders] ([Id])
GO
ALTER TABLE [dbo].[Seniors] CHECK CONSTRAINT [FK_Seniors_TeamLeaders]
GO
ALTER TABLE [dbo].[TeamLeaders]  WITH CHECK ADD  CONSTRAINT [FK_TeamLeaders_ProjectManagers] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[ProjectManagers] ([Id])
GO
ALTER TABLE [dbo].[TeamLeaders] CHECK CONSTRAINT [FK_TeamLeaders_ProjectManagers]
GO
ALTER TABLE [dbo].[TeamLeaders]  WITH CHECK ADD  CONSTRAINT [FK_TeamLeaders_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[TeamLeaders] CHECK CONSTRAINT [FK_TeamLeaders_Projects]
GO
ALTER TABLE [dbo].[Trainees]  WITH CHECK ADD  CONSTRAINT [FK_Trainees_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[Trainees] CHECK CONSTRAINT [FK_Trainees_Projects]
GO
ALTER TABLE [dbo].[Trainees]  WITH CHECK ADD  CONSTRAINT [FK_Trainees_TeamLeaders] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[TeamLeaders] ([Id])
GO
ALTER TABLE [dbo].[Trainees] CHECK CONSTRAINT [FK_Trainees_TeamLeaders]
GO
USE [master]
GO
ALTER DATABASE [EmployeesDb] SET  READ_WRITE 
GO
