CREATE TABLE [dbo].[BuyingCarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DataClient] nvarchar(max)  NOT NULL,
    [Cost] int  NOT NULL,
    [DatePurchase] datetime  NOT NULL,
    [SellingAutoId] int  NOT NULL
);
GO
ALTER TABLE [dbo].[BuyingCarSet]
ADD CONSTRAINT [PK_BuyingCarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO
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