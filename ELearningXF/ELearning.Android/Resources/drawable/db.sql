USE [BA_ELearning]
GO
/****** Object:  Table [dbo].[Logins]    Script Date: 30/06/2022 12:58:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 30/06/2022 12:58:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Email] [varchar](50) NULL,
	[Tel] [varchar](50) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NULL,
	[Avatar] [varchar](max) NULL,
	[Birthday] [datetime] NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Logins] ON 

INSERT [dbo].[Logins] ([Id], [Username], [Password]) VALUES (1, N'admin', N'123456')
SET IDENTITY_INSERT [dbo].[Logins] OFF
GO
SET IDENTITY_INSERT [dbo].[Staffs] ON 

INSERT [dbo].[Staffs] ([Id], [Name], [Email], [Tel], [Address], [Gender], [Position], [Avatar], [Birthday]) VALUES (1, N'Nguyễn Huy Thắng', N'nguyenthangdev1996@gmail.com', N'0976895423', N'1150 đường Láng', N'Nam', N'Giám đốc', N'https://1.bp.blogspot.com/-_aCcZJgeqEc/XqJ8L-14S0I/AAAAAAAAioM/yGeTg3Nl33kwDZw4A_oiPwbP_slhbnS6gCLcBGAsYHQ/s1600/Con%2B-Meo-De-Thuong%2B%25285%2529.jpg', NULL)
INSERT [dbo].[Staffs] ([Id], [Name], [Email], [Tel], [Address], [Gender], [Position], [Avatar], [Birthday]) VALUES (2, N'Nguyễn Phương Thảo', N'thaonguyen132@gmail.com', N'0976895423', N'1150 đường Láng', N'Nam', N'Trưởng phòng', N'http://bannenbiet.com/wp-content/uploads/2020/07/ngon-ngu-meo.jpg', NULL)
INSERT [dbo].[Staffs] ([Id], [Name], [Email], [Tel], [Address], [Gender], [Position], [Avatar], [Birthday]) VALUES (3, N'Trần Linh Đan', N'danhlinh11@gmail.com', N'0976895423', N'1150 đường Láng', N'Nam', N'Nhân viên', N'https://toplist.vn/images/800px/-111959.jpg', NULL)
INSERT [dbo].[Staffs] ([Id], [Name], [Email], [Tel], [Address], [Gender], [Position], [Avatar], [Birthday]) VALUES (4, N'Phạm Quốc Hoàng', N'quochoangdz@gmail.com', N'0976895423', N'1150 đường Láng', N'Nam', N'Nhân viên', N'https://cf.shopee.vn/file/b7f5d74154eed89a2fc829b10ac91dc3', NULL)
INSERT [dbo].[Staffs] ([Id], [Name], [Email], [Tel], [Address], [Gender], [Position], [Avatar], [Birthday]) VALUES (5, N'Phan Anh Tuấn', N'tuanto@gmail.com', N'0976895423', N'1150 đường Láng', N'Nam', N'Nhân viên', N'https://kenh14cdn.com/thumb_w/650/2016/8-1462079009065.jpg', NULL)
INSERT [dbo].[Staffs] ([Id], [Name], [Email], [Tel], [Address], [Gender], [Position], [Avatar], [Birthday]) VALUES (6, N'Lâm Bảo Ngọc', N'ngocxinhdep14@gmail.com', N'0976895423', N'1150 đường Láng', N'Nam', N'Nhân viên', N'https://t.ex-cdn.com/giadinhmoi.vn/resize/600x595/files/thachthao/2018/05/23/0-1740.jpg', NULL)
INSERT [dbo].[Staffs] ([Id], [Name], [Email], [Tel], [Address], [Gender], [Position], [Avatar], [Birthday]) VALUES (7, N'Cao Minh Anh', N'anhcaohsbc@gmail.com', N'0976895423', N'1150 đường Láng', N'Nam', N'Nhân viên', N'https://toplist.vn/images/800px/meo-long-dai-anh-111954.jpg', NULL)
INSERT [dbo].[Staffs] ([Id], [Name], [Email], [Tel], [Address], [Gender], [Position], [Avatar], [Birthday]) VALUES (8, N'Trần Văn Trung', N'trungml@gmail.com', N'0976895423', N'1150 đường Láng', N'Nam', N'Trưởng phòng', N'https://kenh14cdn.com/thumb_w/650/2016/5-1462079008982.jpg', NULL)
INSERT [dbo].[Staffs] ([Id], [Name], [Email], [Tel], [Address], [Gender], [Position], [Avatar], [Birthday]) VALUES (9, N'Hoàng Ngọc Anh', N'anhhoang4@gmail.com', N'0976895423', N'1150 đường Láng', N'Nam', N'Nhân viên', N'https://trumboss.com/wp-content/uploads/2018/10/phuong-phap-giup-meo-binh-tinh-696x459.jpg', NULL)
SET IDENTITY_INSERT [dbo].[Staffs] OFF
GO
