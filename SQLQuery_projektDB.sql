
CREATE TABLE [dbo].[Product] (
    [Id]            INT             IDENTITY(1, 1) NOT NULL,
    [ArtistName]    VARCHAR(256)    NOT NULL,
    [AlbumName]     VARCHAR(256)    NOT NULL,
    [RecordLabel]   VARCHAR(128)    NOT NULL,
    [ReleaseDate]   INT             NOT NULL,       
    [Genre]         VARCHAR(50)     NOT NULL,
    [Format]        VARCHAR(50)     NOT NULL,
    [Price]         DECIMAL(18, 2)  NOT NULL,       
    [PurchasePrice] DECIMAL(18, 2)  NOT NULL,       
    [Used]          BIT             NOT NULL,       
    [Condition]     VARCHAR(128)    NOT NULL,       
    [StockBalance]  INT             DEFAULT 0,      
    [Description]   VARCHAR(512)    NOT NULL,       
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Campaign] (
    [Id]             INT             IDENTITY(1, 1) NOT NULL,   
    [Name]           VARCHAR(256)    NOT NULL,                 
    [Start]          DATETIME2(0)    NULL,                      
    [End]            DATETIME2(0)    NULL,                      
    [Description]    VARCHAR(512)    NULL,                     
    [CampaignStatus] BIT             NOT NULL,                  
    [DiscountId]     INT             NOT NULL,                 
    CONSTRAINT [PK_Campaign] PRIMARY KEY CLUSTERED ([Id] ASC)    
);

CREATE TABLE [dbo].[Discount] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Value]     DECIMAL (18, 2) NOT NULL,
    [Type]      VARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_Rabatt] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[ReturnOrder] (
    [Id]              INT             IDENTITY(1, 1) NOT NULL,  
    [OrderDetailsId]  INT             NOT NULL,                
    [Reason]          VARCHAR(512)    NOT NULL,                
    [Date]            DATETIME2(0)    NOT NULL,                
    [ReturnQuantity]  INT             NOT NULL,                
    CONSTRAINT [PK_Return] PRIMARY KEY CLUSTERED ([Id] ASC)     
);

CREATE TABLE [dbo].[OrderDetails] (
    [Id]          INT             IDENTITY(1, 1) NOT NULL,
    [ProductId]   INT             NOT NULL,            
    [DiscountId]  INT             NULL,               
    [OrderId]     INT             NOT NULL,            
    [Quantity]    INT             NOT NULL,            
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[OrderStatus] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (100) NULL,
    CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Order] (
    [Id]               INT             IDENTITY(1, 1) NOT NULL,
    [UserId]           INT             NOT NULL,            
    [Date]             DATETIME2(0)    NOT NULL,            
    [TotalAmount]      DECIMAL(18, 2)  NOT NULL,            
    [OrderStatusId]    INT             NULL,               
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[User] (
    [Id]                INT            IDENTITY(1, 1) NOT NULL,
    [FirstName]         VARCHAR(50)    NOT NULL,
    [LastName]          VARCHAR(50)    NOT NULL,
    [BirthDate]         DATE           NULL,           
    [Address]           VARCHAR(100)   NOT NULL,
    [ZipCode]           VARCHAR(20)    NOT NULL,
    [City]              VARCHAR(50)    NOT NULL, 
    [Country]           VARCHAR(50)    NOT NULL,
    [Email]             VARCHAR(128)   NOT NULL,
    [Username]          VARCHAR(50)    NOT NULL UNIQUE, 
    [PasswordSalt]      VARBINARY(64)  NOT NULL,
    [PasswordHash]      VARBINARY(32)  NOT NULL,
    [IsAdmin]           BIT            DEFAULT 0, 
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC) -- TODO IsAdmin
);

-- reserverade ord User annoying


