USE [db_test]
GO
/****** Object:  StoredProcedure [dbo].[sp_machine_maint_scan_out]    Script Date: 3/16/2019 11:03:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=============================================
Author:      Jack Nagel
Create date: 02/26/2018
Description: Updates machine_maint to scan out
Usage:       API
=============================================
*/
ALTER   PROCEDURE [dbo].[sp_machine_maint_scan_out]

	@id					BIGINT				= NULL,
	@parts_xml			NVARCHAR(1000)		= NULL,

	@error_number		INT					= 0 OUTPUT,
	@error_message		NVARCHAR(200)		= NULL OUTPUT

AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @trancount INT = @@trancount
	
	DECLARE @doc_handle INT

	BEGIN TRY
		IF @trancount = 0
			BEGIN TRANSACTION;
		ELSE SAVE TRANSACTION sp_machine_maint_scan_out;

		IF @id IS NULL
			RAISERROR('Machine Maint ID is required.', 11, 1)

		----------------------------------
		-- Scan Out
		----------------------------------

		UPDATE machine_maint
			SET scan_out_dt = GETDATE()
		WHERE id = @id

		IF @@ROWCOUNT <> 1
			RAISERROR('Error scanning out, could not find maintenance record.', 11, 1)

		----------------------------------
		-- Open Parts XML
		----------------------------------
		
		EXEC sp_xml_preparedocument @doc_handle OUTPUT, @parts_xml 
		
		INSERT INTO machine_maint_parts 
			(machine_maint_id,
			 part,
			 quantity)
		SELECT @id,
		       part,
			   SUM(CONVERT(INT, quantity))
		FROM OPENXML (@doc_handle, '/machineMaintParts/machineMaintPart',1)  
			  WITH (part NVARCHAR(50),
					quantity NVARCHAR(20))  
		GROUP BY part

		EXEC sp_xml_removedocument @doc_handle

		IF @trancount = 0
			COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF (@trancount = 0 AND @@trancount > 0)
			OR XACT_STATE() = -1
			ROLLBACK TRANSACTION;
		ELSE IF @trancount > 0
			ROLLBACK TRANSACTION sp_machine_maint_scan_out

		SELECT @error_number = ERROR_NUMBER(),
			   @error_message = ERROR_MESSAGE()
	END CATCH

	INSERT INTO audit_sp_machine_maint_scan_out
		(audit_dt,
		machine_maint_id,
		parts_xml,
		[error_number],
		[error_message])
	VALUES
		(GETDATE(),
		@id,
		@parts_xml,
		@error_number,
		@error_message)

END

