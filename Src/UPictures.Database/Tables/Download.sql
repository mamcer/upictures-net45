CREATE TABLE [dbo].[Download] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (255) NOT NULL,
    [CreationDate] DATETIME       NOT NULL,
    [Status]       INT            NOT NULL,
    [FileName]     NVARCHAR (255) DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_dbo.Download] PRIMARY KEY CLUSTERED ([Id] ASC)
);

