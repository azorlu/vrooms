CREATE TABLE [dbo].[Persons] (
    [PersonId]     INT            IDENTITY (1, 1) NOT NULL,
    [NameStyle]    BIT            NOT NULL,
    [Title]        NVARCHAR (10)  NOT NULL,
    [FirstName]    NVARCHAR (50)  NOT NULL,
    [MiddleName]   NVARCHAR (50)  NOT NULL,
    [LastName]     NVARCHAR (50)  NOT NULL,
    [Suffix]       NVARCHAR (10)  NOT NULL,
    [EmailAddress] NVARCHAR (255) NOT NULL,
    [PhoneNumber]  NVARCHAR (20)  NOT NULL,
    [AddressLine1] NVARCHAR (100) NOT NULL,
    [AddressLine2] NVARCHAR (100) NOT NULL,
    [City]         NVARCHAR (30)  NOT NULL,
    [PostalCode]   NVARCHAR (15)  NOT NULL,
    PRIMARY KEY CLUSTERED ([PersonId] ASC)
);

