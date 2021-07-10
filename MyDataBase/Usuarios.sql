CREATE TABLE [dbo].[Usuario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Usuario] VARCHAR(50) NOT NULL, 
    [Nombre] VARCHAR(50) NOT NULL, 
    [Correo] VARCHAR(50) NOT NULL, 
    [IdRol] INT NULL,
    [Activo] BIT NOT NULL, 

    FOREIGN KEY (IdRol) REFERENCES Roles(Id)
)
