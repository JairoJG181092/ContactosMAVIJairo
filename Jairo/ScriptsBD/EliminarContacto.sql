CREATE PROCEDURE sp_EliminarContacto
@Id INT
AS
BEGIN
    DELETE FROM ContactosMAVIJairo WHERE Id = @Id;
END
