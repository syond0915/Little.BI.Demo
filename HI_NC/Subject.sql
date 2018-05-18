CREATE TABLE [dbo].[Subject]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SubTitle] NVARCHAR(10) NULL, 
    [SubSource] INT NULL, 
    [StudentId] INT NULL
)
