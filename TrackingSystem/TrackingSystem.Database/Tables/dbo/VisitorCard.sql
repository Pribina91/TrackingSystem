CREATE TABLE [dbo].[VisitorCard]
(
    [CardId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Active] BIT NOT NULL, 
    [VisitorName] NVARCHAR(MAX) NOT NULL
)
