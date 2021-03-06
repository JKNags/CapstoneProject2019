USE [db_test]
GO
/****** Object:  StoredProcedure [dbo].[sp_machine_maint_scan_in]    Script Date: 3/16/2019 10:59:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=============================================
Author:      Jack Nagel
Create date: 02/26/2018
Description: Inserts into machine_maint
Usage:       API
=============================================
*/
ALTER   PROCEDURE [dbo].[sp_machine_maint_scan_in]

	@id					BIGINT				= NULL OUTPUT,
	@machine			NVARCHAR(50)		= NULL,
	@work_order			NVARCHAR(50)		= NULL,
	@employee			NVARCHAR(50)		= NULL,
	@scan_in_dt			NVARCHAR(50)		= NULL OUTPUT,

	@error_number		INT					= 0 OUTPUT,
	@error_message		NVARCHAR(200)		= NULL OUTPUT

AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @trancount INT = @@trancount,
			@transaction_dt DATETIME = GETDATE()
	
	DECLARE @other_id BIGINT = NULL,
			@other_machine NVARCHAR(50) = NULL,
			@other_work_order NVARCHAR(50) = NULL,
			@other_scan_in_dt DATETIME = NULL

	BEGIN TRY
		IF @trancount = 0
			BEGIN TRANSACTION;
		ELSE SAVE TRANSACTION sp_machine_maint_scan_in;

		IF @machine IS NULL
			RAISERROR('Scan Equipment barcode.', 11, 1)

		IF @work_order IS NULL
			RAISERROR('Scan Work Order barcode.', 11, 1)

		IF @employee IS NULL
			RAISERROR('Scan Employee ID barcode.', 11, 1)

		-- Allow scan in (re-entry) when entering same machine, work order, and
		--   employee of a running record (for when app is closed while scanned in)
		--   , but error when different machine or work order for an employee scanned in

		SELECT @other_id = mm.id,
			   @other_machine = mm.machine,
			   @other_work_order = mm.work_order,
			   @other_scan_in_dt = mm.scan_in_dt
			FROM machine_maint mm
			WHERE mm.employee = @employee
			AND scan_out_dt IS NULL

		----------------------------------
		-- Add Machine Maint Data
		----------------------------------
		IF (@other_machine IS NOT NULL
				AND @other_machine <> @machine)
			OR (@other_work_order IS NOT NULL
				AND @other_work_order <> @work_order)
		BEGIN
			RAISERROR('You are already scanned into other Equipment (%s) for Work Order (%s).', 11, 1, @other_machine, @other_work_order)
		END
		ELSE IF (@other_machine IS NULL
			AND @other_work_order IS NULL)
		BEGIN
			INSERT INTO machine_maint
				(work_order,
				machine,
				employee,
				scan_in_dt,
				scan_out_dt)
			VALUES
				(@work_order,
				@machine,
				@employee,
				@transaction_dt,
				NULL)

			SELECT @other_id = SCOPE_IDENTITY(),
				   @other_scan_in_dt = @transaction_dt
		END

		SELECT @id = @other_id,
			   @scan_in_dt = FORMAT(@other_scan_in_dt, 'MM/dd/yyyy HH:mm', 'en-US')

		IF @trancount = 0
			COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF (@trancount = 0 AND @@trancount > 0)
			OR XACT_STATE() = -1
			ROLLBACK TRANSACTION;
		ELSE IF @trancount > 0
			ROLLBACK TRANSACTION sp_machine_maint_scan_in

		SELECT @error_number = ERROR_NUMBER(),
			   @error_message = ERROR_MESSAGE()
	END CATCH

	INSERT INTO audit_sp_machine_maint_scan_in
		(audit_dt,
		work_order,
		machine,
		employee,
		[error_number],
		[error_message])
	VALUES
		(@transaction_dt,
		@work_order,
		@machine,
		@employee,
		@error_number,
		@error_message)

END

