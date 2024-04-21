CREATE TABLE [dbo].[UserLikedMovie]
(
	[UserID] INT NOT NULL, 
    [MovieID] INT NOT NULL,
	CONSTRAINT [LikedID] PRIMARY KEY ([UserID], [MovieID]),
	CONSTRAINT [FK_UserLikedMovieForUsID] FOREIGN KEY ([UserID]) REFERENCES [User]([UserID]),
	CONSTRAINT [FK_UserlikedMovieForMovID] FOREIGN KEY ([MovieID]) REFERENCES [Movie]([MovieID])
)
