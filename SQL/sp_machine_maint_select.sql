USE [db_test]
GO
/****** Object:  StoredProcedure [dbo].[sp_machine_maint_select]    Script Date: 3/9/2019 9:39:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=============================================
Author:      Jack Nagel
Create date: 03/07/2019
Description: Select from machine_maint
Usage:       API
=============================================
*/
ALTER     PROCEDURE [dbo].[sp_machine_maint_select]

	@work_order			NVARCHAR(50)		= NULL,
	@machine			NVARCHAR(50)		= NULL,
	@employee			NVARCHAR(50)		= NULL,
	@num_rows			INT					= 20

AS
BEGIN
	SET NOCOUNT ON;

	SELECT  @work_order = NULLIF(LTRIM(RTRIM(@work_order)), ''),
			@machine = NULLIF(LTRIM(RTRIM(@machine)), ''),
			@employee = NULLIF(LTRIM(RTRIM(@employee)), '')
			

	SELECT TOP (@num_rows) mm.id AS [machineMaintId],
						   mm.machine,
						   mm.work_order AS [workOrder],
						   mm.employee,
						   mm.scan_in_dt AS [scanInDt],
						   FORMAT(mm.scan_in_dt, 'MM/dd/yy HH:mm', 'en-US') AS [scanInDtFormatted],
						   mm.scan_out_dt AS [scanOutDt],
						   FORMAT(mm.scan_out_dt, 'MM/dd/yy HH:mm', 'en-US') AS [scanOutDtFormatted],
						   CONVERT(NVARCHAR, DATEDIFF(MINUTE, mm.scan_in_dt, mm.scan_out_dt))
								+ ' m (' + CONVERT(NVARCHAR, FORMAT(DATEDIFF(MINUTE, mm.scan_in_dt, mm.scan_out_dt) / 60.0, 'N2')) + ' h)'
								AS [duration]
	FROM machine_maint mm
	WHERE (@work_order IS NULL
		OR mm.work_order LIKE '%' + @work_order + '%')
		AND (@machine IS NULL
			OR mm.machine LIKE '%' + @machine + '%')
		AND (@employee IS NULL
			OR mm.employee LIKE '%' + @employee + '%')
	ORDER BY mm.id DESC

END

go

exec sp_machine_maint_select

