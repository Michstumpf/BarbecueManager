USE [BarbecueManager]
GO

/****** Object:  Table [dbo].[Barbecue]    Script Date: 30/11/2017 11:54:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Barbecue](
	[BarbecueID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Reason] [nvarchar](200) NOT NULL,
	[Observation] [nvarchar](max) NULL,
	[AmountWithDrink] [numeric](15, 2) NULL,
	[AmountWithoutDrink] [numeric](15, 2) NULL,
 CONSTRAINT [PK_Barbecue] PRIMARY KEY CLUSTERED 
(
	[BarbecueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


