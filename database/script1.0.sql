USE [master]
GO
/****** Object:  Database [FStudent]    Script Date: 9/14/2017 9:01:06 PM ******/
CREATE DATABASE [FStudent]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FStudent', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FStudent.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FStudent_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FStudent_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FStudent] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FStudent].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FStudent] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FStudent] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FStudent] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FStudent] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FStudent] SET ARITHABORT OFF 
GO
ALTER DATABASE [FStudent] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FStudent] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [FStudent] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FStudent] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FStudent] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FStudent] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FStudent] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FStudent] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FStudent] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FStudent] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FStudent] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FStudent] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FStudent] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FStudent] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FStudent] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FStudent] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FStudent] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FStudent] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FStudent] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FStudent] SET  MULTI_USER 
GO
ALTER DATABASE [FStudent] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FStudent] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FStudent] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FStudent] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [FStudent]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 9/14/2017 9:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseCode] [nvarchar](50) NOT NULL,
	[CourseName] [nvarchar](50) NULL,
	[Credit] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professor]    Script Date: 9/14/2017 9:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor](
	[ProfessorCode] [nvarchar](50) NOT NULL,
	[Department] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_Professor] PRIMARY KEY CLUSTERED 
(
	[ProfessorCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Section]    Script Date: 9/14/2017 9:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Section](
	[SectionNo] [nvarchar](50) NOT NULL,
	[SeatingCapacity] [nvarchar](50) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[ProfessorCode] [nvarchar](50) NULL,
	[RepresentedCourse] [nvarchar](50) NULL,
	[SemesterBelong] [nvarchar](50) NULL,
 CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED 
(
	[SectionNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 9/14/2017 9:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentCode] [nvarchar](50) NOT NULL,
	[Major] [nchar](10) NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[TranscriptID] [nchar](10) NULL,
	[TotalCredit] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentTransript]    Script Date: 9/14/2017 9:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTransript](
	[TranscriptID] [int] NOT NULL,
	[StudentCode] [nvarchar](50) NOT NULL,
	[SectionID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StudentTransript] PRIMARY KEY CLUSTERED 
(
	[TranscriptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TranscriptAttendanceEntry]    Script Date: 9/14/2017 9:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TranscriptAttendanceEntry](
	[EntryID] [int] NOT NULL,
	[TranscriptID] [int] NULL,
	[AttendanceStatus] [int] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_TranscriptAttendanceEntry] PRIMARY KEY CLUSTERED 
(
	[EntryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TranscriptMarkEntry]    Script Date: 9/14/2017 9:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TranscriptMarkEntry](
	[EntryID] [int] NOT NULL,
	[TranscriptID] [int] NULL,
	[MarkTitle] [nvarchar](50) NULL,
	[Percentage] [float] NULL,
	[Grade] [float] NULL,
 CONSTRAINT [PK_TranscriptMarkEntry] PRIMARY KEY CLUSTERED 
(
	[EntryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Section]  WITH CHECK ADD  CONSTRAINT [FK_Section_Course] FOREIGN KEY([RepresentedCourse])
REFERENCES [dbo].[Course] ([CourseCode])
GO
ALTER TABLE [dbo].[Section] CHECK CONSTRAINT [FK_Section_Course]
GO
ALTER TABLE [dbo].[Section]  WITH CHECK ADD  CONSTRAINT [FK_Section_Professor] FOREIGN KEY([ProfessorCode])
REFERENCES [dbo].[Professor] ([ProfessorCode])
GO
ALTER TABLE [dbo].[Section] CHECK CONSTRAINT [FK_Section_Professor]
GO
ALTER TABLE [dbo].[StudentTransript]  WITH CHECK ADD  CONSTRAINT [FK_StudentTransript_Section] FOREIGN KEY([SectionID])
REFERENCES [dbo].[Section] ([SectionNo])
GO
ALTER TABLE [dbo].[StudentTransript] CHECK CONSTRAINT [FK_StudentTransript_Section]
GO
ALTER TABLE [dbo].[StudentTransript]  WITH CHECK ADD  CONSTRAINT [FK_StudentTransript_Student] FOREIGN KEY([StudentCode])
REFERENCES [dbo].[Student] ([StudentCode])
GO
ALTER TABLE [dbo].[StudentTransript] CHECK CONSTRAINT [FK_StudentTransript_Student]
GO
ALTER TABLE [dbo].[TranscriptAttendanceEntry]  WITH CHECK ADD  CONSTRAINT [FK_TranscriptAttendanceEntry_StudentTransript] FOREIGN KEY([TranscriptID])
REFERENCES [dbo].[StudentTransript] ([TranscriptID])
GO
ALTER TABLE [dbo].[TranscriptAttendanceEntry] CHECK CONSTRAINT [FK_TranscriptAttendanceEntry_StudentTransript]
GO
ALTER TABLE [dbo].[TranscriptMarkEntry]  WITH CHECK ADD  CONSTRAINT [FK_TranscriptMarkEntry_StudentTransript] FOREIGN KEY([TranscriptID])
REFERENCES [dbo].[StudentTransript] ([TranscriptID])
GO
ALTER TABLE [dbo].[TranscriptMarkEntry] CHECK CONSTRAINT [FK_TranscriptMarkEntry_StudentTransript]
GO
USE [master]
GO
ALTER DATABASE [FStudent] SET  READ_WRITE 
GO
