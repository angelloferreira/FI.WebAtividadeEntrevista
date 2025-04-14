CREATE PROCEDURE FI_SP_ConsBeneficiariosCliente
    @IdCliente BIGINT
AS
BEGIN
    SELECT Id, Nome, Cpf, IdCliente
    FROM Beneficiarios
    WHERE IdCliente = @IdCliente
END