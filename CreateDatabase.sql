CREATE DATABASE TechNationDB;

USE TechNationDB;

CREATE TABLE NotasFiscais (
    Id INT PRIMARY KEY IDENTITY,
    NomePagador NVARCHAR(100),
    NumeroIdentificacao NVARCHAR(100),
    DataEmissao DATE,
    DataCobranca DATE,
    DataPagamento DATE,
    Valor DECIMAL(18, 2),
    DocumentoNotaFiscal NVARCHAR(100),
    DocumentoBoletoBancario NVARCHAR(100),
    Status INT
);


-- Gerar 1000 notas fiscais distribuídas ao longo de todos os meses do ano
DECLARE @counter INT = 1;
DECLARE @clientId INT;
DECLARE @date DATE;
DECLARE @value DECIMAL(18, 2);
DECLARE @month INT;
DECLARE @year INT = 2024;

WHILE @counter <= 1000
BEGIN
    SET @clientId = FLOOR(RAND() * 100) + 1;
    SET @month = FLOOR(RAND() * 12) + 1;
    SET @date = DATEFROMPARTS(@year, @month, FLOOR(RAND() * 28) + 1);
    SET @value = RAND() * 10000;

    INSERT INTO NotasFiscais (NomePagador, NumeroIdentificacao, DataEmissao, DataCobranca, DataPagamento, Valor, DocumentoNotaFiscal, DocumentoBoletoBancario, Status)
    VALUES (
        'Cliente ' + CAST(@clientId AS NVARCHAR(100)),
        'ID' + CAST(@counter AS NVARCHAR(100)),
        @date,
        DATEADD(DAY, 30, @date),
        NULL,
        @value,
        'NF' + CAST(@counter AS NVARCHAR(100)),
        'BB' + CAST(@counter AS NVARCHAR(100)),
        FLOOR(RAND() * 4)
    );

    SET @counter = @counter + 1;
END;