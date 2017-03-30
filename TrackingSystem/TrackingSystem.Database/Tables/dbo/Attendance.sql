CREATE TABLE [dbo].[Attendance]
(
    [AttendanceId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CardId] INT NOT NULL, 
    [CheckIn] DATETIME2 NOT NULL, 
    [CheckOut] DATETIME2 NULL, 
    CONSTRAINT [FK_Attendance_VisitorCard] FOREIGN KEY ([CardId]) REFERENCES [dbo].[VisitorCard]([CardId])
)
