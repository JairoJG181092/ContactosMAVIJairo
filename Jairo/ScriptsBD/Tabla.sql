CREATE TABLE ContactosMAVIJairo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    TipoContacto NVARCHAR(50) NOT NULL,
    TelefonoFijo NVARCHAR(15) NULL,
    TelefonoMovil NVARCHAR(15) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Sexo NVARCHAR(10) NOT NULL,
    EstadoCivil NVARCHAR(20) NOT NULL
);