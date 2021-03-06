USE [EmployeeDetails]
GO
/****** Object:  StoredProcedure [dbo].[InsertEmployeeRecord]    Script Date: 12-Apr-21 11:34:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[InsertEmployeeRecord]
	@EmpName		varchar(255),
	@Gender			char(1),
	@StartDate		Date,
	@Salary		bigint,
	@Department		varchar(100),
	@Notes			text,
	@ProfileImage	nvarchar(max)
AS
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @new_identity INTEGER = 0;
	declare @Identity table (ID int)
	DECLARE @result bit = 0;
    -- Insert statements for procedure here
	
	Insert into EmpPayroll(ProfileImage, EmpName, Gender, StartDate, Salary, Notes) output Inserted.EmpID into @Identity
	VALUES(@ProfileImage, @EmpName, @Gender, @StartDate, @Salary, @Notes);
	SELECT @new_identity = (select ID from @Identity);

	if @Department is not null or @Department != ''
	begin
	insert into EmpDepartment(EmpID, DeptID)
	SELECT @new_identity, DeptID
	FROM 
	Department where DepartmentName in (
	select distinct(value)
	from STRING_SPLIT(@Department, ',')
	WHERE RTRIM(value) <> ''
	);
	end

	exec GetSpecificEmployeeData @EmpID = @new_identity;
--	and NOT EXISTS(SELECT DeptID FROM Department where DeptID = @DeptID);

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
