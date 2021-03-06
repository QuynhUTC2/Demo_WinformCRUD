USE [DemoCRUDwinform]
GO
/****** Object:  Table [dbo].[StudentsTB]    Script Date: 3/22/2021 7:16:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsTB](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
	[Fathername] [nchar](10) NULL,
	[RollNumber] [nchar](10) NULL,
	[Address] [nchar](10) NULL,
	[Number] [nchar](10) NULL,
 CONSTRAINT [PK_StudentsTB] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
