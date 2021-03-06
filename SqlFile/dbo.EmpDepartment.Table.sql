USE [EmployeeDetails]
GO
/****** Object:  Table [dbo].[EmpDepartment]    Script Date: 12-Apr-21 11:34:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpDepartment](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [int] NULL,
	[DeptID] [int] NULL,
 CONSTRAINT [EmpDepartment_RecordID_PrimaryKey] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmpDepartment]  WITH CHECK ADD  CONSTRAINT [EmpDepartment_Department_ForeignKey] FOREIGN KEY([DeptID])
REFERENCES [dbo].[Department] ([DeptID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmpDepartment] CHECK CONSTRAINT [EmpDepartment_Department_ForeignKey]
GO
ALTER TABLE [dbo].[EmpDepartment]  WITH CHECK ADD  CONSTRAINT [EmpDepartment_EmpPayroll_ForeignKey] FOREIGN KEY([EmpID])
REFERENCES [dbo].[EmpPayroll] ([EmpID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmpDepartment] CHECK CONSTRAINT [EmpDepartment_EmpPayroll_ForeignKey]
GO
