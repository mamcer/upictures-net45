CREATE TABLE [dbo].[DownloadPictures] (
    [Download_Id] INT NOT NULL,
    [Picture_Id]  INT NOT NULL,
    CONSTRAINT [PK_dbo.DownloadPictures] PRIMARY KEY CLUSTERED ([Download_Id] ASC, [Picture_Id] ASC),
    CONSTRAINT [FK_dbo.DownloadPictures_dbo.Download_Download_Id] FOREIGN KEY ([Download_Id]) REFERENCES [dbo].[Download] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.DownloadPictures_dbo.Picture_Picture_Id] FOREIGN KEY ([Picture_Id]) REFERENCES [dbo].[Picture] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Picture_Id]
    ON [dbo].[DownloadPictures]([Picture_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Download_Id]
    ON [dbo].[DownloadPictures]([Download_Id] ASC);

