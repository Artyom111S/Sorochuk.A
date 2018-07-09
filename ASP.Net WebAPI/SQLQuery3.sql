
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/09/2018 13:28:16
-- Generated from EDMX file: C:\Users\Admin\Desktop\Sorochuk.A-ASP.NetWebAPI1\Sorochuk.A-ASP.NetWebAPI1\ASP.Net WebAPI\ASP.Net WebAPI\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\Users\Admin\Desktop\Sorochuk.A-ASP.NetWebAPI1\Sorochuk.A-ASP.NetWebAPI1\ASP.Net WebAPI\ASP.Net WebAPI\App_Data\Database1.mdf];
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

-- Creating table 'BuyingCarSet'
CREATE TABLE [dbo].[BuyingCarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DataClient] nvarchar(max)  NOT NULL,
    [Cost] int NOT NULL,
    [DatePurchase] datetime NOT NULL,
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