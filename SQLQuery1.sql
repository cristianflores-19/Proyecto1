CREATE TABLE Investigaciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Tema NVARCHAR(MAX),
    Resultado NVARCHAR(MAX),
    Fecha DATETIME DEFAULT GETDATE()

	select * from Investigaciones
);