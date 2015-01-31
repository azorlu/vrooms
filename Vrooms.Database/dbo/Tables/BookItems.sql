CREATE TABLE [dbo].[BookItems] (
    [BookItemId]          INT           IDENTITY (1, 1) NOT NULL,
    [BookId]              INT           NOT NULL,
    [CirculationStatusId] INT           NOT NULL,
    [RFID]                VARCHAR (20)  NOT NULL,
    [Barcode]             VARCHAR (20)  NOT NULL,
    [ShelvingLocation]    NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([BookItemId] ASC),
    FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([BookId]),
    FOREIGN KEY ([CirculationStatusId]) REFERENCES [dbo].[CirculationStatuses] ([CirculationStatusId])
);

