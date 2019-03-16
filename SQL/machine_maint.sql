USE [db_test]
GO

/****** Object:  Table [dbo].[machine_maint]    Script Date: 3/8/2019 3:22:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[machine_maint](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[work_order] [nvarchar](50) NOT NULL,
	[machine] [nvarchar](50) NOT NULL,
	[employee] [nvarchar](50) NOT NULL,
	[scan_in_dt] [datetime] NOT NULL,
	[scan_out_dt] [datetime] NULL,
 CONSTRAINT [PK_machine_maint] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


