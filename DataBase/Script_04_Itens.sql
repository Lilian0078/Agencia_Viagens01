CREATE DATABASE dbAgencia_Viagens_
go
use dbAgencia_Viagens_
go

Create table ITENS (
Codigo int identity(1,1) primary key,
CodigoProduto varchar(100),
CodigoPacote varchar(100),
Quantidade varchar(100),
ValorUnidade decimal(10,2)

)
go
--select * from ITENS

--teste
INSERT ITENS (CODIGOPRODUTO, CODIGOPACOTE, QUANTIDADE, VALORUNIDADE) VALUES ('CODIGOPRODUTO', 'CODIGOPACOTE', 'QUANTIDADE', 'VALORUNIDADE')

