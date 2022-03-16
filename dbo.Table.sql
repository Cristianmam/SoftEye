CREATE TABLE [dbo].[Pacientes]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [nombre] VARCHAR(50) NULL, 
    [fdn] DATE NULL, 
    [dni] VARCHAR(50) NULL, 
    [edad] INT NULL, 
    [telefono] VARCHAR(50) NULL, 
    [domicilio] VARCHAR(50) NULL, 
    [email] VARCHAR(50) NULL, 
    [hclinica] VARCHAR(50) NULL
)
