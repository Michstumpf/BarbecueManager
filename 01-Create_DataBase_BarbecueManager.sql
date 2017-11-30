USE [master]
GO

/****** Object:  Database [BarbecueManager]    Script Date: 30/11/2017 11:53:01 ******/
CREATE DATABASE [BarbecueManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BarbecueManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BarbecueManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BarbecueManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BarbecueManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [BarbecueManager] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BarbecueManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BarbecueManager] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BarbecueManager] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BarbecueManager] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BarbecueManager] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BarbecueManager] SET ARITHABORT OFF 
GO

ALTER DATABASE [BarbecueManager] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BarbecueManager] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BarbecueManager] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BarbecueManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BarbecueManager] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BarbecueManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BarbecueManager] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BarbecueManager] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BarbecueManager] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BarbecueManager] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BarbecueManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BarbecueManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BarbecueManager] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BarbecueManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BarbecueManager] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BarbecueManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BarbecueManager] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BarbecueManager] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [BarbecueManager] SET  MULTI_USER 
GO

ALTER DATABASE [BarbecueManager] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BarbecueManager] SET DB_CHAINING OFF 
GO

ALTER DATABASE [BarbecueManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [BarbecueManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [BarbecueManager] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [BarbecueManager] SET QUERY_STORE = OFF
GO

USE [BarbecueManager]
GO

ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [BarbecueManager] SET  READ_WRITE 
GO


