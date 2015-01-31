CREATE TABLE [dbo].[CirculationStatuses] (
    [CirculationStatusId] INT           IDENTITY (1, 1) NOT NULL,
    [Description]         NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CirculationStatusId] ASC)
);

