﻿CREATE PROCEDURE FI_SP_DelBeneficiario
    @Id BIGINT
AS
BEGIN
    DELETE FROM Beneficiarios WHERE Id = @Id
END