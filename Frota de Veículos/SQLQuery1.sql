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

Select * from Veiculo
DROP TABLE Veiculo

Create Table Motorista(
MotId int identity(1,1) primary key,
Nome varchar(100) not null,
Idade varchar(100) null,
VeId int not null FOREIGN KEY REFERENCES Veiculo(VeId)
)

Select * from Motorista

Create Table Posto(
PoId int identity(1,1) primary key,
Nome varchar(100) not null,
Localizacao varchar(100) null,
OrdSerId int not null FOREIGN KEY REFERENCES OrdemServico(OrdSerId)
)

Select * from Posto


Create Table TipoCombustivel(
CombId int identity(1,1) primary key,
ValorLitro float null,
Nome varchar(100) not null,
)

select * from TipoCombustivel

Create Table OrdemServico(
OrdSerId int identity(1,1) primary key,
Data date,
QuantidadeCombustivel float,
MotId int not null FOREIGN KEY REFERENCES Motorista(MotId),
CombId int not null FOREIGN KEY REFERENCES TipoCombustivel(CombId)
)