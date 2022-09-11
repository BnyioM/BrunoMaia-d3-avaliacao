CREATE DATABASE [BrunoMaia-d3-avaliacao];
GO

-- Define qual banco de dados ser� utilizado
USE [BrunoMaia-d3-avaliacao];
GO

-- Cria a tabela Accounts
CREATE TABLE Accounts(
	IdAccount		    VARCHAR(255) NOT NULL UNIQUE,
	[Name]			    VARCHAR(255) NOT NULL,
	[Email]     		VARCHAR(255) NOT NULL,
	[Password]			VARCHAR(255) NOT NULL
);
GO

-- Lista os dados da tabela
SELECT * FROM Accounts;
GO

-- Insere um registro na tabela
INSERT INTO Accounts (IdAccount, [Name], [Email], [Password])
VALUES				 ('ADM-01', 'Admin', 'admin@email.com', 'admin123');
GO

INSERT INTO Accounts (IdAccount, [Name], [Email], [Password])
VALUES				 ('ADM-02', 'Test', 'test@email.com', 'test123');
GO

