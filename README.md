# ConsoleMenu
Console app referente a atividade prática de fundamentos do C# do PDI. 

# ScriptsBD

## Criação da tabela Cliente
CREATE TABLE Cliente(Id INT PRIMARY KEY, Nome VARCHAR(100), Cpf BIGINT, Saldo FLOAT);

## Inserção de Cliente
INSERT INTO Cliente(Id, Nome, Cpf, Saldo) VALUES (@Id, @Nome, @Cpf, @Saldo);

## Verificação se Cliente já existe na base de dados
SELECT COUNT(*) FROM Cliente WHERE Id = @Id;

## Atualização de Cliente na Base de dados
UPDATE Cliente SET Nome = @Nome, Cpf = @Cpf, Saldo = @Saldo WHERE Id = @Id;
