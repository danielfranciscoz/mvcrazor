﻿CREATE TABLE [dbo].[Roles]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [NombreRol] VARCHAR(50) NOT NULL, 
    [Activo] BIT NOT NULL DEFAULT 0
)
