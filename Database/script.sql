USE [WatchShop]
GO
/****** Object:  Table [dbo].[About]    Script Date: 4/27/2019 4:53:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[About](
	[ID_About] [bigint] IDENTITY(1,1) NOT NULL,
	[Header] [ntext] NULL,
	[Image] [varchar](200) NULL,
	[Title_Body] [nvarchar](200) NULL,
	[Body] [ntext] NULL,
	[Title_Guarantee] [nvarchar](200) NULL,
	[Guarantee] [ntext] NULL,
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[ID_About] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/27/2019 4:53:13 PM ******/
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
/****** Object:  Table [dbo].[Contact]    Script Date: 4/27/2019 4:53:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contact](
	[ID_Contact] [bigint] IDENTITY(1,1) NOT NULL,
	[Phone] [varchar](12) NULL,
	[Email] [varchar](200) NULL,
	[Address] [nvarchar](200) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID_Contact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 4/27/2019 4:53:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID_Feedback] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Address] [nvarchar](200) NULL,
	[Email] [varchar](200) NULL,
	[Content] [ntext] NULL,
	[CreateDate] [datetime] NULL,
	[Phone] [varchar](12) NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[ID_Feedback] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 4/27/2019 4:53:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[ID_Login] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](100) NULL DEFAULT (NULL),
	[Password] [varchar](200) NULL DEFAULT (NULL),
	[ID_Role] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 4/27/2019 4:53:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ID_OrderDetail] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_Order] [bigint] NOT NULL,
	[Quantity] [int] NULL CONSTRAINT [DF__OrderDeta__Quant__2F10007B]  DEFAULT ((0)),
	[TotalPrice] [decimal](18, 0) NULL CONSTRAINT [DF__OrderDeta__Total__300424B4]  DEFAULT ((0)),
	[ID_Product] [bigint] NULL,
	[CreateDate] [datetime] NULL CONSTRAINT [DF_OrderDetail_CreateDate]  DEFAULT (getdate()),
 CONSTRAINT [PK__OrderDet__855D4EF54439E292] PRIMARY KEY CLUSTERED 
(
	[ID_OrderDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 4/27/2019 4:53:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[ID_Order] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL CONSTRAINT [DF__Orders__Name__276EDEB3]  DEFAULT (NULL),
	[Phone] [char](12) NULL CONSTRAINT [DF__Orders__Phone__286302EC]  DEFAULT (NULL),
	[Address] [nvarchar](500) NULL CONSTRAINT [DF__Orders__Address__29572725]  DEFAULT (NULL),
	[Status] [nvarchar](10) NULL CONSTRAINT [DF__Orders__Status__2A4B4B5E]  DEFAULT (NULL),
	[CreateDate] [datetime] NULL CONSTRAINT [DF__Orders__Create_D__2B3F6F97]  DEFAULT (getdate()),
	[Transport] [nvarchar](100) NULL CONSTRAINT [DF__Orders__Transpor__2C3393D0]  DEFAULT (NULL),
	[Note] [ntext] NULL,
	[Email] [varchar](200) NULL,
 CONSTRAINT [PK__Orders__EC9FA955638D0AE2] PRIMARY KEY CLUSTERED 
(
	[ID_Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/27/2019 4:53:13 PM ******/
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
	[Content] [ntext] NULL,
	[Avatar] [varchar](200) NULL,
	[Quantity] [int] NULL,
	[Hot] [bit] NULL,
	[Discount] [decimal](18, 0) NULL,
	[Metatitle] [varchar](100) NULL,
	[CreateDate] [datetime] NULL CONSTRAINT [DF_Product_CreateDate]  DEFAULT (getdate()),
	[ID_Trademark] [bigint] NOT NULL,
	[ID_Promotion] [bigint] NULL,
 CONSTRAINT [PK__Product__522DE496F74B3569] PRIMARY KEY CLUSTERED 
(
	[ID_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 4/27/2019 4:53:13 PM ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 4/27/2019 4:53:13 PM ******/
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
/****** Object:  Table [dbo].[Trademark]    Script Date: 4/27/2019 4:53:13 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 4/27/2019 4:53:13 PM ******/
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
SET IDENTITY_INSERT [dbo].[About] ON 

INSERT [dbo].[About] ([ID_About], [Header], [Image], [Title_Body], [Body], [Title_Guarantee], [Guarantee]) VALUES (1, N'Dù mới được thành lập trong vài năm gần đây nhưng ShopWatch đã, đang và sẽ vươn lên giữ vị trí số 1 trong những cửa hàng bán lẽ đồng hồ tại Việt Nam, tiếp tục sứ mệnh mang vẻ đẹp, tinh hoa của những chiếc đồng hồ chính hãng cao cấp của các thương hiệu đồng hồ nổi tiếng đến với những người đam mê đồng hồ tại Việt Nam.

Với mong muốn đem đến khách hàng những giá trị cao nhất, ShopWatch không chỉ bán những chiếc đồng hồ chính hãng tốt nhất tới khách hàng mà còn đem tới khách hàng những chế độ bảo hành, hậu mãi mà khó có cửa hàng nào đáp ứng được.', N'image_about.jpg', N'ShopWatch và những quan điểm trong kinh doanh', N'Ngay từ những ngày đầu thành lập, ShopWatch đã xác định rõ quan điểm kinh doanh: “Khách hàng, chất lượng và uy tín phải được đưa lên hàng đầu”. Điều này đều được các cán bộ, nhân viên của ShopWatch hiểu rõ và tuân thủ tuyệt đối.

Tuyệt đối không bán hàng giải, hàng nhái, hàng kém chất lượng, không rõ nguồn gốc, xuất xứ … cho khách hàng.
Cung cấp cho quý khách hàng những sản phẩm tốt nhất với giá cả cạnh tranh cùng với những dịch vụ hoàn hảo nhất.
Phải đặt chữ TÍN lên hàng đầu, không vì lợi nhuận mà lừa đối khách hàng.
Đặt mình vào địa vị khách hàng để đưa ra những quyết định, chính sách hợp lý nhất.', N'Chính sách bảo hành tại ShopWatch', N'Thấu hiểu tâm lý khách hàng, ngoài chính sách bảo hành chính hãng do nhà sản xuất quy định, ShopWatch còn mang tới những gói dịch vụ bảo hành tốt nhất với từng nhu cầu của khách hàng.

Bảo hành tiêu chuẩn: Thời hạn bảo hành trong vòng 1 năm (tương đương 12 tháng). Với gói bảo hành này, bạn sẽ được thay pin miễn phí đối với các dòng máy Quartz và hỗ trợ sửa chữa miễn phí với các lỗi nhiễm từ, sai số, ngấm nước.
Bảo hành vàng: Đây là gói bảo hành phải trả phí và để sở hữu gói bảo hàng này bạn chỉ cần bỏ ra 300.000 VNĐ. Thời hạn bảo hành của gói này là 5 năm (tương đương 60 tháng). Với gói bảo hành này, bạn sẽ được miễn phí: thay pin (đối với máy Quartz); sửa chữa lỗi nhiễm từ, sai số, ngấm nước; đánh bóng mặt đồng hồ; bảo dưỡng lau dầu và hỗ trợ 50% chi phi thay thế linh kiện bên trong.
Bảo hành kim cương: Thời hạn bảo hành 5 năm (tương đương 60 tháng). Giống như gói bảo hành vàng, bạn cũng sẽ được miễn phí thay pin, sửa lỗi nhiễm từ, sai số, ngấm nước, đánh bóng mặt đồng hồ, bảo dưỡng lau dầu. Tuy nhiên, điểm khác biệt lớn nhất đó chính là bạn được miễn phí 100% chi phí thay thế linh kiện bên trong và được hỗ trợ 50% chi phí thay thế linh kiện bên ngoài.
Nếu bạn đã chọn mua và được hưởng những chính sách bán hàng – bảo hành của ShopWatch dù chỉ một lần, chúng tôi tin và hy vọng quý khách hàng sẽ cảm thấy hài lòng.')
SET IDENTITY_INSERT [dbo].[About] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID_Category], [Name], [Metatitle]) VALUES (1, N'ĐỒNG HỒ CỔ ĐIỂN', N'codien')
INSERT [dbo].[Category] ([ID_Category], [Name], [Metatitle]) VALUES (2, N'ĐỒNG HỒ THÔNG MINH', N'hiendai')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([ID_Contact], [Phone], [Email], [Address]) VALUES (1, N'123456789', N'watchshop@gmail.com', N'213 Hoàng Quốc Việt, Cầu Giấy, Hà Nội')
SET IDENTITY_INSERT [dbo].[Contact] OFF
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([ID_Login], [Username], [Password], [ID_Role]) VALUES (1, N'admin', N'12345', 2)
INSERT [dbo].[Login] ([ID_Login], [Username], [Password], [ID_Role]) VALUES (2, N'user', N'12345', 1)
SET IDENTITY_INSERT [dbo].[Login] OFF
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([ID_OrderDetail], [ID_Order], [Quantity], [TotalPrice], [ID_Product], [CreateDate]) VALUES (1, 1, 1, CAST(4200000 AS Decimal(18, 0)), 2, NULL)
INSERT [dbo].[OrderDetail] ([ID_OrderDetail], [ID_Order], [Quantity], [TotalPrice], [ID_Product], [CreateDate]) VALUES (2, 2, 1, CAST(200 AS Decimal(18, 0)), 2, NULL)
INSERT [dbo].[OrderDetail] ([ID_OrderDetail], [ID_Order], [Quantity], [TotalPrice], [ID_Product], [CreateDate]) VALUES (3, 3, 777, CAST(155400 AS Decimal(18, 0)), 2, NULL)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID_Order], [Name], [Phone], [Address], [Status], [CreateDate], [Transport], [Note], [Email]) VALUES (1, N'Lê Văn Dũng', N'0349987549  ', N'Hà Nội', N'W', CAST(N'2019-04-04 11:10:12.977' AS DateTime), N'CPN', N'note', N'dungleevan08121998@gmail.com')
INSERT [dbo].[Orders] ([ID_Order], [Name], [Phone], [Address], [Status], [CreateDate], [Transport], [Note], [Email]) VALUES (2, N'Citizen NH8350-83A', N'22223878374 ', N'mndmsn', N'CF', CAST(N'2019-04-08 18:18:55.380' AS DateTime), N'CPN', N'sdsd', N'sas@gmail.com')
INSERT [dbo].[Orders] ([ID_Order], [Name], [Phone], [Address], [Status], [CreateDate], [Transport], [Note], [Email]) VALUES (3, N'Nguyễn Thị Hường', N'0123456789  ', N'Đặng Thùy Trâm', N'CF', CAST(N'2019-04-08 20:44:20.097' AS DateTime), N'CPN', N'heloo', N'huong@gmail.com')
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Content], [Avatar], [Quantity], [Hot], [Discount], [Metatitle], [CreateDate], [ID_Trademark], [ID_Promotion]) VALUES (2, N'Orient FDD03001W0', CAST(200 AS Decimal(18, 0)), NULL, NULL, N'OrientFDD03001W0.jpg', NULL, 1, CAST(10000 AS Decimal(18, 0)), N'orient', NULL, 2, 1)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Content], [Avatar], [Quantity], [Hot], [Discount], [Metatitle], [CreateDate], [ID_Trademark], [ID_Promotion]) VALUES (3, N'Seiko SNKN85J1', CAST(3150000 AS Decimal(18, 0)), NULL, NULL, N'SeikoSNKN85J1.jpg', NULL, 1, CAST(11000 AS Decimal(18, 0)), N'seiko', NULL, 3, 1)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Content], [Avatar], [Quantity], [Hot], [Discount], [Metatitle], [CreateDate], [ID_Trademark], [ID_Promotion]) VALUES (4, N'OLYM PIANUS OP990-133AMS', CAST(300 AS Decimal(18, 0)), NULL, NULL, N'OLYMPIANUSOP990133AMS.jpg', NULL, 1, CAST(12000 AS Decimal(18, 0)), N'olym', NULL, 4, 1)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Content], [Avatar], [Quantity], [Hot], [Discount], [Metatitle], [CreateDate], [ID_Trademark], [ID_Promotion]) VALUES (7, N'Daniel Wellington DW00100235', CAST(2700000 AS Decimal(18, 0)), NULL, NULL, N'DW00100235.jpg', NULL, 1, CAST(14000 AS Decimal(18, 0)), N'daniel', NULL, 5, 1)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Content], [Avatar], [Quantity], [Hot], [Discount], [Metatitle], [CreateDate], [ID_Trademark], [ID_Promotion]) VALUES (9, N'Citizen NH8350-83A', CAST(2100000 AS Decimal(18, 0)), NULL, NULL, N'NH835083A.jpg', NULL, 1, NULL, N'citizen', NULL, 6, NULL)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Content], [Avatar], [Quantity], [Hot], [Discount], [Metatitle], [CreateDate], [ID_Trademark], [ID_Promotion]) VALUES (10, N'Đồng hồ Candino C4500/2', CAST(3140000 AS Decimal(18, 0)), NULL, NULL, N'CandinoC45002.jpg', NULL, 1, NULL, N'cadino', NULL, 7, NULL)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Content], [Avatar], [Quantity], [Hot], [Discount], [Metatitle], [CreateDate], [ID_Trademark], [ID_Promotion]) VALUES (11, N'Đồng hồ Skagen 584LSLM', CAST(2560000 AS Decimal(18, 0)), NULL, NULL, N'Skagen584LSLM.jpg', NULL, 1, NULL, N'skagen', NULL, 8, NULL)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Content], [Avatar], [Quantity], [Hot], [Discount], [Metatitle], [CreateDate], [ID_Trademark], [ID_Promotion]) VALUES (12, N'Apple Watch S1 42mm', CAST(2155500 AS Decimal(18, 0)), NULL, NULL, N'applewatchs142mm.jpg', NULL, 1, NULL, N'apple', NULL, 9, NULL)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Content], [Avatar], [Quantity], [Hot], [Discount], [Metatitle], [CreateDate], [ID_Trademark], [ID_Promotion]) VALUES (13, N'Samsung Gear Fit2 Pro', CAST(2124440 AS Decimal(18, 0)), NULL, NULL, N'samsunggearfit2pro.jpg', NULL, 1, NULL, N'samsung', NULL, 10, NULL)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Content], [Avatar], [Quantity], [Hot], [Discount], [Metatitle], [CreateDate], [ID_Trademark], [ID_Promotion]) VALUES (14, N'Huawei Band 3e ', CAST(1254500 AS Decimal(18, 0)), NULL, NULL, N'huaweiband3e.jpg', NULL, 1, NULL, N'huawei', NULL, 11, NULL)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Content], [Avatar], [Quantity], [Hot], [Discount], [Metatitle], [CreateDate], [ID_Trademark], [ID_Promotion]) VALUES (15, N'Mi-Band 3', CAST(3420000 AS Decimal(18, 0)), NULL, NULL, N'miband3.jpg', NULL, 1, NULL, N'miband', NULL, 12, NULL)
INSERT [dbo].[Product] ([ID_Product], [Name], [Price], [Description], [Content], [Avatar], [Quantity], [Hot], [Discount], [Metatitle], [CreateDate], [ID_Trademark], [ID_Promotion]) VALUES (18, N'Fitbit Charge 3 Đen', CAST(2323500 AS Decimal(18, 0)), NULL, NULL, N'fitbitcharge3den.jpg', NULL, 1, NULL, N'fibit', NULL, 13, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Promotion] ON 

INSERT [dbo].[Promotion] ([ID_Promotion], [Name], [StartTime], [EndTime], [Description]) VALUES (1, N'Mùa hè năng động', CAST(N'2019-03-31 00:00:00.000' AS DateTime), CAST(N'2019-04-17 00:00:00.000' AS DateTime), N'Một mùa hè sôi động với đồng hồ sang trọng')
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
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Contact_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Product] ([ID_Product])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
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
