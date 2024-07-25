CREATE PROCEDURE sp_ConsultarContactoPorId
@Id INT
AS
BEGIN
    SELECT * FROM ContactosMAVIJairo
    WHERE Id = @Id;
END