CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[username] [nvarchar](255) NOT NULL,
	[fullname] [nvarchar](255) NOT NULL
)

CREATE TABLE [dbo].[Task](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[title] [nvarchar](255) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[user] [int] NOT NULL REFERENCES [User](id),
)

INSERT [dbo].[User] ([username], [fullname]) VALUES (N'hoapn', N'Phạm Ngọc Hòa')
INSERT [dbo].[User] ([username], [fullname]) VALUES (N'nhattq', N'Trần Quang Nhật')
INSERT [dbo].[User] ([username], [fullname]) VALUES (N'hiepdq', N'Đỗ Quang Hiệp')

INSERT [dbo].[Task] ([title], [description], [user]) VALUES (N'Học SEO', N'Nghiên cứu về SEO cho developer', 1)
INSERT [dbo].[Task] ([title], [description], [user]) VALUES (N'Học chạy ads facebook', N'Chuẩn bị để chạy ad cho trang vietdesign', 3)
INSERT [dbo].[Task] ([title], [description], [user]) VALUES (N'Code phần thông tin', N'Phần thông tin chi tiết của từng sản phẩm', 1)