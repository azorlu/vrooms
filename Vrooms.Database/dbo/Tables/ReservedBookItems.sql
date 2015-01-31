CREATE TABLE [dbo].[ReservedBookItems] (
    [ReservedBookItemId] INT      IDENTITY (1, 1) NOT NULL,
    [BookItemId]         INT      NOT NULL,
    [PatronId]           INT      NOT NULL,
    [DateReserved]       DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([ReservedBookItemId] ASC),
    FOREIGN KEY ([BookItemId]) REFERENCES [dbo].[BookItems] ([BookItemId]),
    FOREIGN KEY ([PatronId]) REFERENCES [dbo].[Patrons] ([PatronId]),
    CONSTRAINT [UQ_BookItemId_PatronId] UNIQUE NONCLUSTERED ([BookItemId] ASC, [PatronId] ASC)
);

