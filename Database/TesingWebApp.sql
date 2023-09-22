USE [TESTDB]
GO

/****** Object:  Table [dbo].[Town]    Script Date: 9/22/2023 6:28:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Town](
	[TownID] [int] IDENTITY(1,1) NOT NULL,
	[TownName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[TownID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Organisation]    Script Date: 9/22/2023 6:27:11 PM ******/

CREATE TABLE [dbo].[Organisation](
	[OrganisationNumber] [nvarchar](8) NOT NULL,
	[OrganisationName] [nvarchar](50) NOT NULL,
	[AddressLine1] [nvarchar](50) NOT NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[AddressLine3] [nvarchar](50) NULL,
	[AddressLine4] [nvarchar](50) NULL,
	[TownID] [int] NOT NULL,
	[Postcode] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Organisation] PRIMARY KEY CLUSTERED 
(
	[OrganisationNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Organisation]  WITH CHECK ADD  CONSTRAINT [FK_Organisation_Town] FOREIGN KEY([TownID])
REFERENCES [dbo].[Town] ([TownID])
GO

ALTER TABLE [dbo].[Organisation] CHECK CONSTRAINT [FK_Organisation_Town]
GO


USE [TESTDB]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 9/22/2023 6:34:26 PM ******/

CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[OrganisationNumber] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD CONSTRAINT [FK_Employee_Organisation] FOREIGN KEY([OrganisationNumber])
REFERENCES [dbo].[Organisation] ([OrganisationNumber])
GO

ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Organisation]
GO






