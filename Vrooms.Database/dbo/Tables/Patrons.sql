CREATE TABLE [dbo].[Patrons] (
    [PatronId]      INT           IDENTITY (1, 1) NOT NULL,
    [PersonId]      INT           NOT NULL,
    [PatronBarcode] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([PatronId] ASC),
    FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Persons] ([PersonId])
);

