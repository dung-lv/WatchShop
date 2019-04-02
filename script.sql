USE [WatchShop]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/2/2019 12:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[ID_Category] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL DEFAULT (NULL),
	[Metatitle] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 4/2/2019 12:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[ID_Login] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](100) NULL,
	[Password] [varchar](200) NULL,
	[ID_Role] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 4/2/2019 12:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ID_OrderDetail] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_Order] [bigint] NOT NULL,
	[Quantity] [int] NULL,
	[TotalPrice] [int] NULL,
	[ID_ProductDetail] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_OrderDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 4/2/2019 12:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[ID_Order] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Phone] [char](12) NULL,
	[Address] [nvarchar](500) NULL,
	[Status] [nvarchar](10) NULL,
	[Create_Date] [varchar](100) NULL,
	[Transport] [nvarchar](100) NULL,
	[Note] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/2/2019 12:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ID_Product] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL CONSTRAINT [DF__Product__Name__173876EA]  DEFAULT (NULL),
	[Price] [decimal](18, 0) NULL CONSTRAINT [DF__Product__Price__182C9B23]  DEFAULT ((0)),
	[Description] [ntext] NULL,
	[Avatar] [varchar](200) NULL,
	[Images] [xml] NULL,
	[Hot] [bit] NULL,
	[Metatitle] [varchar](100) NULL,
	[ID_Trademark] [bigint] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ID_Promotion] [bigint] NULL,
	[Discount] [decimal](18, 0) NULL,
 CONSTRAINT [PK__Product__522DE496F74B3569] PRIMARY KEY CLUSTERED 
(
	[ID_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductColor]    Script Date: 4/2/2019 12:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductColor](
	[ID_Color] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL DEFAULT (NULL),
PRIMARY KEY CLUSTERED 
(
	[ID_Color] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductDetail]    Script Date: 4/2/2019 12:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetail](
	[ID_ProductDetail] [bigint] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NULL,
	[ID_Product] [bigint] NULL,
	[ID_Color] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_ProductDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 4/2/2019 12:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[ID_Promotion] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL CONSTRAINT [DF__Promotion__Name__34C8D9D1]  DEFAULT (NULL),
	[StartTime] [datetime] NULL CONSTRAINT [DF__Promotion__Start__35BCFE0A]  DEFAULT (getdate()),
	[EndTime] [datetime] NULL CONSTRAINT [DF__Promotion__EndTi__36B12243]  DEFAULT (getdate()),
	[Description] [ntext] NULL,
 CONSTRAINT [PK__Promotio__ECECECBE60F6485A] PRIMARY KEY CLUSTERED 
(
	[ID_Promotion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/2/2019 12:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[ID_Role] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL DEFAULT (NULL),
PRIMARY KEY CLUSTERED 
(
	[ID_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Trademark]    Script Date: 4/2/2019 12:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Trademark](
	[ID_Trademark] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL DEFAULT (NULL),
	[Metatitle] [varchar](100) NULL,
	[ID_Category] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Trademark] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/2/2019 12:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[ID_User] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Address] [nvarchar](200) NULL,
	[Sex] [nchar](10) NULL,
	[Phone] [char](12) NULL,
	[email] [varchar](50) NULL,
	[ID_Login] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID_Category], [Name], [Metatitle]) VALUES (1, N'ĐỒNG HỒ CỔ ĐIỂN', N'codien')
INSERT [dbo].[Category] ([ID_Category], [Name], [Metatitle]) VALUES (2, N'ĐỒNG HỒ THÔNG MINH', N'hiendai')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Avatar], [Images], [Hot], [Metatitle], [ID_Trademark], [CreateDate], [ID_Promotion], [Discount]) VALUES (2, N'Orient FDD03001W0', CAST(4200000 AS Decimal(18, 0)), NULL, N'OrientFDD03001W0.jpg', NULL, 1, N'orient', 2, NULL, 1, CAST(10000 AS Decimal(18, 0)))
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Avatar], [Images], [Hot], [Metatitle], [ID_Trademark], [CreateDate], [ID_Promotion], [Discount]) VALUES (3, N'Seiko SNKN85J1', CAST(3150000 AS Decimal(18, 0)), NULL, N'SeikoSNKN85J1.jpg', NULL, 1, N'seiko', 3, NULL, 1, CAST(11000 AS Decimal(18, 0)))
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Avatar], [Images], [Hot], [Metatitle], [ID_Trademark], [CreateDate], [ID_Promotion], [Discount]) VALUES (4, N'OLYM PIANUS OP990-133AMS', CAST(4156000 AS Decimal(18, 0)), NULL, N'OLYMPIANUSOP990133AMS.jpg', NULL, 1, N'olym', 4, NULL, 1, CAST(12000 AS Decimal(18, 0)))
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Avatar], [Images], [Hot], [Metatitle], [ID_Trademark], [CreateDate], [ID_Promotion], [Discount]) VALUES (7, N'Daniel Wellington DW00100235', CAST(2700000 AS Decimal(18, 0)), NULL, N'DW00100235.jpg', NULL, 1, N'daniel', 5, NULL, 1, CAST(14000 AS Decimal(18, 0)))
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Avatar], [Images], [Hot], [Metatitle], [ID_Trademark], [CreateDate], [ID_Promotion], [Discount]) VALUES (9, N'Citizen NH8350-83A', CAST(2100000 AS Decimal(18, 0)), NULL, N'NH835083A.jpg', NULL, 1, N'citizen', 6, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Avatar], [Images], [Hot], [Metatitle], [ID_Trademark], [CreateDate], [ID_Promotion], [Discount]) VALUES (10, N'Đồng hồ Candino C4500/2', CAST(3140000 AS Decimal(18, 0)), NULL, N'CandinoC45002.jpg', NULL, 1, N'cadino', 7, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Avatar], [Images], [Hot], [Metatitle], [ID_Trademark], [CreateDate], [ID_Promotion], [Discount]) VALUES (11, N'Đồng hồ Skagen 584LSLM', CAST(2560000 AS Decimal(18, 0)), NULL, N'Skagen584LSLM.jpg', NULL, 1, N'skagen', 8, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Avatar], [Images], [Hot], [Metatitle], [ID_Trademark], [CreateDate], [ID_Promotion], [Discount]) VALUES (12, N'Apple Watch S1 42mm', CAST(2155500 AS Decimal(18, 0)), NULL, N'applewatchs142mm.jpg', NULL, 1, N'apple', 9, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Avatar], [Images], [Hot], [Metatitle], [ID_Trademark], [CreateDate], [ID_Promotion], [Discount]) VALUES (13, N'Samsung Gear Fit2 Pro', CAST(2124440 AS Decimal(18, 0)), NULL, N'samsunggearfit2pro.jpg', NULL, 1, N'samsung', 10, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Avatar], [Images], [Hot], [Metatitle], [ID_Trademark], [CreateDate], [ID_Promotion], [Discount]) VALUES (14, N'Huawei Band 3e ', CAST(1254500 AS Decimal(18, 0)), NULL, N'huaweiband3e.jpg', NULL, 1, N'huawei', 11, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Avatar], [Images], [Hot], [Metatitle], [ID_Trademark], [CreateDate], [ID_Promotion], [Discount]) VALUES (15, N'Mi-Band 3', CAST(3420000 AS Decimal(18, 0)), NULL, N'miband3.jpg', NULL, 1, N'miband', 12, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Avatar], [Images], [Hot], [Metatitle], [ID_Trademark], [CreateDate], [ID_Promotion], [Discount]) VALUES (18, N'Fitbit Charge 3 Đen', CAST(2323500 AS Decimal(18, 0)), NULL, N'fitbitcharge3den.jpg', NULL, 1, N'fibit', 13, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[ProductColor] ON 

INSERT [dbo].[ProductColor] ([ID_Color], [Name]) VALUES (1, N'Đen')
INSERT [dbo].[ProductColor] ([ID_Color], [Name]) VALUES (2, N'Nâu')
INSERT [dbo].[ProductColor] ([ID_Color], [Name]) VALUES (3, N'Xám')
SET IDENTITY_INSERT [dbo].[ProductColor] OFF
SET IDENTITY_INSERT [dbo].[Promotion] ON 

INSERT [dbo].[Promotion] ([ID_Promotion], [Name], [StartTime], [EndTime], [Description]) VALUES (1, N'Mùa hè năng động', CAST(N'2019-03-31 00:00:00.000' AS DateTime), CAST(N'2019-04-01 00:00:00.000' AS DateTime), N'Một mùa hè sôi động với đồng hồ sang trọng')
SET IDENTITY_INSERT [dbo].[Promotion] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([ID_Role], [Name]) VALUES (1, N'user')
INSERT [dbo].[Roles] ([ID_Role], [Name]) VALUES (2, N'admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Trademark] ON 

INSERT [dbo].[Trademark] ([ID_Trademark], [Name], [Metatitle], [ID_Category]) VALUES (2, N'ĐỒNG HỒ ORIENT', N'orient', 1)
INSERT [dbo].[Trademark] ([ID_Trademark], [Name], [Metatitle], [ID_Category]) VALUES (3, N'ĐỒNG HỒ SEIKO', N'seiko', 1)
INSERT [dbo].[Trademark] ([ID_Trademark], [Name], [Metatitle], [ID_Category]) VALUES (4, N'ĐỒNG HỒ OP', N'op', 1)
INSERT [dbo].[Trademark] ([ID_Trademark], [Name], [Metatitle], [ID_Category]) VALUES (5, N'ĐỒNG HỒ DW', N'dw', 1)
INSERT [dbo].[Trademark] ([ID_Trademark], [Name], [Metatitle], [ID_Category]) VALUES (6, N'ĐỒNG HỒ CITIZEN', N'citizen', 1)
INSERT [dbo].[Trademark] ([ID_Trademark], [Name], [Metatitle], [ID_Category]) VALUES (7, N'ĐỒNG HỒ CANDINO', N'candino', 1)
INSERT [dbo].[Trademark] ([ID_Trademark], [Name], [Metatitle], [ID_Category]) VALUES (8, N'ĐỒNG HỒ SKAGEN', N'skagen', 1)
INSERT [dbo].[Trademark] ([ID_Trademark], [Name], [Metatitle], [ID_Category]) VALUES (9, N'APPLE', N'apple', 2)
INSERT [dbo].[Trademark] ([ID_Trademark], [Name], [Metatitle], [ID_Category]) VALUES (10, N'SAMSUNG', N'samsung', 2)
INSERT [dbo].[Trademark] ([ID_Trademark], [Name], [Metatitle], [ID_Category]) VALUES (11, N'HUAWEI', N'huawei', 2)
INSERT [dbo].[Trademark] ([ID_Trademark], [Name], [Metatitle], [ID_Category]) VALUES (12, N'XIAOMI', N'xiaomi', 2)
INSERT [dbo].[Trademark] ([ID_Trademark], [Name], [Metatitle], [ID_Category]) VALUES (13, N'FITBIT', N'fitbit', 2)
SET IDENTITY_INSERT [dbo].[Trademark] OFF
ALTER TABLE [dbo].[Login] ADD  DEFAULT (NULL) FOR [Username]
GO
ALTER TABLE [dbo].[Login] ADD  DEFAULT (NULL) FOR [Password]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (NULL) FOR [Phone]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (NULL) FOR [Address]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (NULL) FOR [Status]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (NULL) FOR [Create_Date]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (NULL) FOR [Transport]
GO
ALTER TABLE [dbo].[ProductDetail] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [Address]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [Sex]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [Phone]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [email]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Role] FOREIGN KEY([ID_Role])
REFERENCES [dbo].[Roles] ([ID_Role])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Role]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([ID_Order])
REFERENCES [dbo].[Orders] ([ID_Order])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_ProductDetail] FOREIGN KEY([ID_ProductDetail])
REFERENCES [dbo].[ProductDetail] ([ID_ProductDetail])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_ProductDetail]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([ID_Trademark])
REFERENCES [dbo].[Trademark] ([ID_Trademark])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Promotion] FOREIGN KEY([ID_Promotion])
REFERENCES [dbo].[Promotion] ([ID_Promotion])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Promotion]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetail_Color] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Product] ([ID_Product])
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_ProductDetail_Color]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetail_Product] FOREIGN KEY([ID_Color])
REFERENCES [dbo].[ProductColor] ([ID_Color])
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_ProductDetail_Product]
GO
ALTER TABLE [dbo].[Trademark]  WITH CHECK ADD  CONSTRAINT [FK_Trademark_Category] FOREIGN KEY([ID_Category])
REFERENCES [dbo].[Category] ([ID_Category])
GO
ALTER TABLE [dbo].[Trademark] CHECK CONSTRAINT [FK_Trademark_Category]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_Login] FOREIGN KEY([ID_Login])
REFERENCES [dbo].[Login] ([ID_Login])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_Login]
GO
