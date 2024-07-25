CREATE PROCEDURE sp_ConsultarContactos
@Nombre NVARCHAR(100)
AS
BEGIN
    SELECT * FROM ContactosMAVIJairo
    WHERE Nombre LIKE '%' + @Nombre + '%';
END