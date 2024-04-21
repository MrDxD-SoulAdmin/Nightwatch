CREATE TABLE [dbo].[MovieGenre]
(
	[MovieID] INT NOT NULL, 
    [GenreID] INT NOT NULL,
	CONSTRAINT [MovieGenreID] PRIMARY KEY ([GenreID], [MovieID]),
	CONSTRAINT [FK_MovieGenreForMovID] FOREIGN KEY ([MovieID]) REFERENCES [Movie]([MovieID]),
	CONSTRAINT [FK_MovieGenreForGenID] FOREIGN KEY ([GenreID]) REFERENCES [Genre]([GenreID])
)
