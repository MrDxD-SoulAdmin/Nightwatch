CREATE TABLE [dbo].[Movie]
(
	[MovieID] INT NOT NULL IDENTITY, 
    [Title] VARCHAR(100) NOT NULL, 
    [Description] VARCHAR(1000) NULL, 
    [Length] TIME(2) NOT NULL, 
    [RelasedOn] DATE NULL, 
    [AgeRating] INT NOT NULL, 
    [ThumbnailPath] VARCHAR(2000) NULL, 
    [FilePath] VARCHAR(200) NOT NULL, 
    [CreatedOn] DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_MovieID] PRIMARY KEY ([MovieID])
)
