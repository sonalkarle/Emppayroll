USE [EmployeeDetails]
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployeeRecord]    Script Date: 12-Apr-21 11:34:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[UpdateEmployeeRecord]
	@EmpID				int,
	@EmpName		varchar(255),
	@Gender			char(1),
	@StartDate		Date,
	@Salary			Money,
	@Department		varchar(100),
	@Notes			text
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
    -- Insert statements for procedure here
	IF NOT EXISTS(select EmpID from EmpPayroll where EmpID = @EmpID)
	begin;
	throw 50001,'emp id dont exist', -1;
	end
	update EmpPayroll set EmpName = @EmpName where EmpID = @EmpID and @EmpName is not null 
	and @EmpName != '';
	update EmpPayroll set Gender = @Gender where EmpID = @EmpID and @Gender is not null 
	and @Gender != '';
	update EmpPayroll set StartDate = @StartDate where EmpID = @EmpID and @StartDate is not null 
	and @StartDate != '';
	update EmpPayroll set Salary = @Salary where EmpID = @EmpID and @Salary is not null 
	and @Salary != '';
	update EmpPayroll set Notes = @Notes where EmpID = @EmpID and @Notes is not null;

--	if (@Department is null or @Department = '')
--	begin
	delete from EmpDepartment where EmpID = @EmpID;
	insert into EmpDepartment(EmpID, DeptID)
	SELECT @EmpID, DeptID
	FROM 
	Department where DepartmentName in (
	select distinct(value)
	from STRING_SPLIT(@Department, ',')
	WHERE RTRIM(value) <> ''
	)
--	end
	exec GetSpecificEmployeeData @EmpID = @EmpID;

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
