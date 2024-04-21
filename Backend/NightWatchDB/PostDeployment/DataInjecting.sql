/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r ./InsertData/UserDataInject.sql
:r ./InsertData/MovieDataInject.sql
:r ./InsertData/GenreDataInject.sql
:r ./InsertData/MovieGenreDataInject.sql
:r ./InsertData/UserLikedMovieDataInject.sql
:r ./InsertData/UserDislikedMovieDataInject.sql
