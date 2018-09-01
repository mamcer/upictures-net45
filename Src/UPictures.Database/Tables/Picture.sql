CREATE TABLE [dbo].[Picture] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [FileName]    NVARCHAR (255) NOT NULL,
    [FileSize]    FLOAT (53)     NOT NULL,
    [DateTaken]   DATETIME       NOT NULL,
    [Width]       INT            NOT NULL,
    [Height]      INT            NOT NULL,
    [CameraMaker] NVARCHAR (255) NULL,
    [CameraModel] NVARCHAR (255) NULL,
    [Album_Id]    INT            NOT NULL,
    [Album_Id1]   INT            NOT NULL,
    [FolderName]  NVARCHAR (255) DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_dbo.Picture] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Picture_dbo.Album_Album_Id] FOREIGN KEY ([Album_Id]) REFERENCES [dbo].[Album] ([Id]),
    CONSTRAINT [FK_dbo.Picture_dbo.Album_Album_Id1] FOREIGN KEY ([Album_Id1]) REFERENCES [dbo].[Album] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Album_Id1]
    ON [dbo].[Picture]([Album_Id1] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Album_Id]
    ON [dbo].[Picture]([Album_Id] ASC);

