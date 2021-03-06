/*UNCOMMENT in need*/

/*
USE [master]
GO
/****** Object:  Database [TrackingSystem]    Script Date: 2017-03-30 12:28:56 ******/
CREATE DATABASE [TrackingSystem]
 CONTAINMENT = NONE
GO
ALTER DATABASE [TrackingSystem] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrackingSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrackingSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TrackingSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TrackingSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TrackingSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TrackingSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [TrackingSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TrackingSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TrackingSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TrackingSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TrackingSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TrackingSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TrackingSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TrackingSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TrackingSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TrackingSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TrackingSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TrackingSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TrackingSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TrackingSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TrackingSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TrackingSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TrackingSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TrackingSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TrackingSystem] SET  MULTI_USER 
GO
ALTER DATABASE [TrackingSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TrackingSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TrackingSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TrackingSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TrackingSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TrackingSystem] SET QUERY_STORE = OFF
GO
USE [TrackingSystem]
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
USE [TrackingSystem]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 2017-03-30 12:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[AttendanceId] [int] IDENTITY(1,1) NOT NULL,
	[CardId] [int] NOT NULL,
	[CheckIn] [datetime2](7) NOT NULL,
	[CheckOut] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VisitorCard]    Script Date: 2017-03-30 12:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitorCard](
	[CardId] [int] IDENTITY(1,1) NOT NULL,
	[Active] [bit] NOT NULL,
	[VisitorName] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_VisitorCard] FOREIGN KEY([CardId])
REFERENCES [dbo].[VisitorCard] ([CardId])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_VisitorCard]
GO
USE [master]
GO
ALTER DATABASE [TrackingSystem] SET  READ_WRITE 
GO
*/