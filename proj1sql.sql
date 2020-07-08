-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [dbo].[Customers]

CREATE TABLE [dbo].[Customers]
(
 [Id]        int IDENTITY (1, 1) NOT NULL ,
 [FirstName] nvarchar(50) NOT NULL ,
 [LastName]  nvarchar(50) NOT NULL ,
 [Username] nvarchar(50) NULL,


 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [dbo].[Orders]

CREATE TABLE [dbo].[Orders]
(
 [Id]        int IDENTITY (1, 1) NOT NULL ,
 [OrderTime] datetime2(7) NOT NULL ,
 [Total]     money NOT NULL ,


 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [dbo].[Products]

CREATE TABLE [dbo].[Products]
(
 [Id]          int IDENTITY (1, 1) NOT NULL ,
 [ProductName] nvarchar(50) NOT NULL ,
 [Type]        nvarchar(50) NOT NULL ,
 [Price]       money NOT NULL ,


 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [dbo].[Stores]

CREATE TABLE [dbo].[Stores]
(
 [Id]        int IDENTITY (1, 1) NOT NULL ,
 [StoreName] nvarchar(50) NOT NULL ,


 CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO


-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [dbo].[Inventory]

CREATE TABLE [dbo].[Inventory]
(
 [Id]        int IDENTITY (1, 1) NOT NULL ,
 [Quantity]  int NOT NULL ,
 [ProductId] int NOT NULL ,
 [StoreId]   int NOT NULL ,


 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_Inventory_Products_ProductId] FOREIGN KEY ([ProductId])  REFERENCES [dbo].[Products]([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
 CONSTRAINT [FK_Inventory_Stores_StoreId] FOREIGN KEY ([StoreId])  REFERENCES [dbo].[Stores]([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO
-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [dbo].[Order Details]

CREATE TABLE [dbo].[Order Details]
(
 [OrderId]        int NOT NULL ,
 [ProductId]      int NOT NULL ,
 [ProductQuantiy] int NOT NULL ,
 [InventoryId]    int NOT NULL ,
 [CustomerId]     int NOT NULL ,


 CONSTRAINT [PK_Orders_Products] PRIMARY KEY CLUSTERED ([OrderId] ASC, [ProductId] ASC),
 CONSTRAINT [Customers_OrderDetails_CustomerId] FOREIGN KEY ([CustomerId])  REFERENCES [dbo].[Customers]([Id]),
 CONSTRAINT [FK_Order_Products_Orders_OrderID] FOREIGN KEY ([OrderId])  REFERENCES [dbo].[Orders]([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
 CONSTRAINT [FK_Order_Products_Products_ProductId] FOREIGN KEY ([ProductId])  REFERENCES [dbo].[Products]([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
 CONSTRAINT [Inventory_OrderDetails_InventoryId] FOREIGN KEY ([InventoryId])  REFERENCES [dbo].[Inventory]([Id]) 
);















































