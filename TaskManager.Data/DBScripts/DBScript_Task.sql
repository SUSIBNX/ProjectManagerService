USE [master]
GO
/****** Object:  Database [ProjectManager]    Script Date: 03-10-2018 20:19:28 ******/
CREATE DATABASE [ProjectManager]

GO
USE [ProjectManager]
GO
/****** Object:  Table [dbo].[ParentTask]    Script Date: 03-10-2018 20:19:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ParentTask](
	[Parent_ID] [int] IDENTITY(1,1) NOT NULL,
	[Parent_Task] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ParentTask] PRIMARY KEY CLUSTERED 
(
	[Parent_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Project]    Script Date: 03-10-2018 20:19:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[Project_ID] [int] IDENTITY(1,1) NOT NULL,
	[Project] [varchar](100) NOT NULL,
	[Start_Date] [datetime] NULL,
	[End_Date] [datetime] NULL,
	[Priority] [int] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Project_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Task]    Script Date: 03-10-2018 20:19:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Task](
	[Task_ID] [int] IDENTITY(1,1) NOT NULL,
	[Parent_ID] [int] NULL,
	[Project_ID] [int] NOT NULL,
	[Task] [varchar](100) NOT NULL,
	[Start_Date] [datetime] NOT NULL,
	[End_Date] [datetime] NOT NULL,
	[Priority] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Task_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 03-10-2018 20:19:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[Employee_ID] [varchar](50) NOT NULL,
	[First_Name] [varchar](100) NOT NULL,
	[Last_Name] [varchar](100) NULL,
	[Project_ID] [int] NULL,
	[Task_ID] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_ParentTask] FOREIGN KEY([Parent_ID])
REFERENCES [dbo].[ParentTask] ([Parent_ID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_ParentTask]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Project] FOREIGN KEY([Project_ID])
REFERENCES [dbo].[Project] ([Project_ID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Project]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Project] FOREIGN KEY([Project_ID])
REFERENCES [dbo].[Project] ([Project_ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Project]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Task] FOREIGN KEY([Task_ID])
REFERENCES [dbo].[Task] ([Task_ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Task]
GO

		     
		     
USE [ProjectManager]
GO
SET IDENTITY_INSERT [dbo].[ParentTask] ON 

INSERT [dbo].[ParentTask] ([Parent_ID], [Parent_Task]) VALUES (1, N'Design')
INSERT [dbo].[ParentTask] ([Parent_ID], [Parent_Task]) VALUES (2, N'Coding')
INSERT [dbo].[ParentTask] ([Parent_ID], [Parent_Task]) VALUES (3, N'UnitTest')
INSERT [dbo].[ParentTask] ([Parent_ID], [Parent_Task]) VALUES (4, N'Deployment')
SET IDENTITY_INSERT [dbo].[ParentTask] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Project_ID], [Project], [Start_Date], [End_Date], [Priority], [Status], [Manager_ID]) VALUES (1, N'PROJECT TEST 2', CAST(N'2018-10-15 17:12:06.000' AS DateTime), CAST(N'2018-12-15 17:12:07.000' AS DateTime), 25, 1, NULL)
SET IDENTITY_INSERT [dbo].[Project] OFF
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([Task_ID], [Parent_ID], [Project_ID], [Task], [Start_Date], [End_Date], [Priority], [Status]) VALUES (3, 2, 1, N'Task from Test', CAST(N'2018-10-15 17:29:13.000' AS DateTime), CAST(N'2018-10-15 17:29:13.000' AS DateTime), 30, 1)
SET IDENTITY_INSERT [dbo].[Task] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([User_ID], [Employee_ID], [First_Name], [Last_Name], [Project_ID], [Task_ID], [IsActive]) VALUES (1, N'EMP0004', N'Test FName', N'Test LName', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[User] OFF


