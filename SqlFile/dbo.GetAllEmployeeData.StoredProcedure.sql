USE [EmployeeDetails]
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployeeData]    Script Date: 12-Apr-21 11:34:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE    PROCEDURE [dbo].[GetAllEmployeeData]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
  SELECT 
  EmpID, ProfileImage, EmpName, Gender, Salary, StartDate, Notes,
  stuff((select ',' + DepartmentName from Department D
  left join EmpDepartment ED on D.DeptID = ED.DeptID where ED.EmpID = E.EmpID
  FOR XML PATH('')), 1, 1, '') as DepartmentNames
  from
  EmpPayroll E;
END
GO
