﻿CREATE TABLE [dbo].[Genre]
(
	[GenreID] INT NOT NULL IDENTITY, 
    [GenreName] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_GenreID] PRIMARY KEY ([GenreID]),
)
