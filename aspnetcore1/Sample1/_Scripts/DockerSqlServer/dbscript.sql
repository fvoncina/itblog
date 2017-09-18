USE master
IF EXISTS(select * from sys.databases where name='aspnetcore_demo_1')
DROP DATABASE aspnetcore_demo_1

CREATE DATABASE aspnetcore_demo_1
GO


/****** Object:  Table [dbo].[Movies]    Script Date: 9/18/2017 12:21:22 PM ******/

USE aspnetcore_demo_1
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Year] [int] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
 (
	[Id] ASC
 )	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO







/* DATA */
INSERT INTO Movies(Id, Title, [Year]) VALUES 
(1, 'The Godfather', 1972),
(2, 'The Godfather: Part II', 1974),
(3, 'The Godfather: Part III', 1990);

