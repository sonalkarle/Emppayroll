USE [EmployeeDetails]
GO
/****** Object:  Table [dbo].[EmpPayroll]    Script Date: 12-Apr-21 11:34:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpPayroll](
	[EmpID] [int] IDENTITY(1,1) NOT NULL,
	[EmpName] [varchar](50) NULL,
	[Gender] [char](1) NULL,
	[Salary] [bigint] NULL,
	[StartDate] [date] NULL,
	[Notes] [text] NULL,
	[ProfileImage] [nvarchar](max) NULL,
 CONSTRAINT [EmpPayroll_PrimaryKeyID] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
