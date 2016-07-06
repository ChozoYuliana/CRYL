create database CRYL_ventas
Go

use CRYL_ventas
Go

create table Cliente(
CodCliente int identity Primary key not null,
Nombre varchar(50),
Apellidos varchar(100),
Dni char(8),
Email varchar(80),
Telefono char(9),
Sexo varchar(1)
);

create table Empleado(
CodEmpleado int identity Primary key not null,
Nombre varchar(50),
Apellidos varchar(80),
Dni char(8),
Email varchar(80),
Telefono char(9),
Edad char(3),
Sexo varchar(1),
Cargo varchar(80)
);

create table Pedidos(
NroPedido char(5) Primary key not null,
CodCliente int,
CodEmpleado int,
FechaPedido date,
FechaEntrega date,
DireccionDestinatario varchar(80),
Constraint cli_pedido foreign key(CodCliente) references Cliente,
Constraint emp_pedido foreign key(CodEmpleado) references Empleado
);

create table Medicamentos(
CodMedicamento int identity Primary key not null,
NombreMedicamento varchar(80),
PrecioUnidad decimal(18,2),
UnidadesEnExistencia int
);

create table DetallePedidos(
NroPedido char(5),
CodMedicamento int,
Cantidad int,
Descuento decimal(18,2),
NroFactura int,
Constraint det_pedido foreign key (NroPedido) references Pedidos,
Constraint det_medi foreign key (CodMedicamento) references Medicamentos
);









select * from Pedidos

delete from Pedidos

insert into Pedidos values('PED01',1,1,'2016/06/13','2016/06/01','El sol');

select * from Medicamentos


select * from Pedidos

insert into DetallePedidos values(20,1,12,13);

select * from DetallePedidos
