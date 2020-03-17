CREATE TABLE [dbo].[Task](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[title] [nvarchar](255) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[complete] [bit] NOT NULL,
)

INSERT [dbo].[Task] ([title], [description], [complete]) VALUES (N'This is task one', N'This is description task one', 1)
INSERT [dbo].[Task] ([title], [description], [complete]) VALUES (N'This is task two', N'This is description task two', 0)
INSERT [dbo].[Task] ([title], [description], [complete]) VALUES (N'This is task three', N'This is description task three', 1)