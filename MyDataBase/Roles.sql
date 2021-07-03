CREATE TABLE [dbo].[Roles]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nombre] VARCHAR(50) NOT NULL, 
    [Eliminado] BIT NOT NULL DEFAULT 0
)
