CREATE TABLE [dbo].[UserDislikedMovie]
(
	[UserID] INT NOT NULL, 
    [MovieID] INT NOT NULL,
	CONSTRAINT [DislikedID] PRIMARY KEY ([UserID], [MovieID]),
	CONSTRAINT [FK_UserDislikedMovieForUsID] FOREIGN KEY ([UserID]) REFERENCES [User]([UserID])  ON DELETE CASCADE,
	CONSTRAINT [FK_UserDislikedMovieForMovID] FOREIGN KEY ([MovieID]) REFERENCES [Movie]([MovieID])  ON DELETE CASCADE
)
