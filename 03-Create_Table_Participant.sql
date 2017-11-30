USE [BarbecueManager]
GO

/****** Object:  Table [dbo].[Participant]    Script Date: 30/11/2017 11:54:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Participant](
	[ParticipantID] [int] IDENTITY(1,1) NOT NULL,
	[BarbecueID] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ContributionAmount] [numeric](15, 2) NULL,
	[IsPaid] [bit] NOT NULL,
	[IsWithDrink] [bit] NOT NULL,
	[Observation] [nvarchar](max) NULL,
 CONSTRAINT [PK_Participant] PRIMARY KEY CLUSTERED 
(
	[ParticipantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Participant]  WITH CHECK ADD  CONSTRAINT [FK_Participant_Barbecue] FOREIGN KEY([BarbecueID])
REFERENCES [dbo].[Barbecue] ([BarbecueID])
GO

ALTER TABLE [dbo].[Participant] CHECK CONSTRAINT [FK_Participant_Barbecue]
GO


