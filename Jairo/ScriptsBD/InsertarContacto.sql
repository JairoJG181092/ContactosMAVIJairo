CREATE PROCEDURE sp_InsertarContacto
@Nombre NVARCHAR(100),
@TipoContacto NVARCHAR(50),
@TelefonoFijo NVARCHAR(15),
@TelefonoMovil NVARCHAR(15),
@FechaNacimiento DATE,
@Sexo NVARCHAR(10),
@EstadoCivil NVARCHAR(20)
AS
BEGIN
    INSERT INTO ContactosMAVIJairo (Nombre, TipoContacto, TelefonoFijo, TelefonoMovil, FechaNacimiento, Sexo, EstadoCivil)
    VALUES (@Nombre, @TipoContacto, @TelefonoFijo, @TelefonoMovil, @FechaNacimiento, @Sexo, @EstadoCivil);
END
