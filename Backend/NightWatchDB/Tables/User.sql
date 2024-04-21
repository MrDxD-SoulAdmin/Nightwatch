CREATE TABLE [dbo].[User]
(
	[UserID] INT NOT NULL IDENTITY, 
    [Email] VARCHAR(100) NOT NULL, 
    [Username] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(64) NOT NULL, 
    [BirthDate] DATE NOT NULL, 
    [ProfilePath] VARCHAR(200) NULL,
    [CreatedOn] DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_UserID] PRIMARY KEY ([UserID]),
)
