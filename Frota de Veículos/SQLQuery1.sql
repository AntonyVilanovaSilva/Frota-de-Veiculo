Use master
go
Create Database FrotadeVeículo
use FrotadeVeículo
go

Create Table Veiculo(
VeId int identity(1,1) primary key,
VeiPlaca varchar(100) not null,
VeiCor varchar(100) null,
VeiMarca varchar(100) null,
CombId int not null FOREIGN KEY REFERENCES TipoCombustivel(CombId)
)

Insert into Veiculo (VeiPlaca,VeiCor,VeiMarca,CombId) values ('JQB-7519','Vermelho','Mercedes',1)
Select * from Veiculo
DROP TABLE Veiculo


Create Table Motorista(
MotId int identity(1,1) primary key,
Nome varchar(100) not null,
Idade varchar(100) null,
VeId int not null FOREIGN KEY REFERENCES Veiculo(VeId)
)

Insert into Motorista (Nome,Idade,VeId) values ('Antony','22',4)

Select * from Motorista


Create Table Posto(
PoId int identity(1,1) primary key,
Nome varchar(100) not null,
Localizacao varchar(100) null,
OrdSerId int not null FOREIGN KEY REFERENCES OrdemServico(OrdSerId)
)

Insert into Posto (Nome,Localizacao,OrdSerId) values ('Posto Estanciano','Estancia',4)
Select * from Posto


Create Table TipoCombustivel(
CombId int identity(1,1) primary key,
ValorLitro float null,
Nome varchar(100) not null,
)

Insert into TipoCombustivel (ValorLitro,Nome) values ('5.60','Diesel')

Create Table OrdemServico(
OrdSerId int identity(1,1) primary key,
Data date,
QuantidadeCombustivel float,
MotId int not null FOREIGN KEY REFERENCES Motorista(MotId),
CombId int not null FOREIGN KEY REFERENCES TipoCombustivel(CombId)
)

Insert into OrdemServico (Data,QuantidadeCombustivel,MotId,CombId) values ('04-04-2024','1500',5,1)
select * from OrdemServico