USE [db_test]
GO

/****** Object:  Table [dbo].[machine_maint_parts]    Script Date: 3/8/2019 3:22:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[machine_maint_parts](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[machine_maint_id] [bigint] NOT NULL,
	[part] [nvarchar](50) NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_machine_maint_parts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[machine_maint_parts]  WITH CHECK ADD  CONSTRAINT [FK_machine_maint_parts_machine_maint] FOREIGN KEY([machine_maint_id])
REFERENCES [dbo].[machine_maint] ([id])
GO

ALTER TABLE [dbo].[machine_maint_parts] CHECK CONSTRAINT [FK_machine_maint_parts_machine_maint]
GO


