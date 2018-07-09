
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/09/2018 11:33:35
-- Generated from EDMX file: C:\Users\Admin\Desktop\Sorochuk.A-ASP.NetWebAPI1\Sorochuk.A-ASP.NetWebAPI1\ASP.Net WebAPI\ASP.Net WebAPI\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Selling_auto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Selling_auto];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Selling_auto'
CREATE TABLE [dbo].[Selling_auto] (
    [Id] int  NOT NULL,
    [InStock] bit  NULL,
    [AutoDescription] nchar(10)  NULL,
    [Cost] int  NULL,
    [DateReceipts] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Selling_auto'
ALTER TABLE [dbo].[Selling_auto]
ADD CONSTRAINT [PK_Selling_auto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------