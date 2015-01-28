CREATE TABLE [dbo].[Books] (
    [BookId]          INT             IDENTITY (1, 1) NOT NULL,
    [Title]           NVARCHAR (255)  NOT NULL,
    [Author]          NVARCHAR (255)  NOT NULL,
    [Publisher]       NVARCHAR (255)  NOT NULL,
    [PublicationYear] SMALLINT        NULL,
    [ISBN]            BIGINT          NULL,
    [Description]     NVARCHAR (1024) NOT NULL,
    [LanguageId]      INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([BookId] ASC),
    FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Languages] ([LanguageId])
);

