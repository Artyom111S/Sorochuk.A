
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/10/2018 11:37:51
-- Generated from EDMX file: C:\Users\Admin\Desktop\Sorochuk.A-ASP.NetWebAPI1\Sorochuk.A-ASP.NetWebAPI1\ASP.Net WebAPI\ASP.Net WebAPI\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\ADMIN\DESKTOP\SOROCHUK.A-ASP.NETWEBAPI1\SOROCHUK.A-ASP.NETWEBAPI1\ASP.NET WEBAPI\ASP.NET WEBAPI\APP_DATA\DATABASE1.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SellingAutoBuyingCar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BuyingCarSet] DROP CONSTRAINT [FK_SellingAutoBuyingCar];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Selling_auto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Selling_auto];
GO
IF OBJECT_ID(N'[dbo].[BuyingCarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BuyingCarSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Selling_auto'
CREATE TABLE [dbo].[Selling_auto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [InStock] bit  NULL,
    [AutoDescription] nchar(10)  NULL,
    [Cost] int  NULL,
    [DateReceipts] datetime  NULL
);
GO

-- Creating table 'BuyingCarSet'
CREATE TABLE [dbo].[BuyingCarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DataClient] nvarchar(max)  NOT NULL,
    [Cost] int  NOT NULL,
    [DatePurchase] datetime  NOT NULL,
    [SellingAutoId] int  NOT NULL
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

-- Creating primary key on [Id] in table 'BuyingCarSet'
ALTER TABLE [dbo].[BuyingCarSet]
ADD CONSTRAINT [PK_BuyingCarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SellingAutoId] in table 'BuyingCarSet'
ALTER TABLE [dbo].[BuyingCarSet]
ADD CONSTRAINT [FK_SellingAutoBuyingCar]
    FOREIGN KEY ([SellingAutoId])
    REFERENCES [dbo].[Selling_auto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SellingAutoBuyingCar'
CREATE INDEX [IX_FK_SellingAutoBuyingCar]
ON [dbo].[BuyingCarSet]
    ([SellingAutoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------