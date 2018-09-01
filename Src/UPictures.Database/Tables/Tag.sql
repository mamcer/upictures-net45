CREATE TABLE [dbo].[Tag] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (255) NOT NULL,
    [Picture_Id] INT            NULL,
    CONSTRAINT [PK_dbo.Tag] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Tag_dbo.Picture_Picture_Id] FOREIGN KEY ([Picture_Id]) REFERENCES [dbo].[Picture] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_Picture_Id]
    ON [dbo].[Tag]([Picture_Id] ASC);

