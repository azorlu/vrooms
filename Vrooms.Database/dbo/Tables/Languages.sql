CREATE TABLE [dbo].[Languages] (
    [LanguageId]      INT           IDENTITY (1, 1) NOT NULL,
    [Iso3]            CHAR (3)      NOT NULL,
    [LanguageName_En] NVARCHAR (64) NOT NULL,
    PRIMARY KEY CLUSTERED ([LanguageId] ASC)
);

