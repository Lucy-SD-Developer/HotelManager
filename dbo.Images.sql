CREATE TABLE [dbo].[Images] (
    [Id]        INT         IDENTITY (1, 1) NOT NULL,
    [ImageName] NCHAR (100) NULL,
	[UploadDateTime] DateTime NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

