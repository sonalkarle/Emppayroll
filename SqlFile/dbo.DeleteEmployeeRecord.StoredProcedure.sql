USE [EmployeeDetails]
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployeeRecord]    Script Date: 12-Apr-21 11:34:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[DeleteEmployeeRecord]
	@EmpID		varchar(255)
AS
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @result bit = 0;

	DECLARE @ID int = 0;
    -- Insert statements for procedure here
	

	IF NOT EXISTS(select EmpID from EmpPayroll where EmpID = @EmpID)
	begin;
	throw 50001,'emp id dont exist', -1;
	end;

	WITH DeletedEmp as(
	SELECT 
  EmpID, EmpName, Gender, Salary, StartDate, Notes,
  stuff((select ',' + DepartmentName from Department D
  left join EmpDepartment ED on D.DeptID = ED.DeptID where ED.EmpID = E.EmpID
  FOR XML PATH('')), 1, 1, '') as DepartmentNames
  from
  EmpPayroll E where EmpID = @EmpID)

  select * from DeletedEmp;
  DELETE from EmpPayroll where EmpID = @EmpID;


COMMIT TRANSACTION;	
set @result = 1;
return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		return @result;		
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		set @result = 1;
		return @result;
	END;
END CATCH
	
END
GO
