USE [db_test]
GO

/****** Object:  Table [dbo].[audit_sp_machine_maint_scan_out]    Script Date: 3/8/2019 3:21:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[audit_sp_machine_maint_scan_out](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[audit_dt] [datetime] NULL,
	[machine_maint_id] [nvarchar](50) NULL,
	[parts_xml] [nvarchar](1000) NULL,
	[status_code] [int] NULL,
	[status_desc] [nvarchar](200) NULL,
 CONSTRAINT [PK_audit_sp_machine_maint_scan_out] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


