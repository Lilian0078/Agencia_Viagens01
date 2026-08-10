CREATE DATABASE dbAgencia_Viagens_
go
use dbAgencia_Viagens_
go

Create table CATEGORIA (
Codigo int identity(1,1) primary key,
Hotel varchar (100),
Aviao varchar(100),
Translado varchar(100),
Voucher varchar(100)
)

go
--select * from CATEGORIA

--teste
INSERT CATEGORIA (HOTEL, AVIAO, TRANSLADO, VOUCHER) VALUES ('HOTEL', 'AVIAO', 'TRANSLADO', 'VOUCHER')

