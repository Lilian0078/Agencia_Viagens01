CREATE DATABASE dbAgencia_Viagens_
go
use dbAgencia_Viagens_
go

Create table COMPRA (
Codigo int identity(1,1) primary key,
DataCompra Date,
FormaPagamento varchar(100),
ValorTotal decimal(10,2)

)
go
--select * from COMPRA

--teste
INSERT COMPRA (DATACOMPRA, FORMAPAGAMENTO,VALORTOTAL) VALUES ('DATACOMPRA','FORMAPAGAMENTO','VALORTOTAL')

