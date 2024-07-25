CREATE PROCEDURE sp_ActualizarContacto
@Id INT,
@Nombre NVARCHAR(100),
@TipoContacto NVARCHAR(50),
@TelefonoFijo NVARCHAR(15),
@TelefonoMovil NVARCHAR(15),
@FechaNacimiento DATE,
@Sexo NVARCHAR(10),
@EstadoCivil NVARCHAR(20)
AS
BEGIN
    UPDATE ContactosMAVIJairo
    SET Nombre = @Nombre, TipoContacto = @TipoContacto, TelefonoFijo = @TelefonoFijo, TelefonoMovil = @TelefonoMovil,
        FechaNacimiento = @FechaNacimiento, Sexo = @Sexo, EstadoCivil = @EstadoCivil
    WHERE Id = @Id;
END
