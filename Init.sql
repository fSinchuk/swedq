IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'CarSignalDb') BEGIN CREATE DATABASE [DBNAME] END
GO

USE [CarSignal]
GO


if not exists (select * from sysobjects where name='Customers' and xtype='U')
BEGIN
	CREATE TABLE [dbo].[Customers](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](max) NOT NULL,
		[Address] [nvarchar](max) NOT NULL,
	CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

if not exists (select * from sysobjects where name='[Car_Statuses]' and xtype='U')
BEGIN
	CREATE TABLE [dbo].[Car_Statuses](
		[Id] [smallint] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](max) NOT NULL,
	CONSTRAINT [PK_Car_Statuses] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

if not exists (select * from sysobjects where name='[Customer_Cars]' and xtype='U')
	BEGIN
	CREATE TABLE [dbo].[Customer_Cars](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[LastPing] [datetime2](7) NULL,
		[CustomerId] [int] NOT NULL,
		[StatusId] [smallint] NOT NULL DEFAULT (CONVERT([smallint],(0))),
		[RegNr] [nvarchar](6) NOT NULL DEFAULT (N''),
		[Vin] [nvarchar](17) NOT NULL DEFAULT (N''),
	CONSTRAINT [PK_Customer_Cars] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	END
GO

ALTER TABLE [dbo].[Customer_Cars]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Cars_Car_Statuses_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Car_Statuses] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Customer_Cars] CHECK CONSTRAINT [FK_Customer_Cars_Car_Statuses_StatusId]
GO

ALTER TABLE [dbo].[Customer_Cars]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Cars_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Customer_Cars] CHECK CONSTRAINT [FK_Customer_Cars_Customers_CustomerId]
GO







