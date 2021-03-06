USE [EasyCombos]
GO
/****** Object:  Table [dbo].[FoodCategories]    Script Date: 09/29/2013 17:20:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategories](
	[FoodCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_FoodCategory] PRIMARY KEY CLUSTERED 
(
	[FoodCategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 09/29/2013 17:20:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](100) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[AdditionalDiscount] [float] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfferTypes]    Script Date: 09/29/2013 17:20:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfferTypes](
	[OfferTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OfferType] PRIMARY KEY CLUSTERED 
(
	[OfferTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodItems]    Script Date: 09/29/2013 17:20:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodItems](
	[FoodItemId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FoodCategoryId] [int] NOT NULL,
	[PricePerUnit] [float] NOT NULL,
	[QunatityOnHand] [int] NOT NULL,
	[Description] [nvarchar](250) NULL,
	[OfferedDiscount] [float] NOT NULL,
	[OfferTypeId] [int] NOT NULL,
 CONSTRAINT [PK_FoodItem] PRIMARY KEY CLUSTERED 
(
	[FoodItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_FoodItem]    Script Date: 09/29/2013 17:20:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_FoodItem](
	[OrderId] [int] NOT NULL,
	[FoodItemId] [int] NOT NULL,
 CONSTRAINT [PK_Order_FoodItem] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[FoodItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_FoodItem_OfferedDiscount]    Script Date: 09/29/2013 17:20:18 ******/
ALTER TABLE [dbo].[FoodItems] ADD  CONSTRAINT [DF_FoodItem_OfferedDiscount]  DEFAULT ((0)) FOR [OfferedDiscount]
GO
/****** Object:  Default [DF_FoodItem_OfferTypeId]    Script Date: 09/29/2013 17:20:18 ******/
ALTER TABLE [dbo].[FoodItems] ADD  CONSTRAINT [DF_FoodItem_OfferTypeId]  DEFAULT ((0)) FOR [OfferTypeId]
GO
/****** Object:  Default [DF_Table_1_Discount]    Script Date: 09/29/2013 17:20:18 ******/
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Table_1_Discount]  DEFAULT ((0)) FOR [AdditionalDiscount]
GO
/****** Object:  ForeignKey [FK_FoodItem_FoodCategories]    Script Date: 09/29/2013 17:20:18 ******/
ALTER TABLE [dbo].[FoodItems]  WITH CHECK ADD  CONSTRAINT [FK_FoodItem_FoodCategories] FOREIGN KEY([FoodCategoryId])
REFERENCES [dbo].[FoodCategories] ([FoodCategoryId])
GO
ALTER TABLE [dbo].[FoodItems] CHECK CONSTRAINT [FK_FoodItem_FoodCategories]
GO
/****** Object:  ForeignKey [FK_FoodItem_OfferType]    Script Date: 09/29/2013 17:20:18 ******/
ALTER TABLE [dbo].[FoodItems]  WITH CHECK ADD  CONSTRAINT [FK_FoodItem_OfferType] FOREIGN KEY([OfferTypeId])
REFERENCES [dbo].[OfferTypes] ([OfferTypeId])
GO
ALTER TABLE [dbo].[FoodItems] CHECK CONSTRAINT [FK_FoodItem_OfferType]
GO
/****** Object:  ForeignKey [FK_Order_FoodItem_FoodItem]    Script Date: 09/29/2013 17:20:18 ******/
ALTER TABLE [dbo].[Order_FoodItem]  WITH CHECK ADD  CONSTRAINT [FK_Order_FoodItem_FoodItem] FOREIGN KEY([FoodItemId])
REFERENCES [dbo].[FoodItems] ([FoodItemId])
GO
ALTER TABLE [dbo].[Order_FoodItem] CHECK CONSTRAINT [FK_Order_FoodItem_FoodItem]
GO
/****** Object:  ForeignKey [FK_Order_FoodItem_Order]    Script Date: 09/29/2013 17:20:18 ******/
ALTER TABLE [dbo].[Order_FoodItem]  WITH CHECK ADD  CONSTRAINT [FK_Order_FoodItem_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[Order_FoodItem] CHECK CONSTRAINT [FK_Order_FoodItem_Order]
GO
