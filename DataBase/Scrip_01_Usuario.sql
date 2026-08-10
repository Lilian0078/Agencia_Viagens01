CREATE DATABASE dbAgencia_Viagens_
go
use dbAgencia_Viagens_
go

Create table USUARIO (
Codigo int identity(1,1) primary key,
Nome varchar (100),
Senha varchar (8),
Email varchar(100),
CodigoFuncionario int 
)

go
--select * from USUARIO

--teste
INSERT USUARIO (NOME,EMAIL) VALUES ('LOGIN', 'EMAIL')

