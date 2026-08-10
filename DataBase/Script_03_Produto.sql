CREATE DATABASE dbAgencia_Viagens_
go
use dbAgencia_Viagens_
go

Create table PRODUTO (
Codigo int identity(1,1) primary key,
Descricao varchar (200)
)

go
--select * from PRODUTO

--teste
INSERT PRODUTO (DESCRICAO) VALUES ('DESCRICAO')

