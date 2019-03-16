USE [db_test]
GO
/****** Object:  StoredProcedure [dbo].[sp_machine_maint_scan_out]    Script Date: 3/6/2019 8:36:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=============================================
Author:      Jack Nagel
Create date: 03/07/2019
Description: Select from machine_maint_parts
Usage:       API
=============================================
*/
CREATE OR ALTER   PROCEDURE [dbo].[sp_machine_maint_parts_select]

	@machine_maint_id	NVARCHAR(50)		= NULL

AS
BEGIN
	SET NOCOUNT ON;

	SELECT mmp.machine_maint_id AS [machineMaintId],
		   mmp.id AS [macineMaintPartsId],
		   mmp.part,
		   mmp.quantity
	FROM machine_maint_parts mmp
	WHERE (mmp.machine_maint_id = @machine_maint_id)
	ORDER BY mmp.part

END

go

exec sp_machine_maint_parts_select