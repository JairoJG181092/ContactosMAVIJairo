CREATE PROCEDURE sp_ObtenerTodosContactos
AS
BEGIN
    SELECT Id, Nombre, Tipo, TelefonoFijo, TelefonoMovil, FechaNacimiento, Sexo, EstadoCivil
    FROM ContactosMAVIAdrian;
END