USE [master]
GO
/****** Object:  Database [BancaBasicaDB]    Script Date: 3/12/2021 9:15:58 ******/
CREATE DATABASE [BancaBasicaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BancaBasicaDB', FILENAME = N'C:\Users\jorge\BancaBasicaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BancaBasicaDB_log', FILENAME = N'C:\Users\jorge\BancaBasicaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BancaBasicaDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BancaBasicaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BancaBasicaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BancaBasicaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BancaBasicaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BancaBasicaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BancaBasicaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BancaBasicaDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BancaBasicaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BancaBasicaDB] SET  MULTI_USER 
GO
ALTER DATABASE [BancaBasicaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BancaBasicaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BancaBasicaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BancaBasicaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BancaBasicaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BancaBasicaDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BancaBasicaDB] SET QUERY_STORE = OFF
GO
USE [BancaBasicaDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/12/2021 9:15:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 3/12/2021 9:15:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuenta]    Script Date: 3/12/2021 9:15:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuenta](
	[Id_Cuenta] [int] IDENTITY(1,1) NOT NULL,
	[Saldo] [float] NOT NULL,
	[Id_Cliente] [int] NOT NULL,
 CONSTRAINT [PK_cuenta] PRIMARY KEY CLUSTERED 
(
	[Id_Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[movimiento]    Script Date: 3/12/2021 9:15:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movimiento](
	[Id_Movimiento] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [float] NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Id_Cuenta] [int] NOT NULL,
	[Tipo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_movimiento] PRIMARY KEY CLUSTERED 
(
	[Id_Movimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[cuenta] ADD  DEFAULT ((0)) FOR [Id_Cliente]
GO
ALTER TABLE [dbo].[movimiento] ADD  DEFAULT ((0)) FOR [Id_Cuenta]
GO
ALTER TABLE [dbo].[movimiento] ADD  DEFAULT (N'') FOR [Tipo]
GO
ALTER TABLE [dbo].[cuenta]  WITH CHECK ADD  CONSTRAINT [FK_cuenta_cliente] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[cliente] ([Id])
GO
ALTER TABLE [dbo].[cuenta] CHECK CONSTRAINT [FK_cuenta_cliente]
GO
ALTER TABLE [dbo].[movimiento]  WITH CHECK ADD  CONSTRAINT [FK_movimiento_cuenta] FOREIGN KEY([Id_Cuenta])
REFERENCES [dbo].[cuenta] ([Id_Cuenta])
GO
ALTER TABLE [dbo].[movimiento] CHECK CONSTRAINT [FK_movimiento_cuenta]
GO
USE [master]
GO
ALTER DATABASE [BancaBasicaDB] SET  READ_WRITE 
GO


USE [BancaBasicaDB]
GO
/****** Object:  Trigger [dbo].[tg_movimiengto]    Script Date: 3/12/2021 9:36:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  TRIGGER [dbo].[tg_movimiengto]
ON [dbo].[movimiento]
AFTER  INSERT,UPDATE
AS
BEGIN 
SET NOCOUNT ON;
	BEGIN TRANSACTION
	declare @tipo	char(1);
	declare @valor  float;
	declare @cuenta varchar(20);
	declare @saldoActual float;

	select @tipo = Tipo, @valor = Valor, @cuenta = Id_Cuenta from inserted;
	select @valor = case when @tipo = '+' then @valor else @valor * -1 end;

	select @saldoActual = Saldo from cuenta where Id_Cuenta = @cuenta;

	IF @tipo = '-'
	BEGIN
		select @saldoActual = @saldoActual + @valor;
		if @saldoActual < 0
		BEGIN
			ROLLBACK TRAN;
			return;
		END

	END

	update cuenta set saldo = saldo + @valor where Id_Cuenta = @cuenta;
	COMMIT TRANSACTION;
	return;
END